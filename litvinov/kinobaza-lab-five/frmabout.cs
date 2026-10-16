using System;
using System.Drawing;
using System.Windows.Forms;

namespace MovieBase
{
    // Форма «О программе» (Show): интерфейс создаётся кодом, размер подстраивается под текст
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
                Text = "Кинобаза (версия 1.0)",
                AutoSize = true,
                Anchor = AnchorStyles.None,
                Font = new Font(Font, FontStyle.Bold),
                Margin = new Padding(3, 3, 3, 12)
            };
            var lblAuthor = new Label { Text = "Автор: Литвинов Семён", AutoSize = true, Margin = new Padding(3, 3, 3, 10) };
            var lblGroup = new Label { Text = "Группа: 24/ИП-391к", AutoSize = true, Margin = new Padding(3, 3, 3, 10) };
            var lblPurpose = new Label
            {
                Text = "Назначение: каталог фильмов киномана с личными оценками, отметкой «просмотрен» и статистикой коллекции.",
                AutoSize = true,
                MaximumSize = new Size(LogicalToDeviceUnits(340), 0),
                Margin = new Padding(3)
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

        private void InitializeComponent()
        {

        }
    }
}