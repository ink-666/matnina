using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace WinFormsApp2
{
    partial class frmMain
    {
        /// <summary>
        /// Требуется конструктором форм — переменная для доп. компонентов.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освобождает ресурсы, занятые формой.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, созданный конструктором форм Windows Forms

        private Label lblDateCaption;
        private DateTimePicker dtpDate;
        private Label lblTitleCaption;
        private TextBox txtTitle;
        private Label lblNoteCaption;
        private TextBox txtNote;
        private Label lblStats;
        private Label lblCoords;
        private Label lblLogCaption;
        private ListBox lstLog;

        private GroupBox gbCommands;
        private Button btnNew;
        private Button btnOpen;
        private Button btnSave;
        private Button btnClear;
        private Button btnBkg;
        private Button btnColor;

        private OpenFileDialog dlgOpen;
        private SaveFileDialog dlgSave;
        private ColorDialog dlgColorText;
        private ColorDialog dlgColorBkg;

        /// <summary>
        /// Обязательный метод конструктора форм — не изменять вручную его содержимое.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            lblDateCaption = new Label();
            dtpDate = new DateTimePicker();
            lblTitleCaption = new Label();
            txtTitle = new TextBox();
            lblNoteCaption = new Label();
            txtNote = new TextBox();
            lblStats = new Label();
            lblCoords = new Label();
            lblLogCaption = new Label();
            lstLog = new ListBox();

            gbCommands = new GroupBox();
            btnNew = new Button();
            btnOpen = new Button();
            btnSave = new Button();
            btnClear = new Button();
            btnBkg = new Button();
            btnColor = new Button();

            dlgOpen = new OpenFileDialog();
            dlgSave = new SaveFileDialog();
            dlgColorText = new ColorDialog();
            dlgColorBkg = new ColorDialog();

            gbCommands.SuspendLayout();
            SuspendLayout();

            // ---------- Дата ----------
            lblDateCaption.AutoSize = true;
            lblDateCaption.Location = new Point(12, 15);
            lblDateCaption.Name = "lblDateCaption";
            lblDateCaption.Size = new Size(38, 15);
            lblDateCaption.Text = "Дата:";

            dtpDate.Location = new Point(64, 12);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(250, 23);
            dtpDate.Format = DateTimePickerFormat.Long;
            dtpDate.ValueChanged += dtpDate_ValueChanged;

            // ---------- Тема записи ----------
            lblTitleCaption.AutoSize = true;
            lblTitleCaption.Location = new Point(12, 48);
            lblTitleCaption.Name = "lblTitleCaption";
            lblTitleCaption.Size = new Size(83, 15);
            lblTitleCaption.Text = "Тема записи:";

            txtTitle.Location = new Point(12, 70);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(590, 23);
            txtTitle.KeyPress += txtTitle_KeyPress;

            // ---------- Текст записи ----------
            lblNoteCaption.AutoSize = true;
            lblNoteCaption.Location = new Point(12, 102);
            lblNoteCaption.Name = "lblNoteCaption";
            lblNoteCaption.Size = new Size(83, 15);
            lblNoteCaption.Text = "Текст записи:";

            txtNote.Location = new Point(12, 124);
            txtNote.Multiline = true;
            txtNote.ScrollBars = ScrollBars.Vertical;
            txtNote.Name = "txtNote";
            txtNote.Size = new Size(590, 160);
            txtNote.TextChanged += txtNote_TextChanged;

            // ---------- статистика и координаты ----------
            lblStats.AutoSize = true;
            lblStats.Location = new Point(12, 292);
            lblStats.Name = "lblStats";
            lblStats.Size = new Size(220, 15);
            lblStats.Text = "Символов: 0  Слов: 0  Строк: 0";

            lblCoords.AutoSize = true;
            lblCoords.Location = new Point(430, 292);
            lblCoords.Name = "lblCoords";
            lblCoords.Size = new Size(90, 15);
            lblCoords.Text = "X: 0   Y: 0";

            // ---------- журнал событий ----------
            lblLogCaption.AutoSize = true;
            lblLogCaption.Location = new Point(12, 320);
            lblLogCaption.Name = "lblLogCaption";
            lblLogCaption.Size = new Size(105, 15);
            lblLogCaption.Text = "Журнал событий:";

            lstLog.FormattingEnabled = true;
            lstLog.Location = new Point(12, 342);
            lstLog.Name = "lstLog";
            lstLog.Size = new Size(590, 130);

            // ---------- группа «Команды» ----------
            gbCommands.Location = new Point(12, 484);
            gbCommands.Name = "gbCommands";
            gbCommands.Size = new Size(590, 60);
            gbCommands.Text = "Команды";
            gbCommands.Controls.Add(btnNew);
            gbCommands.Controls.Add(btnOpen);
            gbCommands.Controls.Add(btnSave);
            gbCommands.Controls.Add(btnClear);
            gbCommands.Controls.Add(btnBkg);
            gbCommands.Controls.Add(btnColor);

            btnNew.Location = new Point(10, 20);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(85, 28);
            btnNew.Text = "Создать";
            btnNew.Click += Command_Click;
            btnNew.MouseEnter += Command_MouseEnter;
            btnNew.MouseLeave += Command_MouseLeave;

            btnOpen.Location = new Point(103, 20);
            btnOpen.Name = "btnOpen";
            btnOpen.Size = new Size(85, 28);
            btnOpen.Text = "Открыть";
            btnOpen.Click += Command_Click;
            btnOpen.MouseEnter += Command_MouseEnter;
            btnOpen.MouseLeave += Command_MouseLeave;

            btnSave.Location = new Point(196, 20);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(85, 28);
            btnSave.Text = "Сохранить";
            btnSave.Click += Command_Click;
            btnSave.MouseEnter += Command_MouseEnter;
            btnSave.MouseLeave += Command_MouseLeave;

            btnClear.Location = new Point(289, 20);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(85, 28);
            btnClear.Text = "Очистить";
            btnClear.Click += Command_Click;
            btnClear.MouseEnter += Command_MouseEnter;
            btnClear.MouseLeave += Command_MouseLeave;

            btnBkg.Location = new Point(382, 20);
            btnBkg.Name = "btnBkg";
            btnBkg.Size = new Size(95, 28);
            btnBkg.Text = "Цвет фона";
            btnBkg.Click += Command_Click;
            btnBkg.MouseEnter += Command_MouseEnter;
            btnBkg.MouseLeave += Command_MouseLeave;

            btnColor.Location = new Point(485, 20);
            btnColor.Name = "btnColor";
            btnColor.Size = new Size(95, 28);
            btnColor.Text = "Цвет текста";
            btnColor.Click += Command_Click;
            btnColor.MouseEnter += Command_MouseEnter;
            btnColor.MouseLeave += Command_MouseLeave;

            // ---------- диалоги (невизуальные компоненты) ----------
            dlgOpen.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            dlgSave.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            dlgColorBkg.FullOpen = true;

            // ---------- форма ----------
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(624, 560);
            Controls.Add(lblDateCaption);
            Controls.Add(dtpDate);
            Controls.Add(lblTitleCaption);
            Controls.Add(txtTitle);
            Controls.Add(lblNoteCaption);
            Controls.Add(txtNote);
            Controls.Add(lblStats);
            Controls.Add(lblCoords);
            Controls.Add(lblLogCaption);
            Controls.Add(lstLog);
            Controls.Add(gbCommands);
            Name = "frmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Дневник практики";
            KeyPreview = true;
            Load += frmMain_Load;
            MouseMove += frmMain_MouseMove;
            FormClosing += frmMain_FormClosing;

            gbCommands.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
    }
}