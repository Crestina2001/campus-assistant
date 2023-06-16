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
    public partial class tree_show : Form
    {
        Image live_tree_wing = Resource1.live_tree;
        Image dead_tree_wing = Resource1.dead_tree;
        PictureBox[] live_pic_wing = new PictureBox[10];//活着的树的数组
        PictureBox[] dead_pic_wing = new PictureBox[10];
        public tree_show()
        {
            InitializeComponent();
            this.DoubleBuffered = true;//双缓冲
            this.BackgroundImage = Resource1.tree;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            string str1 = File.ReadAllText(@"D:\calendar\to_do\live.txt");
            Form1.live_num = int.Parse(str1);
            string str3 = File.ReadAllText(@"D:\calendar\to_do\dead.txt");
            Form1.dead_num = int.Parse(str3);
            start_wing();
            put_picture_wing();
            this.Text = "专注结果显示";
            this.Size = new Size(1000, 600);
        }
        public void start_wing()
        {
            Label explain_wing=new Label();
            explain_wing.BackColor = Color.Transparent;
            explain_wing.Size = new Size(500, 50);
            explain_wing.Text = "已完成的专注次数为"+Form1.live_num.ToString()+"  未完成的专注次数为"+Form1.dead_num.ToString();
            this.Controls.Add(explain_wing);
            for(int i=0;i<10;i++)
            {
                live_pic_wing[i] = new PictureBox();
                live_pic_wing[i].Size=new Size(100, 200);
                live_pic_wing[i].Location = new Point(i * 100, 50);
                live_pic_wing[i].SizeMode = PictureBoxSizeMode.StretchImage;
                live_pic_wing[i].BackColor = Color.Transparent;
                this.Controls.Add(live_pic_wing[i]);
                dead_pic_wing[i] = new PictureBox();
                dead_pic_wing[i].Size = new Size(100, 200);
                dead_pic_wing[i].Location = new Point(i * 100, 300);
                dead_pic_wing[i].SizeMode = PictureBoxSizeMode.StretchImage;
                dead_pic_wing[i].BackColor = Color.Transparent;
                this.Controls.Add(dead_pic_wing[i]);
            }
        }
        public void put_picture_wing()
        {
            for(int i=0;i<Form1.live_num&&i<10;i++)
            {
                live_pic_wing[i].Image = live_tree_wing;
            }
            for (int i = 0; i < Form1.dead_num && i < 10; i++)
            {
                dead_pic_wing[i].Image = dead_tree_wing;
            }
        }

        private void tree_show_wing_Load(object sender, EventArgs e)
        {

        }
    }
}
