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

    public partial class Form1 : Form
    {
        PictureBox[,] date = new PictureBox[6, 7];  //显示日历的小格子
        ComboBox combobox1 = new ComboBox();         //左上角那个选择学期的
        Button click_next = new Button();            //下一个月的button
        Button click_back = new Button();          //上一个月的button
        Button classes_picture_store = new Button();//点击存储课程表的按钮
        Button tomato_todo = new Button();//点击跳转到番茄todo的按钮
        Button learning = new Button();//用于跳转到学习单词板块的按钮
        //段的标签变量
        List<Label> dateLabels = new List<Label>();     //表示日期的标签

        List<Label> weekLabels = new List<Label>();     //显示星期几的标签
        Label monthDisplayer = new Label();             //展示当前年月
        Label show_explain_semester= new Label();//说明选择学期的label
        Label show_explain_web= new Label();//说明选择的网站
        classes_picture_store picture_store = new classes_picture_store();//课程表相关信息
        todo todo_wing = new todo();

      


        Button loginButton = new Button();
        int currentDay = 0;
        bool access = false;

        public static string path;
        public static int tick_time;
        public static int live_num;
        public static int dead_num;
        //public static int a=100;//传递给另一个form的定义必须是静态的
        /*
            this.Hide();//先把当前窗体隐藏
            note_todo_wing note_todo_wing = new note_todo_wing();//定义新的窗体对象
            note_todo_wing.Show();//展示新的窗体
        */ //调用另一个form的方法

        private ComboBox urlList = new ComboBox();  //收藏网页列表

        public class choose_wing
        {
            public int year;   //年
            public int month;  //月
            public int day;    //日
        };//分别存储用户点击的格子对应的年月日



        public static choose_wing user_choose = new choose_wing();//new一个对象(5.20留)

        Image image_wing = Resource1.test;

        public void removeDayLabel()
        {
            for (int i = 0; i < dateLabels.Count(); i++)
            {
                this.Controls.Remove(dateLabels[i]);
            }
        }

        public int isLeap(int year)     //判断闰年
        {
            if (year % 100 != 0)
            {
                if (year % 4 == 0)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                if (year % 400 == 0)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }

        public int Zeller(int year, int month)     //得出某一年的某一个月第一天是星期几
        {
            int week, century, day = 1;
            if (month == 1 || month == 2)
            {
                month = month + 12;
                year = year - 1;
            }
            century = year / 100;
            year = year - 100 * century;
            week = year + year / 4 + century / 4 - 2 * century + 13 * (month + 1) / 5 + day - 1;

            if (week < 0)
            {
                while (week < 0)
                    week = week + 7;
            }
            week = week % 7;
            return week;
        }

        public void initWeekLabels()
        {
            weekLabels.Add(new Label());
            weekLabels[0].Text = "SUN";

            weekLabels.Add(new Label());
            weekLabels[1].Text = "MON";

            weekLabels.Add(new Label());
            weekLabels[2].Text = "TUE";

            weekLabels.Add(new Label());
            weekLabels[3].Text = "WED";

            weekLabels.Add(new Label());
            weekLabels[4].Text = "THU";

            weekLabels.Add(new Label());
            weekLabels[5].Text = "FRI";

            weekLabels.Add(new Label());
            weekLabels[6].Text = "SAT";

            for (int i = 0; i < 7; i++)
            {
                weekLabels[i].BackColor = Color.Transparent;
                weekLabels[i].Location = new Point(88 * i + 270, 145);
                weekLabels[i].Font = new Font("黑体", 20.3f);
                weekLabels[i].Size = new Size(60, 30);
                this.Controls.Add(weekLabels[i]);
            }
        }

        public void timeLabels()                //初始化日期标签
        {
            int IsLeap = isLeap(user_choose.year);
            int monthDays = 0;
            int week = Zeller(user_choose.year, user_choose.month);

            switch (user_choose.month)
            {
                case 1: monthDays = 31; break;
                case 2: monthDays = 28 + IsLeap; break;
                case 3: monthDays = 31; break;
                case 4: monthDays = 30; break;
                case 5: monthDays = 31; break;
                case 6: monthDays = 30; break;
                case 7: monthDays = 31; break;
                case 8: monthDays = 31; break;
                case 9: monthDays = 30; break;
                case 10: monthDays = 31; break;
                case 11: monthDays = 30; break;
                case 12: monthDays = 31; break;
                default: break;
            }

            for (int i = 0; i < monthDays; i++)
            {
                dateLabels.Add(new Label());
                dateLabels[i].Text = (i + 1).ToString();
                //横向90，纵向100
                dateLabels[i].Font = new Font("黑体", 15.3f);
                dateLabels[i].BackColor = Color.Transparent;
                //dateLabels[i].Location = new Point(90 * ((i + week) % 7) + 280, 100 * ((i + week) / 7) + 100);
                dateLabels[i].Location = new Point(90 * ((i + week) % 7) + 280, 90 * ((i + week) / 7) + 200);
                dateLabels[i].Size = new Size(60, 20);
                dateLabels[i].Click += new EventHandler(getLabelDate);
                //当天日期高亮
                if (user_choose.year.ToString().Equals(DateTime.Now.Year.ToString()))
                {
                    if (user_choose.month.ToString().Equals(DateTime.Now.Month.ToString()))
                    {
                        if (i+1==DateTime.Now.Day)
                        {
                            dateLabels[i].Size = new Size(32, 32);
                            dateLabels[i].BackColor = Color.White;
                        }
                    }                         
                }
            }

            monthDisplayer.Text = user_choose.year.ToString() + "年" + user_choose.month.ToString() + "月";
            monthDisplayer.Location = new Point(500, 80);
            monthDisplayer.Font = new Font("黑体", 20.5f);
            monthDisplayer.Size = new Size(160, 50);
            monthDisplayer.BackColor = Color.Transparent;

            for (int i = 0; i < monthDays; i++)
            {
                this.Controls.Add(dateLabels[i]);
            }
            this.Controls.Add(monthDisplayer);
        }

        public void removePic()     //防遮挡用
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    this.Controls.Remove(date[i, j]);
                }
            }
        }
        public void create_folder_wing()
        {
            if (!Directory.Exists(@"D:\calendar"))
            {
                Directory.CreateDirectory(@"D:\calendar");
            }
        }

        public void start_button_wing()     //将控件初始化添加到屏幕中
        {
            //下个月按钮样式调整
            click_next.Size = new Size(70, 70);
            click_next.Location = new Point(925, 350);
            //click_next.Text = "下个月";
            click_next.BackgroundImage = Image.FromFile("D:\\杨政熹大学记录\\大三下学期\\课程文件\\用户交互设计\\final\\HCI_final\\日历\\Resources\\right.png");
            click_next.BackgroundImageLayout = ImageLayout.Zoom;
            click_next.FlatStyle = FlatStyle.Flat;
            click_next.FlatAppearance.BorderSize = 0;
            click_next.BackColor = Color.Transparent;
            click_next.FlatAppearance.MouseOverBackColor = Color.Transparent;
            click_next.FlatAppearance.BorderColor = Color.White;
            this.Controls.Add(click_next);

            //上个月按钮样式调整
            click_back.Size = new Size(70, 70);
            click_back.Location = new Point(135, 350);
            //click_back.Text = "上个月";
            click_back.BackgroundImage = Image.FromFile("D:\\杨政熹大学记录\\大三下学期\\课程文件\\用户交互设计\\final\\HCI_final\\日历\\Resources\\left.png");
            click_back.BackgroundImageLayout = ImageLayout.Zoom;
            click_back.FlatStyle = FlatStyle.Flat;
            click_back.FlatAppearance.BorderSize = 0;
            click_back.BackColor = Color.Transparent;
            click_back.FlatAppearance.MouseOverBackColor = Color.Transparent;
            click_back.FlatAppearance.BorderColor = Color.White;
            this.Controls.Add(click_back);

            //课程表按钮样式调整
            classes_picture_store.Size = new Size(80, 60);
            classes_picture_store.Location = new Point(900, 10);
            //classes_picture_store.Text = "课程表";
            classes_picture_store.TextAlign = ContentAlignment.BottomCenter;
            classes_picture_store.ImageAlign = ContentAlignment.TopCenter;
            classes_picture_store.BackgroundImage = Image.FromFile("D:\\杨政熹大学记录\\大三下学期\\课程文件\\用户交互设计\\final\\HCI_final\\日历\\Resources\\课程表-01.png");
            classes_picture_store.BackgroundImageLayout = ImageLayout.Zoom;
            classes_picture_store.FlatStyle = FlatStyle.Flat;
            classes_picture_store.FlatAppearance.BorderSize = 0;
            classes_picture_store.BackColor = Color.Transparent;
            classes_picture_store.FlatAppearance.MouseOverBackColor = Color.Transparent;
            classes_picture_store.FlatAppearance.BorderColor = Color.White;
            this.Controls.Add(classes_picture_store);

            //番茄时钟按钮样式调整
            tomato_todo.Size = new Size(70, 50);
            tomato_todo.Location = new Point(995, 15);
            //tomato_todo.Text = "番茄时钟";
            tomato_todo.TextAlign = ContentAlignment.BottomCenter;
            tomato_todo.ImageAlign = ContentAlignment.TopCenter;
            tomato_todo.BackgroundImage = Image.FromFile("D:\\杨政熹大学记录\\大三下学期\\课程文件\\用户交互设计\\final\\HCI_final\\日历\\Resources\\闹钟.png");
            tomato_todo.BackgroundImageLayout = ImageLayout.Zoom;
            tomato_todo.FlatStyle = FlatStyle.Flat;
            tomato_todo.FlatAppearance.BorderSize = 0;
            tomato_todo.BackColor = Color.Transparent;
            tomato_todo.FlatAppearance.MouseOverBackColor = Color.Transparent;
            tomato_todo.FlatAppearance.BorderColor = Color.White;
            this.Controls.Add(tomato_todo);


            //背单词按钮样式调整
            learning.Size = new Size(70, 50);
            learning.Location = new Point(1090, 15);
            //learning.Text = "背单词";
            learning.TextAlign = ContentAlignment.BottomCenter;
            learning.ImageAlign = ContentAlignment.TopCenter;
            learning.BackgroundImage = Image.FromFile("D:\\杨政熹大学记录\\大三下学期\\课程文件\\用户交互设计\\final\\HCI_final\\日历\\Resources\\abc.png");
            learning.BackgroundImageLayout = ImageLayout.Zoom;
            learning.FlatStyle = FlatStyle.Flat;
            learning.FlatAppearance.BorderSize = 0;
            learning.BackColor = Color.Transparent;
            learning.FlatAppearance.MouseOverBackColor = Color.Transparent;
            learning.FlatAppearance.BorderColor = Color.White;
            this.Controls.Add(learning);



            show_explain_semester.Size = new Size(200, 30);
            show_explain_semester.Location = new Point(17, 10);
            show_explain_semester.Text = "选择学期";
            show_explain_semester.BackColor = Color.Transparent;
            this.Controls.Add(show_explain_semester);


            show_explain_web.Size=new Size(200, 20);
            show_explain_web.Location = new Point(20, 80);
            show_explain_web.Text = "网站导航";
            show_explain_web.BackColor = Color.Transparent;
            this.Controls.Add(show_explain_web);

            urlList.Location = new Point(20, 100);
            urlList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            urlList.Items.Add("同济大学一块钱");
            urlList.Items.Add("同济大学软件学院官网");
            urlList.Items.Add("同济大学canvas");
            urlList.SelectedIndexChanged += new EventHandler(webJumper);
            this.Controls.Add(urlList);
        }
        public void start_choose()     //默认设置
        {

            user_choose.year = 2023;
            user_choose.month = 6;
            user_choose.day = 1;//默认设置为2023年6月1号
        }
        public void start_combobox1()  //选择学期
        {
            combobox1.Location = new Point(20, 30);
            combobox1.Size = new Size(200, 50);
            combobox1.Items.Add("2023年第一学期");//添加里面的选项
            combobox1.Items.Add("2023年第二学期");
            combobox1.DropDownStyle = ComboBoxStyle.DropDownList;//不能输入内容，只能选择

            this.Controls.Add(combobox1);
        }
        public void start_date()
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    date[i, j] = new PictureBox();
                    date[i, j].Location = new Point(j * 90 + 255, i * 100 + 80);
                    date[i, j].Size = new Size(50, 70);
                    date[i, j].BackColor = Color.Transparent;
                    this.Controls.Add(date[i, j]);
                }
            }
        }
        public Form1()
        {
            InitializeComponent();

            Login();

            if (access)
            {
                this.Size = new Size(1200, 800);//改变窗体的大小
                this.Text = "日历程序";//改窗体的名称S
                this.BackgroundImage = Resource1.main;
                this.BackgroundImageLayout = ImageLayout.Stretch;

              
                
                
                start_combobox1();
                //start_date();
                start_choose();
                start_button_wing();//以上start函数均为初始化函数
                create_folder_wing();
                initWeekLabels();


                timeLabels();
                start_date();

                this.DoubleBuffered = true;//双缓冲

                //调用显示函数
                this.combobox1.SelectedIndexChanged += new System.EventHandler(ComboBox1_SelectedIndexChanged_wing);//添加事件,针对combobox的
                click_next.Click += new EventHandler(this.click_next_wing_event);//点击下个月时的事件
                click_back.Click += new EventHandler(this.click_back_wing_event);//点击上个月时的事件
                classes_picture_store.Click += new EventHandler(this.click_classes_wing);//点击课程表示的事件
                tomato_todo.Click += new EventHandler(this.click_todo_wing);//点击番茄时钟时的事件
                learning.Click += new EventHandler(this.click_learning_wing);//点击背单词的事件
            }
            else
            {
                this.Close();
            }

        }

        public void click_todo_wing(object sender, EventArgs e)
        {
            todo_wing.ShowDialog();//展示番茄时钟的窗体
        }
        public void click_learning_wing(object sender, EventArgs e)
        {
            learning_word learning_yzx = new learning_word();
            learning_yzx.ShowDialog();//展示背单词功能
        }
        public void click_next_wing_event(object sender, EventArgs e)
        {
            if (user_choose.month == 12)
            {
                user_choose.year++;
                user_choose.month = 1;
            }//如果是12月的加1则跳转至下一年并且月份变为1
            else
            {
                user_choose.month++;
            }//月份自增
            removePic();
            removeDayLabel();

            timeLabels();
            start_date();

        }

        public void Login()
        {
            Label account = new Label();
            Label passw = new Label();
            Label notice = new Label();

            TextBox passwEnter = new TextBox();
            TextBox accountEnter = new TextBox();

            account.Location = new Point(60, 130);
            account.Text = "账户";
            account.BackColor = Color.Transparent;

            passw.Location = new Point(60, 160);
            passw.Text = "密码";
            passw.BackColor = Color.Transparent;

            notice.Text = "日历登录界面";
            notice.Font = new Font("黑体", 15.3f);
            notice.Size = new Size(200, 50);
            notice.Location = new Point(120, 20);
            notice.BackColor = Color.Transparent;

            this.Size = new Size(400, 400);

            loginButton.Location = new Point(300, 200);
            loginButton.Text = "登录";
            loginButton.Click += new EventHandler(loginClick);

            accountEnter.Location = new Point(90, 130);
            accountEnter.Size = new Size(200, 20);

            passwEnter.PasswordChar = '*';
            passwEnter.Location = new Point(90, 160);
            passwEnter.Size = new Size(200, 20);

            this.BackgroundImage = Resource1.login;
            this.BackgroundImageLayout = ImageLayout.Stretch;//设置背景图片自动适应

            this.Controls.Add(loginButton);
            this.Controls.Add(accountEnter);
            this.Controls.Add(passwEnter);
            this.Controls.Add(account);
            this.Controls.Add(passw);
            this.Controls.Add(notice);



            this.ShowDialog();

            this.Controls.Remove(loginButton);
            this.Controls.Remove(accountEnter);
            this.Controls.Remove(passwEnter);
            this.Controls.Remove(account);
            this.Controls.Remove(passw);
            this.Controls.Remove(notice);

        }

        public void click_back_wing_event(object sender, EventArgs e)
        {
            if (user_choose.month == 1)
            {
                user_choose.year--;
                user_choose.month = 12;
            }//如果是1月的减1则跳转至上一年并且月份变为12
            else
            {
                user_choose.month--;
            }//月份自减
            removePic();
            removeDayLabel();

            timeLabels();
            start_date();
        }
        public void click_classes_wing(object sender, EventArgs e)
        {
            picture_store.ShowDialog();//展示课程表窗体
        }
        private void ComboBox1_SelectedIndexChanged_wing(object sender, System.EventArgs e)//事件对应的用户选择的改变
        {
            string input_semester_wing = (string)combobox1.SelectedItem;//得到用户选择的是什么
            if (input_semester_wing == "2023年第一学期")
            {
                user_choose.year = 2022;
                user_choose.month = 10;
                user_choose.day = 1;
            }
            else if (input_semester_wing == "2023年第二学期")
            {
                user_choose.year = 2023;
                user_choose.month = 6;
                user_choose.day = 1;
            }
            removePic();
            removeDayLabel();
            timeLabels();
            start_date();
            //判断用户选择并传参
            //修改choose_wing类中数字
        }
        private void webJumper(object sender, EventArgs e)
        {
            ComboBox tmp = (ComboBox)sender;

            if (tmp.Text == "同济大学软件学院官网")
                System.Diagnostics.Process.Start("https://sse.tongji.edu.cn/");
            if (tmp.Text == "同济大学一块钱")
                System.Diagnostics.Process.Start("https://1.tongji.edu.cn/workbench");
            if (tmp.Text == "同济大学canvas")
                System.Diagnostics.Process.Start("http://canvas.tongji.edu.cn/");
        }
        private void loginClick(object sender, EventArgs e)
        {
            this.Close();
            access = true;
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void getLabelDate(object sender, EventArgs e)
        {
            Label tmp = (Label)sender;

            if (currentDay.ToString() != tmp.Text)
            {
                int date = 0;                                      //目标楼层                                  
                for (int i = 0; i < tmp.Text.Length; i++) //根据传入的按钮计算出目标楼层
                    date = date * 10 + (tmp.Text[i] - '0');
                

                user_choose.day = date;
                currentDay = date;
                note_plan note_plan_wing = new note_plan();
                note_plan_wing.ShowDialog();
            }
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void monthCalendar1_DateChanged_1(object sender, DateRangeEventArgs e)
        {

        }
    }
}
