using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }



        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            // 创建 NoteForm，并传入选定的日期
            NoteForm noteForm = new NoteForm(e.Start);

            // 显示 NoteForm
            noteForm.ShowDialog();

        }


        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            learning_word learning_wordForm = new learning_word();
            learning_wordForm.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            classes_picture_store classes_picture_storeForm = new classes_picture_store();
            classes_picture_storeForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // 创建 timeStatistic 的实例
            timeStatistic timeStatisticForm = new timeStatistic();

            // 显示 timeStatistic 窗口
            timeStatisticForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string pythonInterpreterPath = @"D:/Conceal2/python.exe";
            string pythonScriptPath = @"../../../../python_code/focus_yolov8/main.py";

            // 创建新的进程启动信息
            System.Diagnostics.ProcessStartInfo myProcessStartInfo = new System.Diagnostics.ProcessStartInfo(pythonInterpreterPath);

            // 以脚本路径作为命令行参数启动 Python 应用程序
            myProcessStartInfo.Arguments = pythonScriptPath;

            System.Diagnostics.Process myProcess = new System.Diagnostics.Process();
            // 将启动信息分配给进程
            myProcess.StartInfo = myProcessStartInfo;

            // 启动进程
            myProcess.Start();
        }


        private void button5_Click(object sender, EventArgs e)
        {
            // 创建 timeStatistic 的实例
            garbage_classification garbage_classificationForm = new garbage_classification();

            // 显示 timeStatistic 窗口
            garbage_classificationForm.Show();
        }

    }
}
