namespace PcConfigurator
{
    partial class Form1
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

        // ---- Заголовки колонок ----
        private System.Windows.Forms.Label lblCategoriesHeader;
        private System.Windows.Forms.Label lblOrderHeader;
        private System.Windows.Forms.Label lblDayHeader;

        // ---- Группа "Процессор" ----
        private System.Windows.Forms.GroupBox grpProcessor;
        private System.Windows.Forms.Label lblPriceHeadProc;
        private System.Windows.Forms.RadioButton rbI3;
        private System.Windows.Forms.RadioButton rbI5;
        private System.Windows.Forms.RadioButton rbI7;
        private System.Windows.Forms.Label lblPriceI3;
        private System.Windows.Forms.Label lblPriceI5;
        private System.Windows.Forms.Label lblPriceI7;

        // ---- Группа "Память" ----
        private System.Windows.Forms.GroupBox grpMemory;
        private System.Windows.Forms.Label lblPriceHeadMem;
        private System.Windows.Forms.ComboBox cmbMemory;
        private System.Windows.Forms.Label lblMemoryPrice;

        // ---- Группа "Накопитель" ----
        private System.Windows.Forms.GroupBox grpStorage;
        private System.Windows.Forms.Label lblPriceHeadStor;
        private System.Windows.Forms.ComboBox cmbStorage;
        private System.Windows.Forms.Label lblStoragePrice;

        // ---- Группа "Видеокарта" ----
        private System.Windows.Forms.GroupBox grpVideo;
        private System.Windows.Forms.Label lblPriceHeadVideo;
        private System.Windows.Forms.RadioButton rbGpuIntegrated;
        private System.Windows.Forms.RadioButton rbGpu1650;
        private System.Windows.Forms.RadioButton rbGpu3060;
        private System.Windows.Forms.RadioButton rbGpu4070;
        private System.Windows.Forms.Label lblGpuIntegratedPrice;
        private System.Windows.Forms.Label lblGpu1650Price;
        private System.Windows.Forms.Label lblGpu3060Price;
        private System.Windows.Forms.Label lblGpu4070Price;

        // ---- Группа "Дополнительно" ----
        private System.Windows.Forms.GroupBox grpExtras;
        private System.Windows.Forms.Label lblPriceHeadExtras;
        private System.Windows.Forms.CheckBox chkCase;
        private System.Windows.Forms.CheckBox chkPsu;
        private System.Windows.Forms.CheckBox chkCooler;
        private System.Windows.Forms.CheckBox chkWindows;
        private System.Windows.Forms.CheckBox chkMonitor;
        private System.Windows.Forms.CheckBox chkKbMouse;
        private System.Windows.Forms.CheckBox chkAssembly;
        private System.Windows.Forms.Label lblCasePrice;
        private System.Windows.Forms.Label lblPsuPrice;
        private System.Windows.Forms.Label lblCoolerPrice;
        private System.Windows.Forms.Label lblWindowsPrice;
        private System.Windows.Forms.Label lblMonitorPrice;
        private System.Windows.Forms.Label lblKbMousePrice;
        private System.Windows.Forms.Label lblAssemblyPrice;

        // ---- Доставка и итог ----
        private System.Windows.Forms.CheckBox chkDelivery;
        private System.Windows.Forms.ComboBox cmbDeliveryZone;
        private System.Windows.Forms.Label lblDeliveryPrice;
        private System.Windows.Forms.Label lblTotalCaption;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Button btnReset;

        // ---- Состав заказа ----
        private System.Windows.Forms.Label lblCountCaption;
        private System.Windows.Forms.TextBox txtCount;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.ListBox lstOrder;
        private System.Windows.Forms.Button btnCheckout;

        // ---- Заказы за день ----
        private System.Windows.Forms.ListBox lstDay;

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.SuspendLayout();

            // ===== Форма =====
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(930, 850);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Конфигурация ПК";
            this.Name = "Form1";
            this.Font = new System.Drawing.Font("Segoe UI", 9F);

            // ===== Заголовки колонок =====
            this.lblCategoriesHeader = new System.Windows.Forms.Label();
            this.lblCategoriesHeader.Location = new System.Drawing.Point(12, 9);
            this.lblCategoriesHeader.Size = new System.Drawing.Size(215, 24);
            this.lblCategoriesHeader.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular);
            this.lblCategoriesHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCategoriesHeader.Text = "Категории";

            this.lblOrderHeader = new System.Windows.Forms.Label();
            this.lblOrderHeader.Location = new System.Drawing.Point(272, 9);
            this.lblOrderHeader.Size = new System.Drawing.Size(293, 24);
            this.lblOrderHeader.Font = this.lblCategoriesHeader.Font;
            this.lblOrderHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblOrderHeader.Text = "Состав заказа";

            this.lblDayHeader = new System.Windows.Forms.Label();
            this.lblDayHeader.Location = new System.Drawing.Point(615, 9);
            this.lblDayHeader.Size = new System.Drawing.Size(293, 24);
            this.lblDayHeader.Font = this.lblCategoriesHeader.Font;
            this.lblDayHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblDayHeader.Text = "Заказы за день";

            // ===== Группа "Процессор" =====
            this.grpProcessor = new System.Windows.Forms.GroupBox();
            this.grpProcessor.Location = new System.Drawing.Point(12, 38);
            this.grpProcessor.Size = new System.Drawing.Size(215, 112);
            this.grpProcessor.Text = "Процессор";
            this.grpProcessor.TabStop = false;

            this.lblPriceHeadProc = MakePriceHeader(150, 18);
            this.rbI3 = new System.Windows.Forms.RadioButton();
            this.rbI3.Location = new System.Drawing.Point(10, 38);
            this.rbI3.Size = new System.Drawing.Size(140, 20);
            this.rbI3.Text = "Intel Core i3";
            this.rbI3.Checked = true;
            this.rbI3.Name = "rbI3";
            this.rbI3.CheckedChanged += new System.EventHandler(this.Options_CheckedChanged);

            this.rbI5 = new System.Windows.Forms.RadioButton();
            this.rbI5.Location = new System.Drawing.Point(10, 63);
            this.rbI5.Size = new System.Drawing.Size(140, 20);
            this.rbI5.Text = "Intel Core i5";
            this.rbI5.Name = "rbI5";
            this.rbI5.CheckedChanged += new System.EventHandler(this.Options_CheckedChanged);

            this.rbI7 = new System.Windows.Forms.RadioButton();
            this.rbI7.Location = new System.Drawing.Point(10, 88);
            this.rbI7.Size = new System.Drawing.Size(140, 20);
            this.rbI7.Text = "Intel Core i7";
            this.rbI7.Name = "rbI7";
            this.rbI7.CheckedChanged += new System.EventHandler(this.Options_CheckedChanged);

            this.lblPriceI3 = MakePriceLabel(160, 38, "9 000");
            this.lblPriceI5 = MakePriceLabel(160, 63, "15 000");
            this.lblPriceI7 = MakePriceLabel(160, 88, "25 000");

            this.grpProcessor.Controls.Add(this.lblPriceHeadProc);
            this.grpProcessor.Controls.Add(this.rbI3);
            this.grpProcessor.Controls.Add(this.rbI5);
            this.grpProcessor.Controls.Add(this.rbI7);
            this.grpProcessor.Controls.Add(this.lblPriceI3);
            this.grpProcessor.Controls.Add(this.lblPriceI5);
            this.grpProcessor.Controls.Add(this.lblPriceI7);

            // ===== Группа "Память" =====
            this.grpMemory = new System.Windows.Forms.GroupBox();
            this.grpMemory.Location = new System.Drawing.Point(12, 158);
            this.grpMemory.Size = new System.Drawing.Size(215, 78);
            this.grpMemory.Text = "Память";
            this.grpMemory.TabStop = false;

            this.lblPriceHeadMem = MakePriceHeader(150, 18);
            this.cmbMemory = new System.Windows.Forms.ComboBox();
            this.cmbMemory.Location = new System.Drawing.Point(10, 40);
            this.cmbMemory.Size = new System.Drawing.Size(120, 23);
            this.cmbMemory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMemory.Items.AddRange(new object[] { "8 ГБ", "16 ГБ", "32 ГБ", "64 ГБ" });
            this.cmbMemory.SelectedIndex = 0;
            this.cmbMemory.Name = "cmbMemory";
            this.cmbMemory.SelectedIndexChanged += new System.EventHandler(this.Options_CheckedChanged);

            this.lblMemoryPrice = MakePriceLabel(160, 43, "2 500");

            this.grpMemory.Controls.Add(this.lblPriceHeadMem);
            this.grpMemory.Controls.Add(this.cmbMemory);
            this.grpMemory.Controls.Add(this.lblMemoryPrice);

            // ===== Группа "Накопитель" =====
            this.grpStorage = new System.Windows.Forms.GroupBox();
            this.grpStorage.Location = new System.Drawing.Point(12, 244);
            this.grpStorage.Size = new System.Drawing.Size(215, 78);
            this.grpStorage.Text = "Накопитель";
            this.grpStorage.TabStop = false;

            this.lblPriceHeadStor = MakePriceHeader(150, 18);
            this.cmbStorage = new System.Windows.Forms.ComboBox();
            this.cmbStorage.Location = new System.Drawing.Point(10, 40);
            this.cmbStorage.Size = new System.Drawing.Size(120, 23);
            this.cmbStorage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStorage.Items.AddRange(new object[] { "SSD 256 ГБ", "SSD 512 ГБ", "SSD 1 ТБ" });
            this.cmbStorage.SelectedIndex = 0;
            this.cmbStorage.Name = "cmbStorage";
            this.cmbStorage.SelectedIndexChanged += new System.EventHandler(this.Options_CheckedChanged);

            this.lblStoragePrice = MakePriceLabel(160, 43, "2 200");

            this.grpStorage.Controls.Add(this.lblPriceHeadStor);
            this.grpStorage.Controls.Add(this.cmbStorage);
            this.grpStorage.Controls.Add(this.lblStoragePrice);

            // ===== Группа "Видеокарта" =====
            this.grpVideo = new System.Windows.Forms.GroupBox();
            this.grpVideo.Location = new System.Drawing.Point(12, 330);
            this.grpVideo.Size = new System.Drawing.Size(215, 138);
            this.grpVideo.Text = "Видеокарта";
            this.grpVideo.TabStop = false;

            this.lblPriceHeadVideo = MakePriceHeader(150, 18);

            this.rbGpuIntegrated = new System.Windows.Forms.RadioButton();
            this.rbGpuIntegrated.Location = new System.Drawing.Point(10, 38);
            this.rbGpuIntegrated.Size = new System.Drawing.Size(140, 20);
            this.rbGpuIntegrated.Text = "Встроенная";
            this.rbGpuIntegrated.Name = "rbGpuIntegrated";
            this.rbGpuIntegrated.CheckedChanged += new System.EventHandler(this.Options_CheckedChanged);

            this.rbGpu1650 = new System.Windows.Forms.RadioButton();
            this.rbGpu1650.Location = new System.Drawing.Point(10, 63);
            this.rbGpu1650.Size = new System.Drawing.Size(140, 20);
            this.rbGpu1650.Text = "GTX 1650";
            this.rbGpu1650.Checked = true;
            this.rbGpu1650.Name = "rbGpu1650";
            this.rbGpu1650.CheckedChanged += new System.EventHandler(this.Options_CheckedChanged);

            this.rbGpu3060 = new System.Windows.Forms.RadioButton();
            this.rbGpu3060.Location = new System.Drawing.Point(10, 88);
            this.rbGpu3060.Size = new System.Drawing.Size(140, 20);
            this.rbGpu3060.Text = "RTX 3060";
            this.rbGpu3060.Name = "rbGpu3060";
            this.rbGpu3060.CheckedChanged += new System.EventHandler(this.Options_CheckedChanged);

            this.rbGpu4070 = new System.Windows.Forms.RadioButton();
            this.rbGpu4070.Location = new System.Drawing.Point(10, 113);
            this.rbGpu4070.Size = new System.Drawing.Size(140, 20);
            this.rbGpu4070.Text = "RTX 4070";
            this.rbGpu4070.Name = "rbGpu4070";
            this.rbGpu4070.CheckedChanged += new System.EventHandler(this.Options_CheckedChanged);

            this.lblGpuIntegratedPrice = MakePriceLabel(160, 38, "0");
            this.lblGpu1650Price = MakePriceLabel(160, 63, "12 000");
            this.lblGpu3060Price = MakePriceLabel(160, 88, "25 000");
            this.lblGpu4070Price = MakePriceLabel(160, 113, "55 000");

            this.grpVideo.Controls.Add(this.lblPriceHeadVideo);
            this.grpVideo.Controls.Add(this.rbGpuIntegrated);
            this.grpVideo.Controls.Add(this.rbGpu1650);
            this.grpVideo.Controls.Add(this.rbGpu3060);
            this.grpVideo.Controls.Add(this.rbGpu4070);
            this.grpVideo.Controls.Add(this.lblGpuIntegratedPrice);
            this.grpVideo.Controls.Add(this.lblGpu1650Price);
            this.grpVideo.Controls.Add(this.lblGpu3060Price);
            this.grpVideo.Controls.Add(this.lblGpu4070Price);

            // ===== Группа "Дополнительно" =====
            this.grpExtras = new System.Windows.Forms.GroupBox();
            this.grpExtras.Location = new System.Drawing.Point(12, 476);
            this.grpExtras.Size = new System.Drawing.Size(215, 232);
            this.grpExtras.Text = "Дополнительно";
            this.grpExtras.TabStop = false;

            this.lblPriceHeadExtras = MakePriceHeader(150, 18);

            this.chkCase = new System.Windows.Forms.CheckBox();
            this.chkCase.Location = new System.Drawing.Point(10, 38);
            this.chkCase.Size = new System.Drawing.Size(140, 20);
            this.chkCase.Text = "Корпус";
            this.chkCase.Checked = true;
            this.chkCase.Name = "chkCase";
            this.chkCase.CheckedChanged += new System.EventHandler(this.Options_CheckedChanged);

            this.chkPsu = new System.Windows.Forms.CheckBox();
            this.chkPsu.Location = new System.Drawing.Point(10, 61);
            this.chkPsu.Size = new System.Drawing.Size(140, 20);
            this.chkPsu.Text = "Блок питания";
            this.chkPsu.Checked = true;
            this.chkPsu.Name = "chkPsu";
            this.chkPsu.CheckedChanged += new System.EventHandler(this.Options_CheckedChanged);

            this.chkCooler = new System.Windows.Forms.CheckBox();
            this.chkCooler.Location = new System.Drawing.Point(10, 84);
            this.chkCooler.Size = new System.Drawing.Size(140, 20);
            this.chkCooler.Text = "Кулер";
            this.chkCooler.Name = "chkCooler";
            this.chkCooler.CheckedChanged += new System.EventHandler(this.Options_CheckedChanged);

            this.chkWindows = new System.Windows.Forms.CheckBox();
            this.chkWindows.Location = new System.Drawing.Point(10, 107);
            this.chkWindows.Size = new System.Drawing.Size(140, 20);
            this.chkWindows.Text = "Windows";
            this.chkWindows.Name = "chkWindows";
            this.chkWindows.CheckedChanged += new System.EventHandler(this.Options_CheckedChanged);

            this.chkMonitor = new System.Windows.Forms.CheckBox();
            this.chkMonitor.Location = new System.Drawing.Point(10, 130);
            this.chkMonitor.Size = new System.Drawing.Size(140, 20);
            this.chkMonitor.Text = "Монитор";
            this.chkMonitor.Checked = true;
            this.chkMonitor.Name = "chkMonitor";
            this.chkMonitor.CheckedChanged += new System.EventHandler(this.Options_CheckedChanged);

            this.chkKbMouse = new System.Windows.Forms.CheckBox();
            this.chkKbMouse.Location = new System.Drawing.Point(10, 153);
            this.chkKbMouse.Size = new System.Drawing.Size(140, 34);
            this.chkKbMouse.Text = "Клавиатура + мышь";
            this.chkKbMouse.Name = "chkKbMouse";
            this.chkKbMouse.CheckedChanged += new System.EventHandler(this.Options_CheckedChanged);

            this.chkAssembly = new System.Windows.Forms.CheckBox();
            this.chkAssembly.Location = new System.Drawing.Point(10, 197);
            this.chkAssembly.Size = new System.Drawing.Size(140, 20);
            this.chkAssembly.Text = "Сборка";
            this.chkAssembly.Name = "chkAssembly";
            this.chkAssembly.CheckedChanged += new System.EventHandler(this.Options_CheckedChanged);

            this.lblCasePrice = MakePriceLabel(160, 38, "0");
            this.lblPsuPrice = MakePriceLabel(160, 61, "2 500");
            this.lblCoolerPrice = MakePriceLabel(160, 84, "3 500");
            this.lblWindowsPrice = MakePriceLabel(160, 107, "8 000");
            this.lblMonitorPrice = MakePriceLabel(160, 130, "9 000");
            this.lblKbMousePrice = MakePriceLabel(160, 158, "1 200");
            this.lblAssemblyPrice = MakePriceLabel(160, 197, "1 400");

            this.grpExtras.Controls.Add(this.lblPriceHeadExtras);
            this.grpExtras.Controls.Add(this.chkCase);
            this.grpExtras.Controls.Add(this.chkPsu);
            this.grpExtras.Controls.Add(this.chkCooler);
            this.grpExtras.Controls.Add(this.chkWindows);
            this.grpExtras.Controls.Add(this.chkMonitor);
            this.grpExtras.Controls.Add(this.chkKbMouse);
            this.grpExtras.Controls.Add(this.chkAssembly);
            this.grpExtras.Controls.Add(this.lblCasePrice);
            this.grpExtras.Controls.Add(this.lblPsuPrice);
            this.grpExtras.Controls.Add(this.lblCoolerPrice);
            this.grpExtras.Controls.Add(this.lblWindowsPrice);
            this.grpExtras.Controls.Add(this.lblMonitorPrice);
            this.grpExtras.Controls.Add(this.lblKbMousePrice);
            this.grpExtras.Controls.Add(this.lblAssemblyPrice);

            // ===== Доставка =====
            this.chkDelivery = new System.Windows.Forms.CheckBox();
            this.chkDelivery.Location = new System.Drawing.Point(12, 716);
            this.chkDelivery.Size = new System.Drawing.Size(100, 20);
            this.chkDelivery.Text = "Доставка";
            this.chkDelivery.Name = "chkDelivery";
            this.chkDelivery.CheckedChanged += new System.EventHandler(this.chkDelivery_CheckedChanged);

            this.cmbDeliveryZone = new System.Windows.Forms.ComboBox();
            this.cmbDeliveryZone.Location = new System.Drawing.Point(12, 740);
            this.cmbDeliveryZone.Size = new System.Drawing.Size(120, 23);
            this.cmbDeliveryZone.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDeliveryZone.Items.AddRange(new object[] { "Центр", "Спальный район", "Пригород" });
            this.cmbDeliveryZone.SelectedIndex = 0;
            this.cmbDeliveryZone.Enabled = false;
            this.cmbDeliveryZone.Name = "cmbDeliveryZone";
            this.cmbDeliveryZone.SelectedIndexChanged += new System.EventHandler(this.Options_CheckedChanged);

            this.lblDeliveryPrice = MakePriceLabel(160, 743, "0");
            this.lblDeliveryPrice.Enabled = false;

            // ===== Итог =====
            this.lblTotalCaption = new System.Windows.Forms.Label();
            this.lblTotalCaption.Location = new System.Drawing.Point(12, 772);
            this.lblTotalCaption.Size = new System.Drawing.Size(55, 23);
            this.lblTotalCaption.Text = "Итого:";
            this.lblTotalCaption.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTotalCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            this.lblResult = new System.Windows.Forms.Label();
            this.lblResult.Location = new System.Drawing.Point(70, 772);
            this.lblResult.Size = new System.Drawing.Size(157, 23);
            this.lblResult.Text = "9 000 ₽";
            this.lblResult.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblResult.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblResult.Name = "lblResult";

            // ===== Кнопка "Сбросить" =====
            this.btnReset = new System.Windows.Forms.Button();
            this.btnReset.Location = new System.Drawing.Point(12, 800);
            this.btnReset.Size = new System.Drawing.Size(215, 32);
            this.btnReset.Text = "Сбросить";
            this.btnReset.Name = "btnReset";
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);

            // ===== Панель "Состав заказа" =====
            this.lblCountCaption = new System.Windows.Forms.Label();
            this.lblCountCaption.Location = new System.Drawing.Point(272, 40);
            this.lblCountCaption.Size = new System.Drawing.Size(55, 23);
            this.lblCountCaption.Text = "Кол-во:";
            this.lblCountCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            this.txtCount = new System.Windows.Forms.TextBox();
            this.txtCount.Location = new System.Drawing.Point(330, 37);
            this.txtCount.Size = new System.Drawing.Size(40, 23);
            this.txtCount.Text = "1";
            this.txtCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCount.Name = "txtCount";
            this.txtCount.TextChanged += new System.EventHandler(this.Options_CheckedChanged);

            this.btnAdd = new System.Windows.Forms.Button();
            this.btnAdd.Location = new System.Drawing.Point(378, 36);
            this.btnAdd.Size = new System.Drawing.Size(90, 25);
            this.btnAdd.Text = "Добавить";
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            this.btnRemove = new System.Windows.Forms.Button();
            this.btnRemove.Location = new System.Drawing.Point(473, 36);
            this.btnRemove.Size = new System.Drawing.Size(92, 25);
            this.btnRemove.Text = "Удалить";
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);

            this.lstOrder = new System.Windows.Forms.ListBox();
            this.lstOrder.Location = new System.Drawing.Point(272, 70);
            this.lstOrder.Size = new System.Drawing.Size(293, 690);
            this.lstOrder.Name = "lstOrder";

            this.btnCheckout = new System.Windows.Forms.Button();
            this.btnCheckout.Location = new System.Drawing.Point(272, 768);
            this.btnCheckout.Size = new System.Drawing.Size(293, 32);
            this.btnCheckout.Text = "Оформить заказ";
            this.btnCheckout.Name = "btnCheckout";
            this.btnCheckout.Click += new System.EventHandler(this.btnCheckout_Click);

            // ===== Панель "Заказы за день" =====
            this.lstDay = new System.Windows.Forms.ListBox();
            this.lstDay.Location = new System.Drawing.Point(615, 36);
            this.lstDay.Size = new System.Drawing.Size(293, 764);
            this.lstDay.Name = "lstDay";

            // ===== Добавление на форму =====
            this.Controls.Add(this.lblCategoriesHeader);
            this.Controls.Add(this.lblOrderHeader);
            this.Controls.Add(this.lblDayHeader);
            this.Controls.Add(this.grpProcessor);
            this.Controls.Add(this.grpMemory);
            this.Controls.Add(this.grpStorage);
            this.Controls.Add(this.grpVideo);
            this.Controls.Add(this.grpExtras);
            this.Controls.Add(this.chkDelivery);
            this.Controls.Add(this.cmbDeliveryZone);
            this.Controls.Add(this.lblDeliveryPrice);
            this.Controls.Add(this.lblTotalCaption);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.lblCountCaption);
            this.Controls.Add(this.txtCount);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.lstOrder);
            this.Controls.Add(this.btnCheckout);
            this.Controls.Add(this.lstDay);

            this.ResumeLayout(false);
        }

        // Небольшие фабричные методы, чтобы не дублировать однотипный код
        // оформления подписей "Цена" и значений цены в каждой группе.
        private System.Windows.Forms.Label MakePriceHeader(int x, int y)
        {
            var lbl = new System.Windows.Forms.Label();
            lbl.Location = new System.Drawing.Point(x, y);
            lbl.Size = new System.Drawing.Size(50, 18);
            lbl.Text = "Цена";
            return lbl;
        }

        private System.Windows.Forms.Label MakePriceLabel(int x, int y, string text)
        {
            var lbl = new System.Windows.Forms.Label();
            lbl.Location = new System.Drawing.Point(x, y);
            lbl.Size = new System.Drawing.Size(55, 20);
            lbl.Text = text;
            return lbl;
        }

        #endregion
    }
}
