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
    public partial class garbage_classification : Form
    {
        private Process process;

        public garbage_classification()
        {
            InitializeComponent();
            process = new Process();
            process.StartInfo.FileName = @"D:/Conceal2/python.exe";
            process.StartInfo.Arguments = @"../../../../python_code/waste_classification/main.py";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.CreateNoWindow = true;

            process.Start();
        }

        //关闭进程时，同时关闭python程序
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            process.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg;*.png;*.jpeg)|*.jpg;*.png;*.jpeg";
            openFileDialog.InitialDirectory = @"../../Resources/test_images"; 

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string imagePath = openFileDialog.FileName;
                pictureBox1.Image = new Bitmap(imagePath);
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;  // 保持长宽比
                process.StandardInput.WriteLine(imagePath);

                // 显示"正在分类..."消息
                textBox1.Text = "正在分类...";

                // 使用异步方式来读取结果，以防止UI线程被阻塞
                process.StandardOutput.ReadLineAsync().ContinueWith(t =>
                {
                    if (!t.IsFaulted)
                    {
                        // 使用Invoke方法来更新UI线程上的控件
                        this.Invoke((Action)(() => textBox1.Text = t.Result));
                    }
                });
            }
        }


        private void garbage_classification_Load(object sender, EventArgs e)
        {

        }
    }
}
