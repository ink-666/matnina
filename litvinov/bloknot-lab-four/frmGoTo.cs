using System;
using System.Drawing;
using System.Windows.Forms;

namespace lab_3_bloknot
{
    // Форма «Перейти к строке» — интерфейс создаётся кодом; размер окна подстраивается под текст
    public class frmGoTo : Form
    {
        private NumericUpDown numLine;
        private CheckBox chkToEditor;

        public int LineNumber => (int)numLine.Value;
        public bool ToEditor => chkToEditor.Checked;

        public frmGoTo(int totalLines)
        {
            Text = "Перейти к строке";
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterParent;
            MaximizeBox = false;
            MinimizeBox = false;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            Padding = new Padding(12);

            var lbl = new Label
            {
                Text = "Номер строки:",
                AutoSize = true,
                Anchor = AnchorStyles.Left,
                Margin = new Padding(3, 6, 12, 6)
            };
            numLine = new NumericUpDown
            {
                Minimum = 1,
                Maximum = Math.Max(1, totalLines),
                Value = 1,
                Width = LogicalToDeviceUnits(90),
                Anchor = AnchorStyles.Left
            };
            chkToEditor = new CheckBox
            {
                Text = "После перехода - в редактор",
                AutoSize = true,
                Margin = new Padding(3, 6, 3, 6)
            };

            var btnOk = new Button
            {
                Text = "OK",
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                Padding = new Padding(0, 6, 0, 6),
                Dock = DockStyle.Fill,
                DialogResult = DialogResult.OK
            };
            var btnCancel = new Button
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

            var tlp = new TableLayoutPanel
            {
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                ColumnCount = 2,
                RowCount = 3
            };
            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            for (int i = 0; i < 3; i++) tlp.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tlp.Controls.Add(lbl, 0, 0);
            tlp.Controls.Add(numLine, 1, 0);
            tlp.Controls.Add(chkToEditor, 0, 1);
            tlp.SetColumnSpan(chkToEditor, 2);
            tlp.Controls.Add(buttons, 0, 2);
            tlp.SetColumnSpan(buttons, 2);

            Controls.Add(tlp);
            AcceptButton = btnOk;
            CancelButton = btnCancel;
        }
    }
}