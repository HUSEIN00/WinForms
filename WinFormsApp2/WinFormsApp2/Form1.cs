using System.Diagnostics;
using System.Drawing;

namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        string name;
        string dost;
        int count;
        decimal price;
        decimal skidka;
        decimal price_skid;
        int countRecords;
        public Form1()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked == true)
            {
                textBox3.Enabled = true;
            }
            else
            {
                textBox3.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            name = textBox1.Text.Trim();
            dost = comboBox1.Text;
            count = Convert.ToInt32(numericUpDown1.Value);
            try
            {
                price = decimal.Parse(textBox2.Text.Trim());
            }
            catch
            {
                price = 0;
                textBox2.Clear();
                MessageBox.Show("Введи нормально", "Ошибка");
                return;
            }

            //ff
            dataGridView1.RowCount++;
            dataGridView1.Rows[dataGridView1.RowCount - 1].Cells[0].Value = name;
            dataGridView1.Rows[dataGridView1.RowCount - 1].Cells[1].Value = dost;
            dataGridView1.Rows[dataGridView1.RowCount - 1].Cells[2].Value = count;
            dataGridView1.Rows[dataGridView1.RowCount - 1].Cells[3].Value = String.Format("{0:C}", price);
            dataGridView1.Rows[dataGridView1.RowCount - 1].Cells[4].Value = skidka.ToString() + "%";
            dataGridView1.Rows[dataGridView1.RowCount - 1].Cells[5].Value = String.Format("{0:C}", price_skid);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            checkBox1.Checked = true;
            checkBox1.Checked = false;
            dataGridView1.ColumnCount = 7;
            dataGridView1.TopLeftHeaderCell.Value = "№";
            dataGridView1.TopLeftHeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.RowHeadersVisible = true;
            dataGridView1.ColumnHeadersVisible = true;
            dataGridView1.Columns[0].HeaderCell.Value = "Товар";
            dataGridView1.Columns[1].HeaderCell.Value = "Доставка";
            dataGridView1.Columns[2].HeaderText = "Кол-ва товара";
            dataGridView1.Columns[3].HeaderText = "Цена";
            dataGridView1.Columns[4].HeaderText = "Скидка";
            dataGridView1.Columns[5].HeaderText = "Итоговая цена";
            // RowCount по умолчанию становится 1, так как есть одна строка заголовков
            // Устанавливаем по центру заголовки таблицы
            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            {
                dataGridView1.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            }
            countRecords++; // Стало 1

        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            price_skid = Convert.ToDecimal(textBox2.Text) * (1 - Convert.ToDecimal(textBox3.Text) / 100);
            textBox4.Text = String.Format("{0:C}", price_skid);

        }
    }
}