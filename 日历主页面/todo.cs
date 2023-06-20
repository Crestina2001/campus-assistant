using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace 日历
{
    public partial class todo : Form
    {
        Button statistics_wing=new Button();
        System.Media.SoundPlayer sndPlayer;
        Timer t_wing;
        public todo()
        {
            InitializeComponent();
            this.DoubleBuffered = true;//双缓冲
            this.BackgroundImage = Resource1.todo;
            this.BackgroundImageLayout = ImageLayout.Stretch;   //设置背景图片自动适应

            this.Text = "番茄时钟";
            label1.Text = "25:00";
            statistics_wing = new Button();
            statistics_wing.Text = "专注次数统计";
            statistics_wing.Location = new Point(200,220);
            statistics_wing.Size = new Size(100, 30);
            this.Controls.Add(statistics_wing);
            create_to_do_wing_folder();
            statistics_wing.Click+= new EventHandler(this.click_statistics_wing);
        }
        public void click_statistics_wing(object sender, EventArgs e)
        {
            tree_show tree_show_wing = new tree_show();

            tree_show_wing.ShowDialog();//展示状态窗体
        }
        public void create_to_do_wing_folder()
        {
            if (!Directory.Exists(@"D:\calendar\to_do"))
            {
                Directory.CreateDirectory(@"D:\calendar\to_do");
            }//创建文件夹
            if (!File.Exists(@"D:\calendar\to_do\live.txt"))
            {
                FileStream fs1 = new FileStream(@"D:\calendar\to_do\live.txt", FileMode.Create, FileAccess.Write);//创建写入文件 
                StreamWriter sw = new StreamWriter(fs1);
                sw.WriteLine("0");//开始写入初始值0
                sw.Close();
                fs1.Close();
            }//创建TXT文件
            if (!File.Exists(@"D:\calendar\to_do\dead.txt"))
            {
                FileStream fs2 = new FileStream(@"D:\calendar\to_do\dead.txt", FileMode.Create, FileAccess.Write);//创建写入文件 
                StreamWriter sw1 = new StreamWriter(fs2);
                sw1.WriteLine("0");//开始写入初始值0
                sw1.Close();
                fs2.Close();
            }//创建TXT文件
        }

        private void button1_Click(object sender, EventArgs e)
        {
            t_wing = new Timer();
            t_wing.Interval = 1000;
            t_wing.Start();//计时器开始
            t_wing.Tick += new EventHandler(t_tick);//定义计时器事件
            string str2 = File.ReadAllText(@"D:\calendar\to_do\dead.txt");
            Form1.dead_num = int.Parse(str2);
            FileStream fs4 = new FileStream(@"D:\calendar\to_do\dead.txt", FileMode.Open, FileAccess.Write);
            StreamWriter sr2 = new StreamWriter(fs4);
            Form1.dead_num++;
            sr2.WriteLine((Form1.dead_num).ToString());//开始写入值
            sr2.Close();
            fs4.Close();//自增一次死亡次数
                        //
            sndPlayer = new System.Media.SoundPlayer(Resource1.iu);
            sndPlayer.Play();//开始播放音乐


        }

        private void button2_Click(object sender, EventArgs e)
        {
            t_wing.Enabled = false;
            sndPlayer.Stop();
                
            Form1.tick_time = 0;
        }
        public void t_tick(object sender, EventArgs e)
        {
            Form1.tick_time++;
            label1.Text=(24-(Form1.tick_time /60)).ToString()+":"+(60- Form1.tick_time%60).ToString();
            if(Form1.tick_time==25*60)//计时到了
            {
                t_wing.Enabled = false;
                string str1 = File.ReadAllText(@"D:\calendar\to_do\live.txt");
                Form1.live_num = int.Parse(str1);
                FileStream fs3 = new FileStream(@"D:\calendar\to_do\live.txt", FileMode.Open, FileAccess.Write);
                StreamWriter sr = new StreamWriter(fs3);
                Form1.live_num++;
                sr.WriteLine(Form1.live_num.ToString());//开始写入值
                sr.Close();
                fs3.Close();//自增一次完成次数
                string str3 = File.ReadAllText(@"D:\calendar\to_do\dead.txt");
                Form1.dead_num = int.Parse(str3);
                FileStream fs5 = new FileStream(@"D:\calendar\to_do\dead.txt", FileMode.Open, FileAccess.Write);
                StreamWriter sr3 = new StreamWriter(fs5);
                Form1.dead_num--;
                sr3.WriteLine(Form1.dead_num.ToString());//开始写入值
                sr3.Close();
                fs5.Close();//自增一次完成次数
            }
        }

        private void todo_wing_Load(object sender, EventArgs e)
        {

        }
    }
}
