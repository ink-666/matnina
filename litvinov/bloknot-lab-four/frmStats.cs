using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace lab_3_bloknot
{
    // Форма «Статистика» — интерфейс создаётся кодом; размер окна подстраивается под текст
    public class frmStats : Form
    {
        public frmStats(string text)
        {
            Text = "Статистика";
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterParent;
            MaximizeBox = false;
            MinimizeBox = false;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            Padding = new Padding(12);

            // ---- подсчёт показателей ----
            string[] lines = text.Length == 0
                ? new string[0]
                : text.Replace("\r\n", "\n").Split('\n');
            int chars = text.Length;
            int words = text.Split(new[] { ' ', '\n', '\r', '\t' },
                                   StringSplitOptions.RemoveEmptyEntries).Length;
            int sentences = text.Split(new[] { '.', '!', '?' },
                                       StringSplitOptions.RemoveEmptyEntries)
                                .Count(s => s.Trim().Length > 0);
            int nonEmpty = lines.Count(l => l.Trim().Length > 0);
            int longest = lines.Length == 0 ? 0 : lines.Max(l => l.Length);

            string[] names = { "Символов (с пробелами):", "Слов:", "Предложений:",
                               "Строк:", "Непустых строк:", "Самый длинный абзац:" };
            int[] values = { chars, words, sentences, lines.Length, nonEmpty, longest };

            // ---- таблица «название — значение» ----
            var tlp = new TableLayoutPanel
            {
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                ColumnCount = 2,
                RowCount = names.Length + 1
            };
            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));

            for (int i = 0; i < names.Length; i++)
            {
                tlp.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                tlp.Controls.Add(new Label
                {
                    Text = names[i],
                    AutoSize = true,
                    Anchor = AnchorStyles.Left,
                    Margin = new Padding(3, 6, 24, 6)
                }, 0, i);
                tlp.Controls.Add(new Label
                {
                    Text = values[i].ToString(),
                    AutoSize = true,
                    Anchor = AnchorStyles.Right,
                    Margin = new Padding(3, 6, 3, 6)
                }, 1, i);
            }

            tlp.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            var btnClose = new Button
            {
                Text = "Закрыть",
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                Padding = new Padding(0, 6, 0, 6),
                Dock = DockStyle.Fill,
                Margin = new Padding(3, 12, 3, 3),
                DialogResult = DialogResult.OK
            };
            tlp.Controls.Add(btnClose, 0, names.Length);
            tlp.SetColumnSpan(btnClose, 2);

            Controls.Add(tlp);
            AcceptButton = btnClose;
            CancelButton = btnClose;
        }
    }
}