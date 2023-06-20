using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 日历
{
    public partial class Form2 : Form
    {
        private Button testButton = new Button();
        public Form2()
        {
            
            InitializeComponent();

            //代码添加button
            this.Controls.Add(testButton);
            testButton.Text = "代码按钮";
            testButton.Location = new Point(500, 200);
            testButton.Size = new Size(80,40);

            button2.Click += new EventHandler(this.Ontest);

  
            Timefield.Text = DateTime.Now.ToString();
            

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void showMessage(object sender, EventArgs e)
        {
            MessageBox.Show("你好！");
        }

        private void Myclick(object sender, EventArgs e)
        {
            MessageBox.Show("hello!");
        }

        public void Ontest(object sender, EventArgs e)
        {
            MessageBox.Show("手动添加函数测试！");
        }

        private void ShowTime(object sender, EventArgs e)
        {
            string timeStr = DateTime.Now.ToString();
            Timefield.Text = timeStr;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
