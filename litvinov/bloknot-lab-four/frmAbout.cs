using System;
using System.Drawing;
using System.Windows.Forms;

namespace lab_3_bloknot
{
    // Форма «О программе» — немодальная (Show), интерфейс создаётся кодом
    public class frmAbout : Form
    {
        public frmAbout()
        {
            Text = "О программе";
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterParent;
            MaximizeBox = false;
            MinimizeBox = false;
            ShowInTaskbar = false;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            Padding = new Padding(12);

            var lblTitle = new Label
            {
                Text = "Блокнот (версия 1.0)",
                AutoSize = true,
                Anchor = AnchorStyles.None,
                Font = new Font(Font, FontStyle.Bold),
                Margin = new Padding(3, 3, 3, 12)
            };
            var lblAuthor = new Label { Text = "Автор: Фамилия Имя", AutoSize = true, Margin = new Padding(3, 3, 3, 10) };
            var lblGroup = new Label { Text = "Группа: ХХХ-00", AutoSize = true, Margin = new Padding(3, 3, 3, 10) };
            var lblPurpose = new Label
            {
                Text = "Назначение: простой текстовый редактор с поиском, предпросмотром и статистикой текста.",
                AutoSize = true,
                MaximumSize = new Size(LogicalToDeviceUnits(340), 0),
                Margin = new Padding(3, 3, 3, 3)
            };

            var tlp = new TableLayoutPanel
            {
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                ColumnCount = 1,
                RowCount = 4
            };
            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            for (int i = 0; i < 4; i++) tlp.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tlp.Controls.Add(lblTitle, 0, 0);
            tlp.Controls.Add(lblAuthor, 0, 1);
            tlp.Controls.Add(lblGroup, 0, 2);
            tlp.Controls.Add(lblPurpose, 0, 3);

            Controls.Add(tlp);
        }
    }
}