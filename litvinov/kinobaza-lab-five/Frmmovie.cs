using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace MovieBase
{
    // Форма «Фильм» (ShowDialog): добавление и редактирование.
    // Интерфейс создаётся кодом, размер окна подстраивается под содержимое.
    public class frmMovie : Form
    {
        private TextBox txtTitle, txtDirector;
        private NumericUpDown numYear, numMark;
        private ComboBox cmbGenre, cmbCountry;
        private CheckBox chkWatched;
        private Button btnOK, btnCancel;

        // Обмен данными с главной формой: запись до ShowDialog, чтение после OK
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string MovieTitle
        {
            get => txtTitle.Text.Trim();
            set => txtTitle.Text = value;
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int Year
        {
            get => (int)numYear.Value;
            set => numYear.Value = Math.Max(Movie.MinYear, Math.Min(Movie.MaxYear, value));
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Genre
        {
            get => Convert.ToString(cmbGenre.SelectedItem) ?? "";
            set
            {
                int i = Array.IndexOf(Movie.Genres, value);
                cmbGenre.SelectedIndex = i >= 0 ? i : 0;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Country
        {
            get => cmbCountry.Text.Trim();
            set => cmbCountry.Text = value;
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Director
        {
            get => txtDirector.Text.Trim();
            set => txtDirector.Text = value;
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int Mark
        {
            get => (int)numMark.Value;
            set => numMark.Value = Math.Max(Movie.MinMark, Math.Min(Movie.MaxMark, value));
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool Watched
        {
            get => chkWatched.Checked;
            set => chkWatched.Checked = value;
        }

        public frmMovie(string caption)
        {
            Text = caption;
            BuildUi();
            // значения по умолчанию для нового фильма
            cmbGenre.SelectedIndex = 0;
            numYear.Value = 2020;
            numMark.Value = 5;
        }

        private void BuildUi()
        {
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterParent;
            MaximizeBox = false;
            MinimizeBox = false;
            ShowInTaskbar = false;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            Padding = new Padding(12);

            int wide = LogicalToDeviceUnits(260);
            int narrow = LogicalToDeviceUnits(90);

            txtTitle = new TextBox { Name = "txtTitle", Width = wide, Anchor = AnchorStyles.Left };
            numYear = new NumericUpDown
            {
                Name = "numYear",
                Width = narrow,
                Anchor = AnchorStyles.Left,
                Minimum = Movie.MinYear,
                Maximum = Movie.MaxYear
            };
            cmbGenre = new ComboBox
            {
                Name = "cmbGenre",
                Width = wide,
                Anchor = AnchorStyles.Left,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbGenre.Items.AddRange(Movie.Genres);
            cmbCountry = new ComboBox { Name = "cmbCountry", Width = wide, Anchor = AnchorStyles.Left };
            cmbCountry.Items.AddRange(new object[]
            {
                "США", "СССР", "Россия", "Великобритания", "Франция", "Германия",
                "Италия", "Япония", "Южная Корея", "Индия", "Канада", "Испания"
            });
            txtDirector = new TextBox { Name = "txtDirector", Width = wide, Anchor = AnchorStyles.Left };
            numMark = new NumericUpDown
            {
                Name = "numMark",
                Width = narrow,
                Anchor = AnchorStyles.Left,
                Minimum = Movie.MinMark,
                Maximum = Movie.MaxMark
            };
            chkWatched = new CheckBox
            {
                Name = "chkWatched",
                Text = "Просмотрен",
                AutoSize = true,
                Margin = new Padding(3, 6, 3, 6)
            };

            btnOK = new Button
            {
                Name = "btnOK",
                Text = "OK",
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                Padding = new Padding(0, 6, 0, 6),
                Dock = DockStyle.Fill
            };
            btnCancel = new Button
            {
                Name = "btnCancel",
                Text = "Отмена",
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                Padding = new Padding(0, 6, 0, 6),
                Dock = DockStyle.Fill,
                DialogResult = DialogResult.Cancel
            };
            btnOK.Click += btnOK_Click;

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
            buttons.Controls.Add(btnOK, 0, 0);
            buttons.Controls.Add(btnCancel, 1, 0);

            var tlp = new TableLayoutPanel
            {
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                ColumnCount = 2,
                RowCount = 9
            };
            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            for (int i = 0; i < 9; i++) tlp.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            string[] captions = { "Название:", "Год:", "Жанр:", "Страна:", "Режиссёр:", "Оценка (1–10):" };
            Control[] fields = { txtTitle, numYear, cmbGenre, cmbCountry, txtDirector, numMark };
            for (int i = 0; i < captions.Length; i++)
            {
                tlp.Controls.Add(new Label
                {
                    Text = captions[i],
                    AutoSize = true,
                    Anchor = AnchorStyles.Left,
                    Margin = new Padding(3, 6, 12, 6)
                }, 0, i);
                tlp.Controls.Add(fields[i], 1, i);
            }
            tlp.Controls.Add(chkWatched, 1, 6);
            tlp.Controls.Add(buttons, 0, 7);
            tlp.SetColumnSpan(buttons, 2);

            Controls.Add(tlp);
            AcceptButton = btnOK;
            CancelButton = btnCancel;
        }

        // Валидация: все ошибки — одним MessageBox, форма при ошибках не закрывается
        private void btnOK_Click(object sender, EventArgs e)
        {
            var errors = new List<string>();
            if (txtTitle.Text.Trim().Length == 0) errors.Add("• Название не может быть пустым");
            if (cmbCountry.Text.Trim().Length == 0) errors.Add("• Страна не может быть пустой");
            if (txtDirector.Text.Trim().Length == 0) errors.Add("• Режиссёр не может быть пустым");

            if (errors.Count > 0)
            {
                MessageBox.Show("Исправьте ошибки:\n" + string.Join("\n", errors),
                    Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DialogResult = DialogResult.OK;
        }
    }
}