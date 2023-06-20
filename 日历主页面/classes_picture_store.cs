using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace 日历
{
    public partial class classes_picture_store : Form
    {
        public PictureBox classes_picture=new PictureBox();
        public classes_picture_store()
        {
            InitializeComponent();
            this.DoubleBuffered = true;//双缓冲
            this.Text = "课程表";
            this.Size = new Size(800, 600);//改变窗体的大小
            this.BackgroundImage = Image.FromFile("calendar\\resource\\课程表.jpg");
            this.BackgroundImageLayout = ImageLayout.Stretch;
            classes_picture.BackColor = Color.Transparent;
            classes_picture.Size = new Size(700, 400);
            classes_picture.Location = new Point(50, 150);
            classes_picture.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Controls.Add(classes_picture);
        }


        private void classes_picture_store_Load(object sender, EventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1.path=textBox1.Text;
            if (File.Exists(Form1.path))
            {
                classes_picture.Image = Image.FromFile(Form1.path);
            }
            else
            {
                MessageBox.Show("请输入正确的路径","错误提示");
            }
        }
    }
}
