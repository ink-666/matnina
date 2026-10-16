using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PcConfigurator
{
    public partial class Form1 : Form
    {
        // ---------- Именованные константы цен ----------
        // Процессор
        private const int PRICE_I3 = 9000;
        private const int PRICE_I5 = 15000;
        private const int PRICE_I7 = 25000;

        // Память
        private const int PRICE_MEM_8 = 2500;
        private const int PRICE_MEM_16 = 4800;
        private const int PRICE_MEM_32 = 9600;
        private const int PRICE_MEM_64 = 19200;

        // Накопитель
        private const int PRICE_SSD_256 = 2200;
        private const int PRICE_SSD_512 = 4500;
        private const int PRICE_SSD_1TB = 13000;

        // Видеокарта
        private const int PRICE_GPU_INTEGRATED = 0;
        private const int PRICE_GPU_1650 = 12000;
        private const int PRICE_GPU_3060 = 25000;
        private const int PRICE_GPU_4070 = 55000;

        // Дополнительно
        private const int PRICE_CASE = 0;
        private const int PRICE_PSU = 2500;
        private const int PRICE_COOLER = 3500;
        private const int PRICE_WINDOWS = 8000;
        private const int PRICE_MONITOR = 9000;
        private const int PRICE_KB_MOUSE = 1200;
        private const int PRICE_ASSEMBLY = 1400;

        // Доставка
        private const int PRICE_DELIVERY_CENTER = 0;
        private const int PRICE_DELIVERY_RESIDENTIAL = 1300;
        private const int PRICE_DELIVERY_SUBURB = 4100;

        // ---------- Данные заказа ----------
        // Позиция заказа: строки предназначены только для отображения,
        // цена хранится отдельно в поле Price.
        private class OrderItem
        {
            public string Description;
            public int Price;
        }

        private readonly List<OrderItem> order = new List<OrderItem>();
        private int dayOrderNumber = 0;

        public Form1()
        {
            InitializeComponent();
            Recalculate();
        }

        // ---------- Расчёт стоимости ----------

        /// <summary>
        /// Возвращает стоимость одного собранного компьютера
        /// (процессор + память + накопитель + видеокарта + допы),
        /// без учёта количества и доставки.
        /// </summary>
        private int GetPrice()
        {
            int price = 0;

            if (rbI3.Checked) price += PRICE_I3;
            else if (rbI5.Checked) price += PRICE_I5;
            else if (rbI7.Checked) price += PRICE_I7;

            price += GetMemoryPrice();
            price += GetStoragePrice();

            if (rbGpuIntegrated.Checked) price += PRICE_GPU_INTEGRATED;
            else if (rbGpu1650.Checked) price += PRICE_GPU_1650;
            else if (rbGpu3060.Checked) price += PRICE_GPU_3060;
            else if (rbGpu4070.Checked) price += PRICE_GPU_4070;

            if (chkCase.Checked) price += PRICE_CASE;
            if (chkPsu.Checked) price += PRICE_PSU;
            if (chkCooler.Checked) price += PRICE_COOLER;
            if (chkWindows.Checked) price += PRICE_WINDOWS;
            if (chkMonitor.Checked) price += PRICE_MONITOR;
            if (chkKbMouse.Checked) price += PRICE_KB_MOUSE;
            if (chkAssembly.Checked) price += PRICE_ASSEMBLY;

            return price;
        }

        private int GetMemoryPrice()
        {
            switch (cmbMemory.SelectedIndex)
            {
                case 0: return PRICE_MEM_8;
                case 1: return PRICE_MEM_16;
                case 2: return PRICE_MEM_32;
                case 3: return PRICE_MEM_64;
                default: return 0;
            }
        }

        private int GetStoragePrice()
        {
            switch (cmbStorage.SelectedIndex)
            {
                case 0: return PRICE_SSD_256;
                case 1: return PRICE_SSD_512;
                case 2: return PRICE_SSD_1TB;
                default: return 0;
            }
        }

        /// <summary>Стоимость доставки в выбранную зону (0, если доставка не выбрана).</summary>
        private int DeliveryPrice()
        {
            if (!chkDelivery.Checked) return 0;

            switch (cmbDeliveryZone.SelectedIndex)
            {
                case 0: return PRICE_DELIVERY_CENTER;
                case 1: return PRICE_DELIVERY_RESIDENTIAL;
                case 2: return PRICE_DELIVERY_SUBURB;
                default: return 0;
            }
        }

        /// <summary>Обновляет подписи цены в каждой группе и итоговую цену текущей конфигурации.</summary>
        private void Recalculate()
        {
            // подписи цены выбранных пунктов ComboBox (у RadioButton/CheckBox цена статична)
            lblMemoryPrice.Text = GetMemoryPrice().ToString("N0");
            lblStoragePrice.Text = GetStoragePrice().ToString("N0");
            lblDeliveryPrice.Text = DeliveryPrice().ToString("N0");

            if (!int.TryParse(txtCount.Text, out int count) || count < 1 || count > 10)
            {
                lblResult.Text = "—";
                return;
            }

            int total = GetPrice() * count + DeliveryPrice();
            lblResult.Text = total.ToString("N0") + " ₽";
        }

        /// <summary>Строит текстовое описание текущей выбранной конфигурации для списка заказа.</summary>
        private string BuildDescription(int count)
        {
            string cpu = rbI3.Checked ? "Intel Core i3" : rbI5.Checked ? "Intel Core i5" : "Intel Core i7";
            string gpu = rbGpuIntegrated.Checked ? "встроенная видеокарта"
                       : rbGpu1650.Checked ? "GTX 1650"
                       : rbGpu3060.Checked ? "RTX 3060" : "RTX 4070";

            var extras = new List<string>();
            if (chkCase.Checked) extras.Add("корпус");
            if (chkPsu.Checked) extras.Add("блок питания");
            if (chkCooler.Checked) extras.Add("кулер");
            if (chkWindows.Checked) extras.Add("Windows");
            if (chkMonitor.Checked) extras.Add("монитор");
            if (chkKbMouse.Checked) extras.Add("клавиатура + мышь");
            if (chkAssembly.Checked) extras.Add("сборка");

            string extrasText = extras.Count > 0 ? ", " + string.Join(", ", extras) : "";
            string deliveryText = chkDelivery.Checked ? ", доставка (" + cmbDeliveryZone.Text + ")" : "";

            return $"{cpu}, {cmbMemory.Text}, {cmbStorage.Text}, {gpu}{extrasText}, x{count}{deliveryText}";
        }

        /// <summary>Перерисовывает список "Состав заказа" и итог заказа.</summary>
        private void RefreshOrder()
        {
            lstOrder.Items.Clear();
            int sum = 0;
            foreach (var item in order)
            {
                lstOrder.Items.Add(item.Description + " — " + item.Price.ToString("N0") + " ₽");
                sum += item.Price;
            }
            if (order.Count > 0)
            {
                lstOrder.Items.Add("Итого по заказу: " + sum.ToString("N0") + " ₽");
            }
        }

        // ---------- Обработчики событий ----------

        /// <summary>
        /// Общий обработчик для всех переключателей, флажков, списков и поля количества.
        /// Пересчитывает цену при любом изменении.
        /// </summary>
        private void Options_CheckedChanged(object sender, EventArgs e)
        {
            Recalculate();
        }

        private void chkDelivery_CheckedChanged(object sender, EventArgs e)
        {
            cmbDeliveryZone.Enabled = chkDelivery.Checked;
            lblDeliveryPrice.Enabled = chkDelivery.Checked;
            Recalculate();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtCount.Text, out int count) || count < 1 || count > 10)
            {
                MessageBox.Show("Введите количество от 1 до 10", "Ошибка ввода",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int price = GetPrice() * count + DeliveryPrice();
            order.Add(new OrderItem { Description = BuildDescription(count), Price = price });
            RefreshOrder();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            // последняя строка списка — это строка "Итого", а не позиция заказа
            if (lstOrder.SelectedIndex == -1 || lstOrder.SelectedIndex >= order.Count)
            {
                MessageBox.Show("Выберите позицию для удаления", "Удаление позиции",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            order.RemoveAt(lstOrder.SelectedIndex);
            RefreshOrder();
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            if (order.Count == 0)
            {
                MessageBox.Show("Состав заказа пуст. Добавьте хотя бы одну позицию.",
                    "Оформление заказа", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int total = 0;
            foreach (var item in order) total += item.Price;

            DialogResult r = MessageBox.Show(
                "Оформить заказ на " + total.ToString("N0") + " ₽?",
                "Подтверждение",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (r == DialogResult.Yes)
            {
                dayOrderNumber++;
                string line = $"Заказ №{dayOrderNumber} от {DateTime.Now:dd.MM HH:mm} — " +
                              $"{order.Count} поз. — {total:N0} ₽";
                lstDay.Items.Add(line);

                order.Clear();
                RefreshOrder();
            }
            // при выборе "Нет" состав заказа сохраняется без изменений
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            rbI3.Checked = true;
            cmbMemory.SelectedIndex = 0;
            cmbStorage.SelectedIndex = 0;
            rbGpu1650.Checked = true;

            chkCase.Checked = true;
            chkPsu.Checked = true;
            chkCooler.Checked = false;
            chkWindows.Checked = false;
            chkMonitor.Checked = true;
            chkKbMouse.Checked = false;
            chkAssembly.Checked = false;

            chkDelivery.Checked = false;
            cmbDeliveryZone.SelectedIndex = 0;

            txtCount.Text = "1";

            Recalculate();
        }
    }
}
