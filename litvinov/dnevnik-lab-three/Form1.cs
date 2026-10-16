using Microsoft.VisualBasic;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace WinFormsApp2
{
    public partial class frmMain : Form
    {
        // флаг: есть ли несохранённые изменения записи
        private bool changed = false;

        public frmMain()
        {
            InitializeComponent();
        }

        // ---------- загрузка формы ----------
        private void frmMain_Load(object sender, EventArgs e)
        {
            dtpDate.Value = DateTime.Now;
            UpdateStats();
            Log("Форма загружена");
        }

        // ---------- изменение даты пользователем ----------
        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            Log("Дата изменена: " + dtpDate.Value.ToString("dd.MM.yyyy"));
        }

        // ---------- общий обработчик шести кнопок команд ----------
        // приём задания: конкретная кнопка узнаётся через sender, действие — через switch по имени
        private void Command_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;               // кто вызвал обработчик
            Log("Команда: " + btn.Text);
            switch (btn.Name)
            {
                case "btnNew": NewNote(); break;
                case "btnOpen": OpenNote(); break;
                case "btnSave": SaveNote(); break;
                case "btnClear": ClearNote(); break;
                case "btnColor": SetTextColor(); break;
                case "btnBkg": SetBkgColor(); break;
            }
        }

        // ---------- статистика текста (символы, слова, строки) ----------
        private void UpdateStats()
        {
            string text = txtNote.Text;
            string[] words = text.Split(new char[] { ' ', '\n', '\r', '\t' },
                StringSplitOptions.RemoveEmptyEntries);
            int lines = 1;
            foreach (char c in text)
                if (c == '\n') lines++;
            lblStats.Text = "Символов: " + text.Length +
                            "  Слов: " + words.Length +
                            "  Строк: " + lines;
        }

        private void txtNote_TextChanged(object sender, EventArgs e)
        {
            UpdateStats();
            changed = true;
            UpdateTitle();
        }

        // ---------- журнал событий (не более 10 последних записей) ----------
        private void Log(string message)
        {
            lstLog.Items.Add(DateTime.Now.ToString("HH:mm:ss") + " " + message);
            while (lstLog.Items.Count > 10)
                lstLog.Items.RemoveAt(0);           // храним только 10 последних
            lstLog.TopIndex = lstLog.Items.Count - 1;
        }

        // ---------- заголовок формы и флаг изменений ----------
        private void UpdateTitle()
        {
            this.Text = "Дневник практики" + (changed ? " *" : "");
        }

        // ---------- запрет ввода цифр в тему записи ----------
        private void txtTitle_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = true;                    // символ отбрасывается
                Log("Заблокирован символ: " + e.KeyChar);
            }
        }

        // ---------- координаты мыши ----------
        private void frmMain_MouseMove(object sender, MouseEventArgs e)
        {
            lblCoords.Text = "X: " + e.X + "   Y: " + e.Y;
        }

        // ---------- подсветка кнопок при наведении ----------
        private void Command_MouseEnter(object sender, EventArgs e)
        {
            ((Button)sender).BackColor = Color.LightSkyBlue;
        }

        private void Command_MouseLeave(object sender, EventArgs e)
        {
            ((Button)sender).BackColor = SystemColors.Control;
        }

        // ---------- команды ----------

        // на текущем этапе задания NewNote остаётся заглушкой (см. Задание 1.2)
        private void NewNote()
        {
            MessageBox.Show("Команда «Новая запись»", "Дневник практики");
        }

        private void ClearNote()
        {
            if (changed)
            {
                DialogResult r = MessageBox.Show("Очистить запись?", "Дневник практики",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (r != DialogResult.Yes) return;    // «Нет» — ничего не делаем
            }
            txtTitle.Clear();
            txtNote.Clear();
            changed = false;
            UpdateTitle();
            UpdateStats();
            Log("Запись очищена");
        }

        private void SaveNote()
        {
            dlgSave.FileName = txtTitle.Text + ".txt";      // имя по умолчанию из темы записи
            if (dlgSave.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(dlgSave.FileName, txtNote.Text);
                changed = false;
                UpdateTitle();
                Log("Сохранено: " + dlgSave.FileName);
            }
            else
            {
                Log("Сохранение отменено");
            }
        }

        private void OpenNote()
        {
            if (changed)
            {
                DialogResult r = MessageBox.Show("Сохранить текущую запись перед открытием?",
                    "Дневник практики", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (r == DialogResult.Yes)
                {
                    SaveNote();
                    if (changed) return;              // сохранение отменили — открытие не выполняем
                }
                else if (r == DialogResult.Cancel)
                {
                    return;                            // «Отмена» — ничего не меняем
                }
                // «Нет» — переходим сразу к выбору файла
            }

            if (dlgOpen.ShowDialog() == DialogResult.OK)
            {
                txtNote.Text = File.ReadAllText(dlgOpen.FileName);
                txtTitle.Text = Path.GetFileNameWithoutExtension(dlgOpen.FileName);
                changed = false;
                UpdateTitle();
                UpdateStats();                         // статистика по загруженному тексту
                Log("Открыто: " + dlgOpen.FileName);
            }
            else
            {
                Log("Открытие отменено");
            }
        }

        private void SetTextColor()
        {
            if (dlgColorText.ShowDialog() == DialogResult.OK)
                txtNote.ForeColor = dlgColorText.Color;
            // «Отмена» — цвет не меняется
        }

        private void SetBkgColor()
        {
            if (dlgColorBkg.ShowDialog() == DialogResult.OK)
                txtNote.BackColor = dlgColorBkg.Color;
            // «Отмена» — цвет не меняется
        }

        // ---------- подтверждение выхода при несохранённых изменениях ----------
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!changed) return;                     // изменений нет — выходим без вопроса

            DialogResult r = MessageBox.Show("Выйти без сохранения?", "Выход",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (r == DialogResult.No)
                e.Cancel = true;                       // форма не закроется
        }

    }
}