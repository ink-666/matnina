using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace MovieBase
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
            miSepFile = new ToolStripSeparator();
            miExit = new ToolStripMenuItem();
            miCatalog = new ToolStripMenuItem();
            miAdd = new ToolStripMenuItem();
            miDelete = new ToolStripMenuItem();
            miEdit = new ToolStripMenuItem();
            miToggle = new ToolStripMenuItem();
            miSepCatalog = new ToolStripSeparator();
            miDemo = new ToolStripMenuItem();
            miReports = new ToolStripMenuItem();
            miTop = new ToolStripMenuItem();
            miHelp = new ToolStripMenuItem();
            miAbout = new ToolStripMenuItem();
            tlsMain = new ToolStrip();
            btnTNew = new ToolStripButton();
            btnTOpen = new ToolStripButton();
            btnTSave = new ToolStripButton();
            sepT1 = new ToolStripSeparator();
            btnTAdd = new ToolStripButton();
            btnTDelete = new ToolStripButton();
            btnTEdit = new ToolStripButton();
            sepT2 = new ToolStripSeparator();
            btnTTop = new ToolStripButton();
            stsMain = new StatusStrip();
            sslCount = new ToolStripStatusLabel();
            sslRating = new ToolStripStatusLabel();
            sslInfo = new ToolStripStatusLabel();
            dgvMovies = new DataGridView();
            colTitle = new DataGridViewTextBoxColumn();
            colYear = new DataGridViewTextBoxColumn();
            colGenre = new DataGridViewTextBoxColumn();
            colCountry = new DataGridViewTextBoxColumn();
            colDirector = new DataGridViewTextBoxColumn();
            colMark = new DataGridViewTextBoxColumn();
            colWatched = new DataGridViewCheckBoxColumn();
            ctxGrid = new ContextMenuStrip(components);
            ctxAdd = new ToolStripMenuItem();
            ctxEdit = new ToolStripMenuItem();
            ctxDelete = new ToolStripMenuItem();
            ctxToggle = new ToolStripMenuItem();
            dlgOpen = new OpenFileDialog();
            dlgSave = new SaveFileDialog();
            menuMain.SuspendLayout();
            tlsMain.SuspendLayout();
            stsMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMovies).BeginInit();
            ctxGrid.SuspendLayout();
            SuspendLayout();
            // 
            // menuMain
            // 
            menuMain.ImageScalingSize = new Size(32, 32);
            menuMain.Items.AddRange(new ToolStripItem[] { miFile, miCatalog, miReports, miHelp });
            menuMain.Location = new Point(0, 0);
            menuMain.Name = "menuMain";
            menuMain.Padding = new Padding(11, 4, 0, 4);
            menuMain.Size = new Size(1634, 44);
            menuMain.TabIndex = 0;
            // 
            // miFile
            // 
            miFile.DropDownItems.AddRange(new ToolStripItem[] { miNew, miOpen, miSave, miSepFile, miExit });
            miFile.Name = "miFile";
            miFile.Size = new Size(90, 36);
            miFile.Text = "Файл";
            // 
            // miNew
            // 
            miNew.Name = "miNew";
            miNew.Size = new Size(359, 44);
            miNew.Text = "Новый";
            miNew.Click += miNew_Click;
            // 
            // miOpen
            // 
            miOpen.Name = "miOpen";
            miOpen.Size = new Size(359, 44);
            miOpen.Text = "Открыть…";
            miOpen.Click += miOpen_Click;
            // 
            // miSave
            // 
            miSave.Name = "miSave";
            miSave.Size = new Size(359, 44);
            miSave.Text = "Сохранить…";
            miSave.Click += miSave_Click;
            // 
            // miSepFile
            // 
            miSepFile.Name = "miSepFile";
            miSepFile.Size = new Size(356, 6);
            // 
            // miExit
            // 
            miExit.Name = "miExit";
            miExit.Size = new Size(359, 44);
            miExit.Text = "Выход";
            miExit.Click += miExit_Click;
            // 
            // miCatalog
            // 
            miCatalog.DropDownItems.AddRange(new ToolStripItem[] { miAdd, miDelete, miEdit, miToggle, miSepCatalog, miDemo });
            miCatalog.Name = "miCatalog";
            miCatalog.Size = new Size(118, 36);
            miCatalog.Text = "Каталог";
            // 
            // miAdd
            // 
            miAdd.Name = "miAdd";
            miAdd.Size = new Size(459, 44);
            miAdd.Text = "Добавить";
            miAdd.Click += miAdd_Click;
            // 
            // miDelete
            // 
            miDelete.Name = "miDelete";
            miDelete.Size = new Size(459, 44);
            miDelete.Text = "Удалить";
            miDelete.Click += miDelete_Click;
            // 
            // miEdit
            // 
            miEdit.Name = "miEdit";
            miEdit.Size = new Size(459, 44);
            miEdit.Text = "Редактировать";
            miEdit.Click += miEdit_Click;
            // 
            // miToggle
            // 
            miToggle.Name = "miToggle";
            miToggle.Size = new Size(459, 44);
            miToggle.Text = "Переключить \"просмотрен\"";
            miToggle.Click += miToggle_Click;
            // 
            // miSepCatalog
            // 
            miSepCatalog.Name = "miSepCatalog";
            miSepCatalog.Size = new Size(456, 6);
            // 
            // miDemo
            // 
            miDemo.Name = "miDemo";
            miDemo.Size = new Size(459, 44);
            miDemo.Text = "Загрузить демо-данные";
            miDemo.Click += miDemo_Click;
            // 
            // miReports
            // 
            miReports.DropDownItems.AddRange(new ToolStripItem[] { miTop });
            miReports.Name = "miReports";
            miReports.Size = new Size(116, 36);
            miReports.Text = "Отчёты";
            // 
            // miTop
            // 
            miTop.Name = "miTop";
            miTop.Size = new Size(246, 44);
            miTop.Text = "Топ-лист";
            miTop.Click += miTop_Click;
            // 
            // miHelp
            // 
            miHelp.DropDownItems.AddRange(new ToolStripItem[] { miAbout });
            miHelp.Name = "miHelp";
            miHelp.Size = new Size(126, 36);
            miHelp.Text = "Справка";
            // 
            // miAbout
            // 
            miAbout.Name = "miAbout";
            miAbout.Size = new Size(359, 44);
            miAbout.Text = "О программе…";
            miAbout.Click += miAbout_Click;
            // 
            // tlsMain
            // 
            tlsMain.ImageScalingSize = new Size(32, 32);
            tlsMain.Items.AddRange(new ToolStripItem[] { btnTNew, btnTOpen, btnTSave, sepT1, btnTAdd, btnTDelete, btnTEdit, sepT2, btnTTop });
            tlsMain.Location = new Point(0, 44);
            tlsMain.Name = "tlsMain";
            tlsMain.Padding = new Padding(0, 0, 4, 0);
            tlsMain.Size = new Size(1634, 42);
            tlsMain.TabIndex = 1;
            // 
            // btnTNew
            // 
            btnTNew.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btnTNew.Name = "btnTNew";
            btnTNew.Size = new Size(93, 36);
            btnTNew.Text = "Новый";
            btnTNew.ToolTipText = "Новая коллекция (Ctrl+N)";
            btnTNew.Click += miNew_Click;
            // 
            // btnTOpen
            // 
            btnTOpen.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btnTOpen.Name = "btnTOpen";
            btnTOpen.Size = new Size(111, 36);
            btnTOpen.Text = "Открыть";
            btnTOpen.ToolTipText = "Открыть коллекцию (Ctrl+O)";
            btnTOpen.Click += miOpen_Click;
            // 
            // btnTSave
            // 
            btnTSave.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btnTSave.Name = "btnTSave";
            btnTSave.Size = new Size(134, 36);
            btnTSave.Text = "Сохранить";
            btnTSave.ToolTipText = "Сохранить коллекцию (Ctrl+S)";
            btnTSave.Click += miSave_Click;
            // 
            // sepT1
            // 
            sepT1.Name = "sepT1";
            sepT1.Size = new Size(6, 42);
            // 
            // btnTAdd
            // 
            btnTAdd.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btnTAdd.Name = "btnTAdd";
            btnTAdd.Size = new Size(124, 36);
            btnTAdd.Text = "Добавить";
            btnTAdd.ToolTipText = "Добавить фильм (Ins)";
            btnTAdd.Click += miAdd_Click;
            // 
            // btnTDelete
            // 
            btnTDelete.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btnTDelete.Name = "btnTDelete";
            btnTDelete.Size = new Size(106, 36);
            btnTDelete.Text = "Удалить";
            btnTDelete.ToolTipText = "Удалить фильм (Del)";
            btnTDelete.Click += miDelete_Click;
            // 
            // btnTEdit
            // 
            btnTEdit.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btnTEdit.Name = "btnTEdit";
            btnTEdit.Size = new Size(180, 36);
            btnTEdit.Text = "Редактировать";
            btnTEdit.ToolTipText = "Редактировать фильм (F4)";
            btnTEdit.Click += miEdit_Click;
            // 
            // sepT2
            // 
            sepT2.Name = "sepT2";
            sepT2.Size = new Size(6, 42);
            // 
            // btnTTop
            // 
            btnTTop.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btnTTop.Name = "btnTTop";
            btnTTop.Size = new Size(117, 36);
            btnTTop.Text = "Топ-лист";
            btnTTop.ToolTipText = "Топ-лист (F9)";
            btnTTop.Click += miTop_Click;
            // 
            // stsMain
            // 
            stsMain.ImageScalingSize = new Size(32, 32);
            stsMain.Items.AddRange(new ToolStripItem[] { sslCount, sslRating, sslInfo });
            stsMain.Location = new Point(0, 1025);
            stsMain.Name = "stsMain";
            stsMain.Padding = new Padding(2, 0, 26, 0);
            stsMain.Size = new Size(1634, 42);
            stsMain.TabIndex = 2;
            // 
            // sslCount
            // 
            sslCount.Name = "sslCount";
            sslCount.Size = new Size(139, 32);
            sslCount.Text = "Фильмов: 0";
            // 
            // sslRating
            // 
            sslRating.Name = "sslRating";
            sslRating.Size = new Size(229, 32);
            sslRating.Text = "Средняя оценка: —";
            // 
            // sslInfo
            // 
            sslInfo.Name = "sslInfo";
            sslInfo.Size = new Size(1238, 32);
            sslInfo.Spring = true;
            sslInfo.Text = "Ничего не выбрано";
            sslInfo.TextAlign = ContentAlignment.MiddleRight;
            // 
            // dgvMovies
            // 
            dgvMovies.AllowUserToAddRows = false;
            dgvMovies.AllowUserToDeleteRows = false;
            dgvMovies.AllowUserToResizeRows = false;
            dgvMovies.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMovies.BackgroundColor = SystemColors.Window;
            dgvMovies.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMovies.Columns.AddRange(new DataGridViewColumn[] { colTitle, colYear, colGenre, colCountry, colDirector, colMark, colWatched });
            dgvMovies.ContextMenuStrip = ctxGrid;
            dgvMovies.Dock = DockStyle.Fill;
            dgvMovies.Location = new Point(0, 86);
            dgvMovies.Margin = new Padding(6, 6, 6, 6);
            dgvMovies.MultiSelect = false;
            dgvMovies.Name = "dgvMovies";
            dgvMovies.RowHeadersVisible = false;
            dgvMovies.RowHeadersWidth = 82;
            dgvMovies.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMovies.Size = new Size(1634, 939);
            dgvMovies.TabIndex = 3;
            dgvMovies.CellContentClick += dgvMovies_CellContentClick;
            dgvMovies.CellDoubleClick += dgvMovies_CellDoubleClick;
            dgvMovies.CellEndEdit += dgvMovies_CellEndEdit;
            dgvMovies.CellValidating += dgvMovies_CellValidating;
            dgvMovies.SelectionChanged += dgvMovies_SelectionChanged;
            dgvMovies.KeyDown += dgvMovies_KeyDown;
            // 
            // colTitle
            // 
            colTitle.FillWeight = 220F;
            colTitle.HeaderText = "Название";
            colTitle.MinimumWidth = 80;
            colTitle.Name = "colTitle";
            // 
            // colYear
            // 
            colYear.FillWeight = 45F;
            colYear.HeaderText = "Год";
            colYear.MinimumWidth = 45;
            colYear.Name = "colYear";
            // 
            // colGenre
            // 
            colGenre.FillWeight = 90F;
            colGenre.HeaderText = "Жанр";
            colGenre.MinimumWidth = 60;
            colGenre.Name = "colGenre";
            // 
            // colCountry
            // 
            colCountry.FillWeight = 90F;
            colCountry.HeaderText = "Страна";
            colCountry.MinimumWidth = 60;
            colCountry.Name = "colCountry";
            // 
            // colDirector
            // 
            colDirector.FillWeight = 110F;
            colDirector.HeaderText = "Режиссёр";
            colDirector.MinimumWidth = 70;
            colDirector.Name = "colDirector";
            // 
            // colMark
            // 
            colMark.FillWeight = 50F;
            colMark.HeaderText = "Оценка";
            colMark.MinimumWidth = 50;
            colMark.Name = "colMark";
            // 
            // colWatched
            // 
            colWatched.FillWeight = 70F;
            colWatched.HeaderText = "Просмотрен";
            colWatched.MinimumWidth = 70;
            colWatched.Name = "colWatched";
            // 
            // ctxGrid
            // 
            ctxGrid.ImageScalingSize = new Size(32, 32);
            ctxGrid.Items.AddRange(new ToolStripItem[] { ctxAdd, ctxEdit, ctxDelete, ctxToggle });
            ctxGrid.Name = "ctxGrid";
            ctxGrid.Size = new Size(401, 156);
            // 
            // ctxAdd
            // 
            ctxAdd.Name = "ctxAdd";
            ctxAdd.Size = new Size(400, 38);
            ctxAdd.Text = "Добавить";
            ctxAdd.Click += miAdd_Click;
            // 
            // ctxEdit
            // 
            ctxEdit.Name = "ctxEdit";
            ctxEdit.Size = new Size(400, 38);
            ctxEdit.Text = "Редактировать";
            ctxEdit.Click += miEdit_Click;
            // 
            // ctxDelete
            // 
            ctxDelete.Name = "ctxDelete";
            ctxDelete.Size = new Size(400, 38);
            ctxDelete.Text = "Удалить";
            ctxDelete.Click += miDelete_Click;
            // 
            // ctxToggle
            // 
            ctxToggle.Name = "ctxToggle";
            ctxToggle.Size = new Size(400, 38);
            ctxToggle.Text = "Переключить \"просмотрен\"";
            ctxToggle.Click += miToggle_Click;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1634, 1067);
            Controls.Add(dgvMovies);
            Controls.Add(tlsMain);
            Controls.Add(stsMain);
            Controls.Add(menuMain);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MainMenuStrip = menuMain;
            Margin = new Padding(6, 6, 6, 6);
            MaximizeBox = false;
            Name = "frmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Кинобаза";
            menuMain.ResumeLayout(false);
            menuMain.PerformLayout();
            tlsMain.ResumeLayout(false);
            tlsMain.PerformLayout();
            stsMain.ResumeLayout(false);
            stsMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMovies).EndInit();
            ctxGrid.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuMain;
        private ToolStripMenuItem miFile, miNew, miOpen, miSave, miExit;
        private ToolStripSeparator miSepFile, miSepCatalog;
        private ToolStripMenuItem miCatalog, miAdd, miDelete, miEdit, miToggle, miDemo;
        private ToolStripMenuItem miReports, miTop;
        private ToolStripMenuItem miHelp, miAbout;
        private ToolStrip tlsMain;
        private ToolStripButton btnTNew, btnTOpen, btnTSave, btnTAdd, btnTDelete, btnTEdit, btnTTop;
        private ToolStripSeparator sepT1, sepT2;
        private StatusStrip stsMain;
        private ToolStripStatusLabel sslCount, sslRating, sslInfo;
        private DataGridView dgvMovies;
        private DataGridViewTextBoxColumn colTitle, colYear, colGenre, colCountry, colDirector, colMark;
        private DataGridViewCheckBoxColumn colWatched;
        private ContextMenuStrip ctxGrid;
        private ToolStripMenuItem ctxAdd, ctxEdit, ctxDelete, ctxToggle;
        private OpenFileDialog dlgOpen;
        private SaveFileDialog dlgSave;
    }
}