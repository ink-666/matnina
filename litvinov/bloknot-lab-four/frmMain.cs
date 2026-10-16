using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace lab_3_bloknot
{
    // Главная форма. Элементы расставлены в конструкторе (Toolbox), имена — см. комментарий ниже.
    //   menuMain (MenuStrip): miNew, miOpen, miSave, miExit | miFind, miClear, miSelectAll, miGoTo |
    //                         miPreview, miParams, miStats | miAbout
    //   toolMain (ToolStrip): tbNew, tbOpen, tbSave, tbFind
    //   pnlFind (Panel, Dock=Top, Visible=false): lblFind, txtFind, btnFindNext, btnCloseFind
    //   tabMain (TabControl, Dock=Fill): tabpEdit -> txtEdit, tabpPreview -> txtPreview
    //   statMain (StatusStrip): lblChars, lblWords, lblFile
    //   dlgOpen (OpenFileDialog), dlgSave (SaveFileDialog), ctxEdit (ContextMenuStrip)
    public partial class frmMain : Form
    {
        private bool changed = false;
        private bool loading = false;
        private string fileName = "";
        private int findPos = 0;

        private bool showWords = true;
        private bool showLineNumbers = false;

        private frmAbout? about; // немодальная форма

        public frmMain()
        {
            InitializeComponent();

            // сочетания клавиш
            miNew.ShortcutKeys = Keys.Control | Keys.N;
            miOpen.ShortcutKeys = Keys.Control | Keys.O;
            miSave.ShortcutKeys = Keys.Control | Keys.S;
            miFind.ShortcutKeys = Keys.Control | Keys.F;
            miSelectAll.ShortcutKeys = Keys.Control | Keys.A;
            miGoTo.ShortcutKeys = Keys.Control | Keys.G;
            miPreview.ShortcutKeys = Keys.F5;
            miParams.ShortcutKeys = Keys.Control | Keys.P;
            miAbout.ShortcutKeys = Keys.F1;
            miExit.ShortcutKeyDisplayString = "Alt+F4";
            miClear.ShortcutKeyDisplayString = "Del";

            // подписка событий
            miNew.Click += miNew_Click;
            miOpen.Click += miOpen_Click;
            miSave.Click += miSave_Click;
            miExit.Click += miExit_Click;
            miFind.Click += miFind_Click;
            miClear.Click += miClear_Click;
            miSelectAll.Click += miSelectAll_Click;
            miGoTo.Click += miGoTo_Click;
            miPreview.Click += miPreview_Click;
            miParams.Click += miParams_Click;
            miStats.Click += miStats_Click;
            miAbout.Click += miAbout_Click;

            btnFindNext.Click += btnFindNext_Click;
            btnCloseFind.Click += btnCloseFind_Click;
            txtFind.KeyPress += txtFind_KeyPress;
            FormClosing += frmMain_FormClosing;

            // начальное состояние
            dlgOpen.Filter = dlgSave.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            pnlFind.Visible = false;
            UpdateStatus();
            UpdateTitle();
            Shown += (s, e) => { changed = false; UpdateTitle(); };
        }

        // ---------- служебные методы ----------
        private void UpdateTitle() => Text = "Блокнот" + (changed ? "*" : "");

        private void UpdateStatus()
        {
            string t = txtEdit.Text;
            int words = t.Split(new[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries).Length;
            lblChars.Text = "Символов: " + t.Length;
            lblWords.Visible = showWords;
            lblWords.Text = "Слов: " + words;
            lblFile.Text = "Файл: " + (fileName == "" ? "имя_файла.txt" : Path.GetFileName(fileName));
        }

        private void UpdatePreview()
        {
            var sb = new StringBuilder();
            string[] lines = txtEdit.Text.Replace("\r\n", "\n").Split('\n');
            for (int i = 0; i < lines.Length; i++)
            {
                if (showLineNumbers) sb.Append((i + 1) + ": ");
                sb.Append("    " + lines[i]);                 // отступ первой строки
                if (i < lines.Length - 1) sb.Append("\r\n");
            }
            txtPreview.Text = sb.ToString();
            txtPreview.TextAlign = HorizontalAlignment.Left;  // по левому краю
        }

        private bool ConfirmDiscard()
        {
            if (!changed) return true;
            return MessageBox.Show("Есть несохранённые изменения. Продолжить?", "Блокнот",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }

        private bool SaveFile()
        {
            if (dlgSave.ShowDialog() != DialogResult.OK) return false;
            File.WriteAllText(dlgSave.FileName, txtEdit.Text, Encoding.UTF8);
            fileName = dlgSave.FileName;
            changed = false;
            UpdateTitle();
            UpdateStatus();
            return true;
        }

        // ---------- изменение текста ----------
        private void txtEdit_TextChanged(object sender, EventArgs e)
        {
            if (!loading) { changed = true; UpdateTitle(); }
            UpdateStatus();
        }

        // ---------- Файл ----------
        private void miNew_Click(object sender, EventArgs e)
        {
            if (!ConfirmDiscard()) return;
            loading = true;
            txtEdit.Clear();
            loading = false;
            fileName = "";
            changed = false;
            UpdateTitle();
            UpdateStatus();
        }

        private void miOpen_Click(object sender, EventArgs e)
        {
            if (!ConfirmDiscard()) return;
            if (dlgOpen.ShowDialog() != DialogResult.OK) return;
            loading = true;
            txtEdit.Text = File.ReadAllText(dlgOpen.FileName, Encoding.UTF8);
            loading = false;
            fileName = dlgOpen.FileName;
            changed = false;
            findPos = 0;
            UpdateTitle();
            UpdateStatus();
        }

        private void miSave_Click(object sender, EventArgs e) => SaveFile();

        private void miExit_Click(object sender, EventArgs e) => Close();

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!changed) return;
            DialogResult r = MessageBox.Show("Сохранить изменения перед выходом?", "Блокнот",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (r == DialogResult.Yes) { if (!SaveFile()) e.Cancel = true; }
            else if (r == DialogResult.Cancel) e.Cancel = true;
        }

        // ---------- Правка ----------
        private void miFind_Click(object sender, EventArgs e)
        {
            pnlFind.Visible = true;
            txtFind.Focus();
            txtFind.SelectAll();
        }

        private void txtFind_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)27) { pnlFind.Visible = false; e.Handled = true; }
        }

        private void btnFindNext_Click(object sender, EventArgs e)
        {
            string text = txtEdit.Text, frag = txtFind.Text;
            if (frag == "" || text == "") { MessageBox.Show("Нечего искать"); return; }
            if (findPos > text.Length) findPos = 0;
            int pos = text.IndexOf(frag, findPos, StringComparison.CurrentCultureIgnoreCase);
            if (pos < 0) pos = text.IndexOf(frag, 0, StringComparison.CurrentCultureIgnoreCase);
            if (pos < 0) { MessageBox.Show("Вхождений нет"); return; }
            tabMain.SelectedTab = tabpEdit;
            txtEdit.Focus();
            txtEdit.SelectionStart = pos;
            txtEdit.SelectionLength = frag.Length;
            findPos = pos + 1;
            txtEdit.ScrollToCaret();
        }

        private void btnCloseFind_Click(object sender, EventArgs e) => pnlFind.Visible = false;

        private void miClear_Click(object sender, EventArgs e)
        {
            if (txtEdit.Text == "") return;
            if (MessageBox.Show("Очистить текст?", "Блокнот", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
                txtEdit.Clear();
        }

        private void miSelectAll_Click(object sender, EventArgs e)
        {
            txtEdit.Focus();
            txtEdit.SelectAll();
        }

        private void miGoTo_Click(object sender, EventArgs e)
        {
            string[] lines = txtEdit.Text.Replace("\r\n", "\n").Split('\n');
            using (var f = new frmGoTo(lines.Length))
            {
                if (f.ShowDialog() != DialogResult.OK) return;
                int pos = 0;
                for (int i = 0; i < f.LineNumber - 1; i++) pos += lines[i].Length + 2; // +2 = \r\n
                tabMain.SelectedTab = tabpEdit;
                txtEdit.SelectionStart = Math.Min(pos, txtEdit.Text.Length);
                txtEdit.SelectionLength = 0;
                txtEdit.ScrollToCaret();
                if (f.ToEditor) txtEdit.Focus();
            }
        }

        // ---------- Вид ----------
        private void miPreview_Click(object sender, EventArgs e)
        {
            UpdatePreview();
            tabMain.SelectedTab = tabpPreview;
        }

        private void miParams_Click(object sender, EventArgs e)
        {
            using (var f = new frmParams(txtEdit.WordWrap, showLineNumbers, showWords))
            {
                if (f.ShowDialog() == DialogResult.OK)
                {
                    txtEdit.WordWrap = f.WordWrap;
                    txtPreview.WordWrap = f.WordWrap;
                    showLineNumbers = f.ShowLineNumbers;
                    showWords = f.ShowWords;
                    UpdateStatus();
                    UpdatePreview();
                }
            }
        }

        private void miStats_Click(object sender, EventArgs e)
        {
            using (var f = new frmStats(txtEdit.Text)) f.ShowDialog();
        }

        // ---------- Справка ----------
        private void miAbout_Click(object sender, EventArgs e)
        {
            if (about == null || about.IsDisposed) about = new frmAbout();
            about.Show(this);
        }

        // ---------- Контекстное меню ----------
        private void ctxCut_Click(object sender, EventArgs e) => txtEdit.Cut();

        private void ctxCopy_Click(object sender, EventArgs e)
        {
            if (tabMain.SelectedTab == tabpPreview) txtPreview.Copy(); else txtEdit.Copy();
        }

        private void ctxPaste_Click(object sender, EventArgs e) => txtEdit.Paste();
    }
}