using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MovieBase
{
    // Главная форма «Кинобаза». Данные — в списке movies; DataGridView только отображает.
    // Индекс строки таблицы == индекс фильма в списке, потому что сортировка по заголовкам
    // запрещена (SortMode = NotSortable) — решение задания 2.5.
    public partial class frmMain : Form
    {
        private List<Movie> movies = new List<Movie>(); // данные — поле формы
        private bool changed = false;                   // флаг изменений («*» в заголовке)
        private string fileName = "";
        private frmAbout? about;                        // немодальная форма

        public frmMain()
        {
            InitializeComponent();

            // задание 2.5: запрет сортировки, чтобы индекс строки совпадал с индексом списка
            foreach (DataGridViewColumn c in dgvMovies.Columns)
                c.SortMode = DataGridViewColumnSortMode.NotSortable;

            // сочетания клавиш (Ins и Del обрабатываются в KeyDown таблицы, чтобы
            // не мешать правке текста в ячейке)
            miNew.ShortcutKeys = Keys.Control | Keys.N;
            miOpen.ShortcutKeys = Keys.Control | Keys.O;
            miSave.ShortcutKeys = Keys.Control | Keys.S;
            miEdit.ShortcutKeys = Keys.F4;
            miTop.ShortcutKeys = Keys.F9;
            miAbout.ShortcutKeys = Keys.F1;
            miExit.ShortcutKeyDisplayString = "Alt+F4";
            miAdd.ShortcutKeyDisplayString = "Ins";
            miDelete.ShortcutKeyDisplayString = "Del";

            dlgOpen.Filter = dlgSave.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            FormClosing += frmMain_FormClosing;

            RefreshGrid();
            UpdateTitle();
        }

        // ---------- служебные методы ----------
        private void UpdateTitle() => Text = "Кинобаза" + (changed ? "*" : "");

        private void MarkChanged()
        {
            changed = true;
            UpdateTitle();
        }

        // Перерисовка таблицы из списка (после каждого изменения данных)
        private void RefreshGrid()
        {
            int keep = dgvMovies.CurrentRow != null ? dgvMovies.CurrentRow.Index : -1;

            dgvMovies.Rows.Clear();
            foreach (Movie m in movies)
            {
                int i = dgvMovies.Rows.Add(m.Title, m.Year, m.Genre, m.Country,
                                           m.Director, m.Mark, m.Watched);
                DataGridViewRow row = dgvMovies.Rows[i];
                if (m.Mark == 10)                                   // подсветка лучших
                    row.DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
                if (!m.Watched)                                     // «ещё не смотрел»
                    row.DefaultCellStyle.ForeColor = Color.Gray;
            }

            if (dgvMovies.Rows.Count > 0)
            {
                if (keep < 0) keep = 0;
                if (keep >= dgvMovies.Rows.Count) keep = dgvMovies.Rows.Count - 1;
                dgvMovies.CurrentCell = dgvMovies.Rows[keep].Cells[0];
            }
            UpdateStatus();
        }

        // Единый метод обновления строки состояния и блокировки команд
        private void UpdateStatus()
        {
            bool any = movies.Count > 0;
            sslCount.Text = "Фильмов: " + movies.Count;

            if (!any)
            {
                sslRating.Text = "Средняя оценка: —";
                sslInfo.Text = "Ничего не выбрано";
            }
            else
            {
                int sum = 0, watched = 0;
                foreach (Movie m in movies)
                {
                    sum += m.Mark;
                    if (m.Watched) watched++;
                }
                sslCount.Text += " (просмотрено: " + watched + ")";
                sslRating.Text = "Средняя оценка: " +
                    ((double)sum / movies.Count).ToString("F1", CultureInfo.InvariantCulture);

                int idx = dgvMovies.CurrentRow == null ? -1 : dgvMovies.CurrentRow.Index;
                if (idx < 0 || idx >= movies.Count)
                    sslInfo.Text = "Ничего не выбрано";
                else
                    sslInfo.Text = "Выбран: " + movies[idx].Title + " (" + movies[idx].Year + ")";
            }

            // блокировка кнопок тулбара при пустом списке
            btnTDelete.Enabled = any;
            btnTEdit.Enabled = any;
            btnTTop.Enabled = any;
        }

        private bool ConfirmDiscard()
        {
            if (!changed) return true;
            return MessageBox.Show("Есть несохранённые изменения. Продолжить?", "Кинобаза",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }

        // ---------- демо-данные ----------
        private void LoadDemo()
        {
            movies = new List<Movie>
            {
                new Movie { Title = "Интерстеллар", Year = 2014, Genre = "фантастика",
                            Country = "США", Director = "Нолан", Mark = 10, Watched = true },
                new Movie { Title = "Джентльмены удачи", Year = 1971, Genre = "комедия",
                            Country = "СССР", Director = "Гайдай", Mark = 9, Watched = true },
                new Movie { Title = "Начало", Year = 2010, Genre = "фантастика",
                            Country = "США", Director = "Нолан", Mark = 9, Watched = true },
                new Movie { Title = "Один дома", Year = 1990, Genre = "комедия",
                            Country = "США", Director = "Коламбус", Mark = 8, Watched = false },
                new Movie { Title = "Крепкий орешек", Year = 1988, Genre = "боевик",
                            Country = "США", Director = "МакТирнан", Mark = 7, Watched = false },
                new Movie { Title = "Побег из Шоушенка", Year = 1994, Genre = "драма",
                            Country = "США", Director = "Дарабонт", Mark = 10, Watched = true }
            };
            RefreshGrid();
        }

        private void miDemo_Click(object sender, EventArgs e)
        {
            if (movies.Count > 0 && changed && !ConfirmDiscard()) return;
            LoadDemo();
            MarkChanged();
        }

        // ---------- добавление / правка / удаление ----------
        private void AddMovie()
        {
            dgvMovies.CancelEdit();
            using (var f = new frmMovie("Добавить фильм"))
            {
                if (f.ShowDialog(this) != DialogResult.OK) return;
                movies.Add(new Movie
                {
                    Title = f.MovieTitle,
                    Year = f.Year,
                    Genre = f.Genre,
                    Country = f.Country,
                    Director = f.Director,
                    Mark = f.Mark,
                    Watched = f.Watched
                });
            }
            MarkChanged();
            RefreshGrid();
            // выделить только что добавленный фильм
            dgvMovies.CurrentCell = dgvMovies.Rows[dgvMovies.Rows.Count - 1].Cells[0];
        }

        private void EditMovie()
        {
            if (dgvMovies.CurrentRow == null)
            { MessageBox.Show("Сначала выделите фильм"); return; }
            dgvMovies.CancelEdit();
            int i = dgvMovies.CurrentRow.Index;
            if (i < 0 || i >= movies.Count) return;
            Movie m = movies[i];

            using (var f = new frmMovie("Редактировать фильм"))
            {
                f.MovieTitle = m.Title;
                f.Year = m.Year;
                f.Genre = m.Genre;
                f.Country = m.Country;
                f.Director = m.Director;
                f.Mark = m.Mark;
                f.Watched = m.Watched;

                if (f.ShowDialog(this) != DialogResult.OK) return;   // «Отмена» — без изменений

                m.Title = f.MovieTitle;
                m.Year = f.Year;
                m.Genre = f.Genre;
                m.Country = f.Country;
                m.Director = f.Director;
                m.Mark = f.Mark;
                m.Watched = f.Watched;
            }
            MarkChanged();
            RefreshGrid();
        }

        private void DeleteMovie()
        {
            if (dgvMovies.CurrentRow == null)
            { MessageBox.Show("Сначала выделите фильм"); return; }
            dgvMovies.CancelEdit();
            int i = dgvMovies.CurrentRow.Index;
            if (i < 0 || i >= movies.Count) return;
            DialogResult r = MessageBox.Show(
                "Удалить «" + movies[i].Title + "» из коллекции?",
                "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r != DialogResult.Yes) return;
            movies.RemoveAt(i);
            MarkChanged();
            RefreshGrid();
        }

        private void ToggleWatched()
        {
            if (dgvMovies.CurrentRow == null)
            { MessageBox.Show("Сначала выделите фильм"); return; }
            dgvMovies.CancelEdit();
            int i = dgvMovies.CurrentRow.Index;
            if (i < 0 || i >= movies.Count) return;
            movies[i].Watched = !movies[i].Watched;
            MarkChanged();
            RefreshGrid();
        }

        // общие обработчики для меню, тулбара и контекстного меню
        private void miAdd_Click(object sender, EventArgs e) => AddMovie();
        private void miEdit_Click(object sender, EventArgs e) => EditMovie();
        private void miDelete_Click(object sender, EventArgs e) => DeleteMovie();
        private void miToggle_Click(object sender, EventArgs e) => ToggleWatched();

        // ---------- события таблицы ----------
        private void dgvMovies_SelectionChanged(object sender, EventArgs e) => UpdateStatus();

        private void dgvMovies_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) EditMovie();
        }

        private void dgvMovies_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
            {
                AddMovie();
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Delete)
            {
                DeleteMovie();
                e.Handled = true;
            }
        }

        // галочка «Просмотрен» — тоже правка
        private void dgvMovies_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= movies.Count) return;
            if (e.ColumnIndex != colWatched.Index) return;
            movies[e.RowIndex].Watched = !movies[e.RowIndex].Watched;
            MarkChanged();
            BeginInvoke(new Action(RefreshGrid));   // перерисовка не из самого события таблицы
        }

        // проверка вводимого значения: нарушение — откат и сообщение
        private void dgvMovies_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            string s = Convert.ToString(e.FormattedValue)?.Trim() ?? "";
            string error = "";

            if (e.ColumnIndex == colTitle.Index && s.Length == 0)
                error = "Название не может быть пустым";
            else if (e.ColumnIndex == colYear.Index &&
                     (!int.TryParse(s, out int year) || year < Movie.MinYear || year > Movie.MaxYear))
                error = "Год — число от 1895 до 2025";
            else if (e.ColumnIndex == colGenre.Index &&
                     !Movie.Genres.Any(g => string.Equals(g, s, StringComparison.OrdinalIgnoreCase)))
                error = "Жанр — один из списка: " + string.Join(", ", Movie.Genres);
            else if (e.ColumnIndex == colCountry.Index && s.Length == 0)
                error = "Страна не может быть пустой";
            else if (e.ColumnIndex == colDirector.Index && s.Length == 0)
                error = "Режиссёр не может быть пустым";
            else if (e.ColumnIndex == colMark.Index &&
                     (!int.TryParse(s, out int mark) || mark < Movie.MinMark || mark > Movie.MaxMark))
                error = "Оценка — число от 1 до 10";

            if (error.Length > 0)
            {
                MessageBox.Show(error, "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;                                   // правка не принимается
                BeginInvoke(new Action(() => dgvMovies.CancelEdit())); // откат прежнего значения
            }
        }

        // завершение правки ячейки: значение переносится в объект
        private void dgvMovies_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= movies.Count) return;
            Movie m = movies[e.RowIndex];
            string s = Convert.ToString(dgvMovies.Rows[e.RowIndex].Cells[e.ColumnIndex].Value)?.Trim() ?? "";

            if (e.ColumnIndex == colTitle.Index) m.Title = s;
            else if (e.ColumnIndex == colYear.Index) { if (int.TryParse(s, out int y)) m.Year = y; }
            else if (e.ColumnIndex == colGenre.Index)
            {
                string g = Movie.Genres.FirstOrDefault(
                    x => string.Equals(x, s, StringComparison.OrdinalIgnoreCase)) ?? s;
                m.Genre = g;
            }
            else if (e.ColumnIndex == colCountry.Index) m.Country = s;
            else if (e.ColumnIndex == colDirector.Index) m.Director = s;
            else if (e.ColumnIndex == colMark.Index) { if (int.TryParse(s, out int k)) m.Mark = k; }
            else return;

            MarkChanged();
            BeginInvoke(new Action(RefreshGrid));   // статистика и подсветка пересчитываются
        }

        // ---------- Файл ----------
        private void miNew_Click(object sender, EventArgs e)
        {
            if (!ConfirmDiscard()) return;
            movies = new List<Movie>();
            fileName = "";
            changed = false;
            RefreshGrid();
            UpdateTitle();
        }

        private void miOpen_Click(object sender, EventArgs e)
        {
            if (!ConfirmDiscard()) return;
            if (dlgOpen.ShowDialog() != DialogResult.OK) return;
            LoadFromFile(dlgOpen.FileName);
        }

        private void miSave_Click(object sender, EventArgs e) => SaveToFile();

        private void miExit_Click(object sender, EventArgs e) => Close();

        // «;» и переводы строк внутри значения заменяются, чтобы не ломать формат
        private static string Clean(string s) =>
            s.Replace(';', ',').Replace('\r', ' ').Replace('\n', ' ');

        private bool SaveToFile()
        {
            if (dlgSave.ShowDialog() != DialogResult.OK) return false;
            try
            {
                var sb = new StringBuilder();
                foreach (Movie m in movies)
                {
                    sb.AppendLine(string.Join(";", new object[]
                    {
                        Clean(m.Title), m.Year, Clean(m.Genre), Clean(m.Country),
                        Clean(m.Director), m.Mark, m.Watched ? "true" : "false"
                    }));
                }
                File.WriteAllText(dlgSave.FileName, sb.ToString(), Encoding.UTF8);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось сохранить файл: " + ex.Message, "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            fileName = dlgSave.FileName;
            changed = false;
            UpdateTitle();
            return true;
        }

        private void LoadFromFile(string path)
        {
            string[] lines;
            try
            {
                lines = File.ReadAllLines(path, Encoding.UTF8);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось открыть файл: " + ex.Message, "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var loaded = new List<Movie>();
            int skipped = 0;
            foreach (string line in lines)
            {
                if (line.Trim().Length == 0) continue;
                string[] p = line.Split(';');
                if (p.Length != 7) { skipped++; continue; }
                for (int i = 0; i < p.Length; i++) p[i] = p[i].Trim();

                if (p[0].Length == 0 ||
                    !int.TryParse(p[1], out int year) || year < Movie.MinYear || year > Movie.MaxYear ||
                    !int.TryParse(p[5], out int mark) || mark < Movie.MinMark || mark > Movie.MaxMark ||
                    !bool.TryParse(p[6], out bool watched))
                { skipped++; continue; }

                loaded.Add(new Movie
                {
                    Title = p[0],
                    Year = year,
                    Genre = p[2],
                    Country = p[3],
                    Director = p[4],
                    Mark = mark,
                    Watched = watched
                });
            }

            movies = loaded;
            fileName = path;
            changed = false;
            RefreshGrid();
            UpdateTitle();
            if (skipped > 0)
                MessageBox.Show("Пропущено строк: " + skipped, "Открытие файла",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!changed) return;
            DialogResult r = MessageBox.Show("Сохранить изменения перед выходом?", "Кинобаза",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (r == DialogResult.Yes) { if (!SaveToFile()) e.Cancel = true; }
            else if (r == DialogResult.Cancel) e.Cancel = true;
        }

        // ---------- Отчёты ----------
        private void TopList()
        {
            if (movies.Count == 0)
            {
                MessageBox.Show("Коллекция пуста — подводить итоги не по чему.", "Топ-лист",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int watched = movies.Count(m => m.Watched);
            double avg = movies.Average(m => m.Mark);
            int best = movies.Max(m => m.Mark);
            string bestNames = string.Join(", ",
                movies.Where(m => m.Mark == best).Select(m => "«" + m.Title + "»"));
            int minYear = movies.Min(m => m.Year);
            int maxYear = movies.Max(m => m.Year);

            var byGenre = movies.GroupBy(m => m.Genre)
                                .Select(g => new { Genre = g.Key, Count = g.Count() }).ToList();
            int maxCount = byGenre.Max(g => g.Count);
            string topGenres = string.Join(", ",
                byGenre.Where(g => g.Count == maxCount).Select(g => g.Genre));

            string text =
                "Всего фильмов: " + movies.Count + ", просмотрено: " + watched + "\n" +
                "Средняя оценка: " + avg.ToString("F1", CultureInfo.InvariantCulture) + "\n" +
                "Лучший фильм (оценка " + best + "): " + bestNames + "\n" +
                "Самый ранний год: " + minYear + ", самый поздний: " + maxYear + "\n" +
                "Чаще всего встречается жанр: " + topGenres + " (" + maxCount + ")";

            MessageBox.Show(text, "Топ-лист", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void miTop_Click(object sender, EventArgs e) => TopList();

        // ---------- Справка ----------
        private void miAbout_Click(object sender, EventArgs e)
        {
            if (about == null || about.IsDisposed) about = new frmAbout();
            about.Show(this);
        }
    }
}