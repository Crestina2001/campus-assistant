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


namespace WindowsFormsApp1
{
    public partial class NoteForm : Form
    {
        private DateTime selectedDate;
        // 添加一个带参数的构造函数
        public NoteForm(DateTime selectedDate)
        {
            InitializeComponent();

            this.selectedDate = selectedDate;

            // 读取选定日期的备忘录，并显示在 richTextBox1 中
            richTextBox1.Text = ReadMemo(selectedDate);
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 获取 richTextBox1 中的文本
            string memo = richTextBox1.Text;

            // 保存备忘录
            WriteMemo(selectedDate, memo);

            // 可选：显示一个消息框，通知用户备忘录已保存
            MessageBox.Show("备忘录已保存。");

            // 可选：关闭 NoteForm
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void NoteForm_Load(object sender, EventArgs e)
        {

        }


        string baseDirectory = "..\\..\\database\\memo";


        // 写入备忘录的函数
        public void WriteMemo(DateTime date, string memo)
        {
            // 为备忘录文件创建一个文件名
            string fileName = "note_" + date.ToString("yyyy_MM_dd") + ".txt";
            string filePath = Path.Combine(baseDirectory, fileName);

            // 写入备忘录
            File.WriteAllText(filePath, memo);
        }

        // 读取备忘录的函数
        public string ReadMemo(DateTime date)
        {
            // 获取备忘录文件的路径
            string fileName = "note_" + date.ToString("yyyy_MM_dd") + ".txt";
            string filePath = Path.Combine(baseDirectory, fileName);

            // 如果文件存在，读取备忘录
            if (File.Exists(filePath))
            {
                return File.ReadAllText(filePath);
            }
            // 如果文件不存在，返回null或其他适当的值
            else
            {
                return null;
            }
        }

    }
}
