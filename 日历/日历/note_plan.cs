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
    public partial class note_plan : Form
    {
        Label explain_today_wing=new Label();
        Label explain_note_wing= new Label();
        Label explain_plan_wing=new Label();
        RichTextBox txt_content = new RichTextBox();
        RichTextBox plan_content=new RichTextBox();
        Button note_change_wing=new Button();
        Button plan_change_wing=new Button();
        string filename_note;
        string filename_plan;
        public note_plan()
        {
            InitializeComponent();
            this.DoubleBuffered = true;//双缓冲
            start_note_plan_all_wing();
            create_note_plan();
            note_change_wing.Click += new EventHandler(this.click_note_change_wing);
            plan_change_wing.Click += new EventHandler(this.click_plan_change_wing);
            this.Text = "笔记和日程";
            this.Size = new Size(600, 680);
        }
        public void click_note_change_wing(object sender, EventArgs e)
        {
            FileStream fs7 = new FileStream(filename_note, FileMode.Open, FileAccess.Write);
            StreamWriter sr7 = new StreamWriter(fs7);
            sr7.WriteLine(txt_content.Text);//写入内容
            sr7.Close();
            fs7.Close();
        }
        public void click_plan_change_wing(object sender, EventArgs e)
        {
            FileStream fs8 = new FileStream(filename_plan, FileMode.Open, FileAccess.Write);
            StreamWriter sr8 = new StreamWriter(fs8);
            sr8.WriteLine(plan_content.Text);//写入内容
            sr8.Close();
            fs8.Close();
        }
        public void start_note_plan_all_wing()
        {
            explain_today_wing.Size = new Size(200, 30);
            explain_today_wing.Text = "当前为" + Form1.user_choose_wing.year_wing.ToString() + "年" + Form1.user_choose_wing.month_wing.ToString() + "月" + Form1.user_choose_wing.day_wing.ToString() + "日";
            this.Controls.Add(explain_today_wing);
            explain_note_wing.Size = new Size(200, 20);
            explain_note_wing.Text = "以下为今日的笔记内容（可编辑）";
            explain_note_wing.Location = new Point(0, 30);
            this.Controls.Add(explain_note_wing);
            explain_plan_wing.Size = new Size(200, 20);
            explain_plan_wing.Text = "以下为今日的日程内容（可编辑）";
            explain_plan_wing.Location = new Point(0, 340);
            this.Controls.Add(explain_plan_wing);
            txt_content.Size = new Size(450, 280);
            txt_content.Location = new Point(0, 50);
            this.Controls.Add(txt_content);
            plan_content.Size = new Size(450, 280);
            plan_content.Location = new Point(0, 360);
            this.Controls.Add(plan_content);
            note_change_wing.Size = new Size(80, 50);
            note_change_wing.Location = new Point(480, 160);
            note_change_wing.Text = "编辑笔记";
            this.Controls.Add(note_change_wing);
            plan_change_wing.Size = new Size(80, 50);
            plan_change_wing.Location = new Point(480, 450);
            plan_change_wing.Text = "编辑日程";
            this.Controls.Add(plan_change_wing);
        }
        public void create_note_plan()
        {
            if (!Directory.Exists(@"D:\calendar\note"))
            {
                Directory.CreateDirectory(@"D:\calendar\note");
            }//创建文件夹note
            if (!Directory.Exists(@"D:\calendar\plan"))
            {
                Directory.CreateDirectory(@"D:\calendar\plan");
            }//创建文件夹plan
            filename_note = @"D:\calendar\note\"+Form1.user_choose_wing.year_wing.ToString() + Form1.user_choose_wing.month_wing.ToString() + Form1.user_choose_wing.day_wing.ToString()+@"note";
            if (!File.Exists(filename_note))
            {
                FileStream fs1 = new FileStream(filename_note, FileMode.Create, FileAccess.Write);//创建写入文件 
                StreamWriter sw = new StreamWriter(fs1);
                sw.WriteLine("已成功新建当日笔记");//开始写入初始值0
                sw.Close();
                fs1.Close();
            }
            filename_plan= @"D:\calendar\plan\"+Form1.user_choose_wing.year_wing.ToString() + Form1.user_choose_wing.month_wing.ToString() + Form1.user_choose_wing.day_wing.ToString() + @"plan";
            if (!File.Exists(filename_plan))
            {
                FileStream fs6 = new FileStream(filename_plan, FileMode.Create, FileAccess.Write);//创建写入文件 
                StreamWriter sw6 = new StreamWriter(fs6);
                sw6.WriteLine("已成功新建当日日程");//开始写入初始值0
                sw6.Close();
                fs6.Close();
            }
            string str2 = File.ReadAllText(filename_note);
            txt_content.Text = str2;
            string str3 = File.ReadAllText(filename_plan);
            plan_content.Text = str3;
        }

    }
}
