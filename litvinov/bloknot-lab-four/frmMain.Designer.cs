namespace lab_3_bloknot
{
    partial class frmMain
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            menuMain = new MenuStrip();
            miFile = new ToolStripMenuItem();
            miNew = new ToolStripMenuItem();
            miOpen = new ToolStripMenuItem();
            miSave = new ToolStripMenuItem();
            miSep1 = new ToolStripSeparator();
            miExit = new ToolStripMenuItem();
            miEdit = new ToolStripMenuItem();
            miFind = new ToolStripMenuItem();
            miClear = new ToolStripMenuItem();
            miSelectAll = new ToolStripMenuItem();
            miGoTo = new ToolStripMenuItem();
            miView = new ToolStripMenuItem();
            miPreview = new ToolStripMenuItem();
            miParams = new ToolStripMenuItem();
            miStats = new ToolStripMenuItem();
            miHelp = new ToolStripMenuItem();
            miAbout = new ToolStripMenuItem();
            toolMain = new ToolStrip();
            tbNew = new ToolStripButton();
            tbOpen = new ToolStripButton();
            tbSave = new ToolStripButton();
            tbFind = new ToolStripButton();
            statMain = new StatusStrip();
            lblChars = new ToolStripStatusLabel();
            lblWords = new ToolStripStatusLabel();
            lblFile = new ToolStripStatusLabel();
            pnlFind = new Panel();
            lblFind = new Label();
            txtFind = new TextBox();
            btnFindNext = new Button();
            btnCloseFind = new Button();
            tabMain = new TabControl();
            tabpEdit = new TabPage();
            txtEdit = new TextBox();
            tabpPreview = new TabPage();
            txtPreview = new TextBox();
            dlgOpen = new OpenFileDialog();
            dlgSave = new SaveFileDialog();
            ctxEdit = new ContextMenuStrip(components);
            ctxCut = new ToolStripMenuItem();
            ctxCopy = new ToolStripMenuItem();
            ctxPaste = new ToolStripMenuItem();
            ctxSelectAll = new ToolStripMenuItem();
            menuMain.SuspendLayout();
            toolMain.SuspendLayout();
            statMain.SuspendLayout();
            pnlFind.SuspendLayout();
            tabMain.SuspendLayout();
            tabpEdit.SuspendLayout();
            tabpPreview.SuspendLayout();
            ctxEdit.SuspendLayout();
            SuspendLayout();
            // 
            // menuMain
            // 
            menuMain.Items.AddRange(new ToolStripItem[] { miFile, miEdit, miView, miHelp });
            menuMain.Location = new Point(0, 0);
            menuMain.Name = "menuMain";
            menuMain.Size = new Size(760, 24);
            menuMain.TabIndex = 0;
            // 
            // miFile
            // 
            miFile.DropDownItems.AddRange(new ToolStripItem[] { miNew, miOpen, miSave, miSep1, miExit });
            miFile.Name = "miFile";
            miFile.Text = "Файл";
            // 
            // miNew / miOpen / miSave / miExit
            // 
            miNew.Name = "miNew";
            miNew.Text = "Новый";
            miOpen.Name = "miOpen";
            miOpen.Text = "Открыть…";
            miSave.Name = "miSave";
            miSave.Text = "Сохранить…";
            miSep1.Name = "miSep1";
            miExit.Name = "miExit";
            miExit.Text = "Выход";
            // 
            // miEdit
            // 
            miEdit.DropDownItems.AddRange(new ToolStripItem[] { miFind, miClear, miSelectAll, miGoTo });
            miEdit.Name = "miEdit";
            miEdit.Text = "Правка";
            miFind.Name = "miFind";
            miFind.Text = "Найти…";
            miClear.Name = "miClear";
            miClear.Text = "Очистить";
            miSelectAll.Name = "miSelectAll";
            miSelectAll.Text = "Выделить всё";
            miGoTo.Name = "miGoTo";
            miGoTo.Text = "Перейти к строке…";
            // 
            // miView
            // 
            miView.DropDownItems.AddRange(new ToolStripItem[] { miPreview, miParams, miStats });
            miView.Name = "miView";
            miView.Text = "Вид";
            miPreview.Name = "miPreview";
            miPreview.Text = "Предпросмотр";
            miParams.Name = "miParams";
            miParams.Text = "Параметры…";
            miStats.Name = "miStats";
            miStats.Text = "Статистика…";
            // 
            // miHelp
            // 
            miHelp.DropDownItems.AddRange(new ToolStripItem[] { miAbout });
            miHelp.Name = "miHelp";
            miHelp.Text = "Справка";
            miAbout.Name = "miAbout";
            miAbout.Text = "О программе…";
            // 
            // toolMain
            // 
            toolMain.Items.AddRange(new ToolStripItem[] { tbNew, tbOpen, tbSave, tbFind });
            toolMain.Location = new Point(0, 24);
            toolMain.Name = "toolMain";
            toolMain.Size = new Size(760, 25);
            toolMain.TabIndex = 1;
            tbNew.DisplayStyle = ToolStripItemDisplayStyle.Text;
            tbNew.Name = "tbNew";
            tbNew.Text = "Новый";
            tbNew.Click += miNew_Click;
            tbOpen.DisplayStyle = ToolStripItemDisplayStyle.Text;
            tbOpen.Name = "tbOpen";
            tbOpen.Text = "Открыть";
            tbOpen.Click += miOpen_Click;
            tbSave.DisplayStyle = ToolStripItemDisplayStyle.Text;
            tbSave.Name = "tbSave";
            tbSave.Text = "Сохранить";
            tbSave.Click += miSave_Click;
            tbFind.DisplayStyle = ToolStripItemDisplayStyle.Text;
            tbFind.Name = "tbFind";
            tbFind.Text = "Найти";
            tbFind.Click += miFind_Click;
            // 
            // statMain
            // 
            statMain.Items.AddRange(new ToolStripItem[] { lblChars, lblWords, lblFile });
            statMain.Location = new Point(0, 498);
            statMain.Name = "statMain";
            statMain.Size = new Size(760, 22);
            statMain.TabIndex = 2;
            lblChars.Name = "lblChars";
            lblChars.Text = "Символов: 0";
            lblWords.Name = "lblWords";
            lblWords.Text = "Слов: 0";
            lblFile.Name = "lblFile";
            lblFile.Text = "Файл: имя_файла.txt";
            // 
            // pnlFind
            // 
            pnlFind.Controls.Add(lblFind);
            pnlFind.Controls.Add(txtFind);
            pnlFind.Controls.Add(btnFindNext);
            pnlFind.Controls.Add(btnCloseFind);
            pnlFind.Dock = DockStyle.Top;
            pnlFind.Location = new Point(0, 49);
            pnlFind.Name = "pnlFind";
            pnlFind.Size = new Size(760, 40);
            pnlFind.TabIndex = 3;
            lblFind.AutoSize = true;
            lblFind.Location = new Point(10, 12);
            lblFind.Name = "lblFind";
            lblFind.Text = "Поиск:";
            txtFind.Location = new Point(70, 8);
            txtFind.Name = "txtFind";
            txtFind.Size = new Size(250, 23);
            txtFind.TabIndex = 0;
            btnFindNext.Location = new Point(330, 6);
            btnFindNext.Name = "btnFindNext";
            btnFindNext.Size = new Size(110, 28);
            btnFindNext.TabIndex = 1;
            btnFindNext.Text = "Найти далее";
            btnCloseFind.Location = new Point(450, 6);
            btnCloseFind.Name = "btnCloseFind";
            btnCloseFind.Size = new Size(90, 28);
            btnCloseFind.TabIndex = 2;
            btnCloseFind.Text = "Закрыть";
            // 
            // tabMain
            // 
            tabMain.Controls.Add(tabpEdit);
            tabMain.Controls.Add(tabpPreview);
            tabMain.Dock = DockStyle.Fill;
            tabMain.Name = "tabMain";
            tabMain.SelectedIndex = 0;
            tabMain.TabIndex = 4;
            // 
            // tabpEdit
            // 
            tabpEdit.Controls.Add(txtEdit);
            tabpEdit.Name = "tabpEdit";
            tabpEdit.Padding = new Padding(3);
            tabpEdit.TabIndex = 0;
            tabpEdit.Text = "Редактор";
            tabpEdit.UseVisualStyleBackColor = true;
            // 
            // txtEdit
            // 
            txtEdit.ContextMenuStrip = ctxEdit;
            txtEdit.Dock = DockStyle.Fill;
            txtEdit.Font = new Font("Segoe UI", 12F);
            txtEdit.Multiline = true;
            txtEdit.Name = "txtEdit";
            txtEdit.ScrollBars = ScrollBars.Vertical;
            txtEdit.TabIndex = 0;
            txtEdit.TextChanged += txtEdit_TextChanged;
            // 
            // tabpPreview
            // 
            tabpPreview.Controls.Add(txtPreview);
            tabpPreview.Name = "tabpPreview";
            tabpPreview.Padding = new Padding(3);
            tabpPreview.TabIndex = 1;
            tabpPreview.Text = "Предпросмотр";
            tabpPreview.UseVisualStyleBackColor = true;
            // 
            // txtPreview
            // 
            txtPreview.ContextMenuStrip = ctxEdit;
            txtPreview.Dock = DockStyle.Fill;
            txtPreview.Font = new Font("Segoe UI", 12F);
            txtPreview.Multiline = true;
            txtPreview.Name = "txtPreview";
            txtPreview.ReadOnly = true;
            txtPreview.ScrollBars = ScrollBars.Vertical;
            txtPreview.TabIndex = 0;
            // 
            // ctxEdit
            // 
            ctxEdit.Items.AddRange(new ToolStripItem[] { ctxCut, ctxCopy, ctxPaste, ctxSelectAll });
            ctxEdit.Name = "ctxEdit";
            ctxCut.Name = "ctxCut";
            ctxCut.Text = "Вырезать";
            ctxCut.Click += ctxCut_Click;
            ctxCopy.Name = "ctxCopy";
            ctxCopy.Text = "Копировать";
            ctxCopy.Click += ctxCopy_Click;
            ctxPaste.Name = "ctxPaste";
            ctxPaste.Text = "Вставить";
            ctxPaste.Click += ctxPaste_Click;
            ctxSelectAll.Name = "ctxSelectAll";
            ctxSelectAll.Text = "Выделить всё";
            ctxSelectAll.Click += miSelectAll_Click;
            // 
            // dlgOpen / dlgSave
            // 
            dlgOpen.FileName = "";
            dlgSave.FileName = "";
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(760, 520);
            Controls.Add(tabMain);
            Controls.Add(pnlFind);
            Controls.Add(toolMain);
            Controls.Add(statMain);
            Controls.Add(menuMain);
            MainMenuStrip = menuMain;
            Name = "frmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Блокнот";
            menuMain.ResumeLayout(false);
            menuMain.PerformLayout();
            toolMain.ResumeLayout(false);
            toolMain.PerformLayout();
            statMain.ResumeLayout(false);
            statMain.PerformLayout();
            pnlFind.ResumeLayout(false);
            pnlFind.PerformLayout();
            tabMain.ResumeLayout(false);
            tabpEdit.ResumeLayout(false);
            tabpEdit.PerformLayout();
            tabpPreview.ResumeLayout(false);
            tabpPreview.PerformLayout();
            ctxEdit.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuMain;
        private ToolStripMenuItem miFile, miNew, miOpen, miSave, miExit;
        private ToolStripSeparator miSep1;
        private ToolStripMenuItem miEdit, miFind, miClear, miSelectAll, miGoTo;
        private ToolStripMenuItem miView, miPreview, miParams, miStats;
        private ToolStripMenuItem miHelp, miAbout;
        private ToolStrip toolMain;
        private ToolStripButton tbNew, tbOpen, tbSave, tbFind;
        private StatusStrip statMain;
        private ToolStripStatusLabel lblChars, lblWords, lblFile;
        private Panel pnlFind;
        private Label lblFind;
        private TextBox txtFind;
        private Button btnFindNext, btnCloseFind;
        private TabControl tabMain;
        private TabPage tabpEdit, tabpPreview;
        private TextBox txtEdit, txtPreview;
        private OpenFileDialog dlgOpen;
        private SaveFileDialog dlgSave;
        private ContextMenuStrip ctxEdit;
        private ToolStripMenuItem ctxCut, ctxCopy, ctxPaste, ctxSelectAll;
    }
}