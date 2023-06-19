namespace WinFormsApp6
{
    public partial class Form1 : Form
    {
        int x = -1;
        int sum=0;
        int sum2 = 0;
        
        string st = "";
        string st2 = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            
            
            
            

            
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            x++;
            if (textBox1.Text.Length > x)
            {
                
                sum += textBox1.Text[x] - '0';
                if(x == 0)
                {
                    st += textBox1.Text[x];
                }
                else
                {
                    st += "+" + textBox1.Text[x];
                }
                
                listBox1.Items.Add($"{st} = {sum}");
            }
            if (textBox2.Text.Length > x)
            {

                sum2 += textBox2.Text[x] - '0';
                if (x == 0)
                {
                    st2 += textBox2.Text[x];
                }
                else
                {
                    st2 += "+" + textBox2.Text[x];
                }

                listBox2.Items.Add($"{st2} = {sum2}");
            }

            if(textBox1.Text.Length < x && textBox2.Text.Length < x)
            {
                int max = 0;
                if(sum > sum2)
                {
                    max = sum;                    
                    timer1.Enabled = false;
                    MessageBox.Show($"Сумма 1: {sum}, Сумма 2: {sum2}\nСумма 1 больше", "Конец");
                }
                else if(sum == sum2)
                {
                    max = sum;
                    
                    timer1.Enabled = false;
                    MessageBox.Show($"Сумма 1: {sum}, Сумма 2: {sum2}\nОдинаковы", "Конец");
                }
                else
                {
                    max = sum2;
                    
                    timer1.Enabled = false;
                    MessageBox.Show($"Сумма 1: {sum}, Сумма 2: {sum2}\nСумма 2 больше", "Конец");
                }
                
            }

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar == ',')
            {
                e.Handled = true; //Игнор клавиш
            }
        }
    }
}