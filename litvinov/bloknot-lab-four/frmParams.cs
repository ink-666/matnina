using System;
using System.Drawing;
using System.Windows.Forms;

namespace lab_3_bloknot
{
    // Форма «Параметры» — интерфейс создаётся кодом; размер окна подстраивается под текст
    public class frmParams : Form
    {
        private GroupBox grpView, grpStat;
        private CheckBox chkWrap, chkLineNumbers, chkWords;
        private Button btnOk, btnCancel;

        // Свойства для обмена данными с главной формой
        public bool WordWrap => chkWrap.Checked;
        public bool ShowLineNumbers => chkLineNumbers.Checked;
        public bool ShowWords => chkWords.Checked;

        public frmParams(bool wordWrap, bool showLineNumbers, bool showWords)
        {
            BuildUi();
            chkWrap.Checked = wordWrap;
            chkLineNumbers.Checked = showLineNumbers;
            chkWords.Checked = showWords;
        }

        private static FlowLayoutPanel NewColumn()
        {
            return new FlowLayoutPanel
            {
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink
            };
        }

        private void BuildUi()
        {
            Text = "Параметры";
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterParent;
            MaximizeBox = false;
            MinimizeBox = false;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            Padding = new Padding(12);

            chkWrap = new CheckBox { Text = "Переносить по словам", AutoSize = true, Margin = new Padding(3, 4, 3, 4) };
            chkLineNumbers = new CheckBox { Text = "Показывать номера строк", AutoSize = true, Margin = new Padding(3, 4, 3, 4) };
            chkWords = new CheckBox { Text = "Показывать количество слов", AutoSize = true, Margin = new Padding(3, 4, 3, 4) };

            var colView = NewColumn();
            colView.Controls.Add(chkWrap);
            colView.Controls.Add(chkLineNumbers);
            grpView = new GroupBox
            {
                Text = "Вид текста",
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                Padding = new Padding(8, 4, 8, 8),
                Dock = DockStyle.Fill
            };
            grpView.Controls.Add(colView);

            var colStat = NewColumn();
            colStat.Controls.Add(chkWords);
            grpStat = new GroupBox
            {
                Text = "Статистика",
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                Padding = new Padding(8, 4, 8, 8),
                Dock = DockStyle.Fill
            };
            grpStat.Controls.Add(colStat);

            btnOk = new Button
            {
                Text = "OK",
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                Padding = new Padding(0, 6, 0, 6),
                Dock = DockStyle.Fill,
                DialogResult = DialogResult.OK
            };
            btnCancel = new Button
            {
                Text = "Отмена",
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                Padding = new Padding(0, 6, 0, 6),
                Dock = DockStyle.Fill,
                DialogResult = DialogResult.Cancel
            };

            var buttons = new TableLayoutPanel
            {
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                ColumnCount = 2,
                RowCount = 1,
                Dock = DockStyle.Fill,
                Margin = new Padding(0, 8, 0, 0)
            };
            buttons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            buttons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            buttons.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            buttons.Controls.Add(btnOk, 0, 0);
            buttons.Controls.Add(btnCancel, 1, 0);

            var main = new TableLayoutPanel
            {
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                ColumnCount = 1,
                RowCount = 3
            };
            main.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            main.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            main.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            main.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            main.Controls.Add(grpView, 0, 0);
            main.Controls.Add(grpStat, 0, 1);
            main.Controls.Add(buttons, 0, 2);

            Controls.Add(main);
            AcceptButton = btnOk;
            CancelButton = btnCancel;
        }
    }
}