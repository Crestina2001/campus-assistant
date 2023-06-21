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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Runtime;
using static System.Windows.Forms.AxHost;
using System.Text.RegularExpressions;
using static System.Windows.Forms.LinkLabel;
using System.Drawing.Design;
using System.Runtime.Remoting.Messaging;
using System.IO.Pipes;

namespace WindowsFormsApp1
{
    public partial class classes_picture_store : Form
    {
       
       
        public PictureBox classes_picture = new PictureBox();
        public classes_picture_store()
        {
            InitializeComponent();
            this.DoubleBuffered = true;//双缓冲
            this.Text = "课程表";
            this.Size = new Size(1000, 600);//改变窗体的大小
            classes_picture.BackColor = Color.Transparent;
            classes_picture.Size = new Size(900, 500);
            classes_picture.Location = new Point(50, 150);
            classes_picture.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Controls.Add(classes_picture);
            
        }
        public String[] filePath = new String[]
        {
            //Monday
            "../../database/curriculum/course1_1_name.txt",
            "../../database/curriculum/course1_1_teacher.txt",
            "../../database/curriculum/course1_1_location.txt",

            "../../database/curriculum/course1_2_name.txt",
            "../../database/curriculum/course1_2_teacher.txt",
            "../../database/curriculum/course1_2_location.txt",

            "../../database/curriculum/course1_3_name.txt",
            "../../database/curriculum/course1_3_teacher.txt",
            "../../database/curriculum/course1_3_location.txt",

            "../../database/curriculum/course1_4_name.txt",
            "../../database/curriculum/course1_4_teacher.txt",
            "../../database/curriculum/course1_4_location.txt",

            "../../database/curriculum/course1_5_name.txt",
            "../../database/curriculum/course1_5_teacher.txt",
            "../../database/curriculum/course1_5_location.txt",

            //Tuesday
            "../../database/curriculum/course2_1_name.txt",
            "../../database/curriculum/course2_1_teacher.txt",
            "../../database/curriculum/course2_1_location.txt",

            "../../database/curriculum/course2_2_name.txt",
            "../../database/curriculum/course2_2_teacher.txt",
            "../../database/curriculum/course2_2_location.txt",

            "../../database/curriculum/course2_3_name.txt",
            "../../database/curriculum/course2_3_teacher.txt",
            "../../database/curriculum/course2_3_location.txt",

            "../../database/curriculum/course2_4_name.txt",
            "../../database/curriculum/course2_4_teacher.txt",
            "../../database/curriculum/course2_4_location.txt",

            "../../database/curriculum/course2_5_name.txt",
            "../../database/curriculum/course2_5_teacher.txt",
            "../../database/curriculum/course2_5_location.txt",

            //Wednesday
            "../../database/curriculum/course3_1_name.txt",
            "../../database/curriculum/course3_1_teacher.txt",
            "../../database/curriculum/course3_1_location.txt",

            "../../database/curriculum/course3_2_name.txt",
            "../../database/curriculum/course3_2_teacher.txt",
            "../../database/curriculum/course3_2_location.txt",

            "../../database/curriculum/course3_3_name.txt",
            "../../database/curriculum/course3_3_teacher.txt",
            "../../database/curriculum/course3_3_location.txt",

            "../../database/curriculum/course3_4_name.txt",
            "../../database/curriculum/course3_4_teacher.txt",
            "../../database/curriculum/course3_4_location.txt",

            "../../database/curriculum/course3_5_name.txt",
            "../../database/curriculum/course3_5_teacher.txt",
            "../../database/curriculum/course3_5_location.txt",

            //Thursday
            "../../database/curriculum/course4_1_name.txt",
            "../../database/curriculum/course4_1_teacher.txt",
            "../../database/curriculum/course4_1_location.txt",

            "../../database/curriculum/course4_2_name.txt",
            "../../database/curriculum/course4_2_teacher.txt",
            "../../database/curriculum/course4_2_location.txt",

            "../../database/curriculum/course4_3_name.txt",
            "../../database/curriculum/course4_3_teacher.txt",
            "../../database/curriculum/course4_3_location.txt",

            "../../database/curriculum/course4_4_name.txt",
            "../../database/curriculum/course4_4_teacher.txt",
            "../../database/curriculum/course4_4_location.txt",

            "../../database/curriculum/course4_5_name.txt",
            "../../database/curriculum/course4_5_teacher.txt",
            "../../database/curriculum/course4_5_location.txt",

            //Friday
            "../../database/curriculum/course5_1_name.txt",
            "../../database/curriculum/course5_1_teacher.txt",
            "../../database/curriculum/course5_1_location.txt",

            "../../database/curriculum/course5_2_name.txt",
            "../../database/curriculum/course5_2_teacher.txt",
            "../../database/curriculum/course5_2_location.txt",

            "../../database/curriculum/course5_3_name.txt",
            "../../database/curriculum/course5_3_teacher.txt",
            "../../database/curriculum/course5_3_location.txt",

            "../../database/curriculum/course5_4_name.txt",
            "../../database/curriculum/course5_4_teacher.txt",
            "../../database/curriculum/course5_4_location.txt",

            "../../database/curriculum/course5_5_name.txt",
            "../../database/curriculum/course5_5_teacher.txt",
            "../../database/curriculum/course5_5_location.txt",
        };
        
        private void classes_picture_store_Load(object sender, EventArgs e)
        {
            //0-0-0
            if (File.Exists(filePath[0]))
            {
                string content = File.ReadAllText(filePath[0]);
                course1_1_name.Text = content;
            }
            else
            {
                // 文件不存在时的操作
                // 创建文件并进行处理
                File.Create(filePath[0]).Close();
            }
            //0-0-1
            if (File.Exists(filePath[1]))
            {
                string content = File.ReadAllText(filePath[1]);
                course1_1_teacher.Text = content;
            }
            else
            {
                File.Create(filePath[1]).Close();
            }
            //0-0-2
            if (File.Exists(filePath[2]))
            {
                string content = File.ReadAllText(filePath[2]);
                course1_1_location.Text = content;
            }
            else
            {
                File.Create(filePath[2]).Close();
            }

            //0-1-0
            if (File.Exists(filePath[3]))
            {
                string content = File.ReadAllText(filePath[3]);
                course1_2_name.Text = content;
            }
            else
            {
                File.Create(filePath[3]).Close();
            }
            //0-1-1
            if (File.Exists(filePath[4]))
            {
                string content = File.ReadAllText(filePath[4]);
                course1_2_teacher.Text = content;
            }
            else
            {
                File.Create(filePath[4]).Close();
            }
            //0-1-2 
            if (File.Exists(filePath[5]))
            {
                string content = File.ReadAllText(filePath[5]);
                course1_2_location.Text = content;
            }
            else
            {
                File.Create(filePath[5]).Close();
            }

            //0-2-0
            if (File.Exists(filePath[6]))
            {
                string content = File.ReadAllText(filePath[6]);
                course1_3_name.Text = content;
            }
            else
            {
                File.Create(filePath[6]).Close();
            }
            //0-2-1
            if (File.Exists(filePath[7]))
            {
                string content = File.ReadAllText(filePath[7]);
                course1_3_teacher.Text = content;
            }
            else
            {
                File.Create(filePath[7]).Close();
            }
            //0-2-2 
            if (File.Exists(filePath[8]))
            {
                string content = File.ReadAllText(filePath[8]);
                course1_3_location.Text = content;
            }
            else
            {
                File.Create(filePath[8]).Close();
            }

            //0-3-0
            if (File.Exists(filePath[9]))
            {
                string content = File.ReadAllText(filePath[9]);
                course1_4_name.Text = content;
            }
            else
            {
                File.Create(filePath[9]).Close();
            }
            //0-3-1
            if (File.Exists(filePath[10]))
            {
                string content = File.ReadAllText(filePath[10]);
                course1_4_teacher.Text = content;
            }
            else
            {
                File.Create(filePath[10]).Close();
            }
            //0-3-2 
            if (File.Exists(filePath[11]))
            {
                string content = File.ReadAllText(filePath[11]);
                course1_4_location.Text = content;
            }
            else
            {
                File.Create(filePath[11]).Close();
            }
            //0-4-0
            if (File.Exists(filePath[12]))
            {
                string content = File.ReadAllText(filePath[12]);
                course1_5_name.Text = content;
            }
            else
            {
                File.Create(filePath[12]).Close();
            }
            //0-4-1
            if (File.Exists(filePath[13]))
            {
                string content = File.ReadAllText(filePath[13]);
                course1_5_teacher.Text = content;
            }
            else
            {
                File.Create(filePath[13]).Close();
            }
            //0-4-2 
            if (File.Exists(filePath[14]))
            {
                string content = File.ReadAllText(filePath[14]);
                course1_5_location.Text = content;
            }
            else
            {
                File.Create(filePath[14]).Close();
            }
            //1-0-0
            if (File.Exists(filePath[15]))
            {
                string content = File.ReadAllText(filePath[15]);
                course2_1_name.Text = content;
            }
            else
            {
                File.Create(filePath[15]).Close();
            }
            //1-0-1
            if (File.Exists(filePath[16]))
            {
                string content = File.ReadAllText(filePath[16]);
                course2_1_teacher.Text = content;
            }
            else
            {
                File.Create(filePath[16]).Close();
            }
            //1-0-2
            if (File.Exists(filePath[17]))
            {
                string content = File.ReadAllText(filePath[17]);
                course2_1_location.Text = content;
            }
            else
            {
                File.Create(filePath[17]).Close();
            }

            //1-1-0
            if (File.Exists(filePath[18]))
            {
                string content = File.ReadAllText(filePath[18]);
                course2_2_name.Text = content;
            }
            else
            {
                File.Create(filePath[18]).Close();
            }
            //1-1-1
            if (File.Exists(filePath[19]))
            {
                string content = File.ReadAllText(filePath[19]);
                course2_2_teacher.Text = content;
            }
            else
            {
                File.Create(filePath[19]).Close();
            }
            //1-1-2 
            if (File.Exists(filePath[20]))
            {
                string content = File.ReadAllText(filePath[20]);
                course2_2_location.Text = content;
            }
            else
            {
                File.Create(filePath[20]).Close();
            }

            //1-2-0
            if (File.Exists(filePath[21]))
            {
                string content = File.ReadAllText(filePath[21]);
                course2_3_name.Text = content;
            }
            else
            {
                File.Create(filePath[21]).Close();
            }
            //1-2-1
            if (File.Exists(filePath[22]))
            {
                string content = File.ReadAllText(filePath[22]);
                course2_3_teacher.Text = content;
            }
            else
            {
                File.Create(filePath[22]).Close();
            }
            //1-2-2 
            if (File.Exists(filePath[23]))
            {
                string content = File.ReadAllText(filePath[23]);
                course2_3_location.Text = content;
            }
            else
            {
                File.Create(filePath[23]).Close();
            }

            //1-3-0
            if (File.Exists(filePath[24]))
            {
                string content = File.ReadAllText(filePath[24]);
                course2_4_name.Text = content;
            }
            else
            {
                File.Create(filePath[24]).Close();
            }
            //1-3-1
            if (File.Exists(filePath[25]))
            {
                string content = File.ReadAllText(filePath[25]);
                course2_4_teacher.Text = content;
            }
            else
            {
                File.Create(filePath[25]).Close();
            }
            //1-3-2 
            if (File.Exists(filePath[26]))
            {
                string content = File.ReadAllText(filePath[26]);
                course2_4_location.Text = content;
            }
            else
            {
                File.Create(filePath[26]).Close();
            }
            //1-4-0
            if (File.Exists(filePath[27]))
            {
                string content = File.ReadAllText(filePath[27]);
                course2_5_name.Text = content;
            }
            else
            {
                File.Create(filePath[27]).Close();
            }
            //1-4-1
            if (File.Exists(filePath[28]))
            {
                string content = File.ReadAllText(filePath[28]);
                course2_5_teacher.Text = content;
            }
            else
            {
                File.Create(filePath[28]).Close();
            }
            //1-4-2 
            if (File.Exists(filePath[29]))
            {
                string content = File.ReadAllText(filePath[29]);
                course2_5_location.Text = content;
            }
            else
            {
                File.Create(filePath[29]).Close();
            }
            //2-0-0
            if (File.Exists(filePath[30]))
            {
                string content = File.ReadAllText(filePath[30]);
                course3_1_name.Text = content;
            }
            else
            {
                File.Create(filePath[30]).Close();
            }
            //2-0-1
            if (File.Exists(filePath[31]))
            {
                string content = File.ReadAllText(filePath[31]);
                course3_1_teacher.Text = content;
            }
            else
            {
                File.Create(filePath[31]).Close();
            }
            //2-0-2
            if (File.Exists(filePath[32]))
            {
                string content = File.ReadAllText(filePath[32]);
                course3_1_location.Text = content;
            }
            else
            {
                File.Create(filePath[32]).Close();
            }

            //2-1-0
            if (File.Exists(filePath[33]))
            {
                string content = File.ReadAllText(filePath[33]);
                course3_2_name.Text = content;
            }
            else
            {
                File.Create(filePath[33]).Close();
            }
            //2-1-1
            if (File.Exists(filePath[34]))
            {
                string content = File.ReadAllText(filePath[34]);
                course3_2_teacher.Text = content;
            }
            else
            {
                File.Create(filePath[34]).Close();
            }
            //2-1-2 
            if (File.Exists(filePath[35]))
            {
                string content = File.ReadAllText(filePath[35]);
                course3_2_location.Text = content;
            }
            else
            {
                File.Create(filePath[35]).Close();
            }

            //2-2-0
            if (File.Exists(filePath[36]))
            {
                string content = File.ReadAllText(filePath[36]);
                course3_3_name.Text = content;
            }
            else
            {
                File.Create(filePath[36]).Close();
            }
            //2-2-1
            if (File.Exists(filePath[37]))
            {
                string content = File.ReadAllText(filePath[37]);
                course3_3_teacher.Text = content;
            }
            else
            {
                File.Create(filePath[37]).Close();
            }
            //2-2-2 
            if (File.Exists(filePath[38]))
            {
                string content = File.ReadAllText(filePath[38]);
                course3_3_location.Text = content;
            }
            else
            {
                File.Create(filePath[38]).Close();
            }

            //2-3-0
            if (File.Exists(filePath[39]))
            {
                string content = File.ReadAllText(filePath[39]);
                course3_4_name.Text = content;
            }
            else
            {
                File.Create(filePath[39]).Close();
            }
            //2-3-1
            if (File.Exists(filePath[40]))
            {
                string content = File.ReadAllText(filePath[40]);
                course3_4_teacher.Text = content;
            }
            else
            {
                File.Create(filePath[40]).Close();
            }
            //2-3-2 
            if (File.Exists(filePath[41]))
            {
                string content = File.ReadAllText(filePath[41]);
                course3_4_location.Text = content;
            }
            else
            {
                File.Create(filePath[41]).Close();
            }
            //2-4-0
            if (File.Exists(filePath[42]))
            {
                string content = File.ReadAllText(filePath[42]);
                course3_5_name.Text = content;
            }
            else
            {
                File.Create(filePath[42]).Close();
            }
            //2-4-1
            if (File.Exists(filePath[43]))
            {
                string content = File.ReadAllText(filePath[43]);
                course3_5_teacher.Text = content;
            }
            else
            {
                File.Create(filePath[43]).Close();
            }
            //2-4-2 
            if (File.Exists(filePath[44]))
            {
                string content = File.ReadAllText(filePath[44]);
                course3_5_location.Text = content;
            }
            else
            {
                File.Create(filePath[44]).Close();
            }
            //3-0-0
            if (File.Exists(filePath[45]))
            {
                string content = File.ReadAllText(filePath[45]);
                course4_1_name.Text = content;
            }
            else
            {
                File.Create(filePath[45]).Close();
            }
            //3-0-1
            if (File.Exists(filePath[46]))
            {
                string content = File.ReadAllText(filePath[46]);
                course4_1_teacher.Text = content;
            }
            else
            {
                File.Create(filePath[46]).Close();
            }
            //3-0-2
            if (File.Exists(filePath[47]))
            {
                string content = File.ReadAllText(filePath[47]);
                course4_1_location.Text = content;
            }
            else
            {
                File.Create(filePath[47]).Close();
            }

            //3-1-0
            if (File.Exists(filePath[48]))
            {
                string content = File.ReadAllText(filePath[48]);
                course4_2_name.Text = content;
            }
            else
            {
                File.Create(filePath[48]).Close();
            }
            //3-1-1
            if (File.Exists(filePath[49]))
            {
                string content = File.ReadAllText(filePath[49]);
                course4_2_teacher.Text = content;
            }
            else
            {
                File.Create(filePath[49]).Close();
            }
            //3-1-2 
            if (File.Exists(filePath[50]))
            {
                string content = File.ReadAllText(filePath[50]);
                course4_2_location.Text = content;
            }
            else
            {
                File.Create(filePath[50]).Close();
            }

            //3-2-0
            if (File.Exists(filePath[51]))
            {
                string content = File.ReadAllText(filePath[51]);
                course4_3_name.Text = content;
            }
            else
            {
                File.Create(filePath[51]).Close();
            }
            //3-2-1
            if (File.Exists(filePath[52]))
            {
                string content = File.ReadAllText(filePath[52]);
                course4_3_teacher.Text = content;
            }
            else
            {
                File.Create(filePath[52]).Close();
            }
            //3-2-2 
            if (File.Exists(filePath[53]))
            {
                string content = File.ReadAllText(filePath[53]);
                course4_3_location.Text = content;
            }
            else
            {
                File.Create(filePath[53]).Close();
            }

            //3-3-0
            if (File.Exists(filePath[54]))
            {
                string content = File.ReadAllText(filePath[54]);
                course4_4_name.Text = content;
            }
            else
            {
                File.Create(filePath[54]).Close();
            }
            //3-3-1
            if (File.Exists(filePath[55]))
            {
                string content = File.ReadAllText(filePath[55]);
                course4_4_teacher.Text = content;
            }
            else
            {
                File.Create(filePath[55]).Close();
            }
            //3-3-2 
            if (File.Exists(filePath[56]))
            {
                string content = File.ReadAllText(filePath[56]);
                course4_4_location.Text = content;
            }
            else
            {
                File.Create(filePath[56]).Close();
            }
            //3-4-0
            if (File.Exists(filePath[57]))
            {
                string content = File.ReadAllText(filePath[57]);
                course4_5_name.Text = content;
            }
            else
            {
                File.Create(filePath[57]).Close();
            }
            //3-4-1
            if (File.Exists(filePath[58]))
            {
                string content = File.ReadAllText(filePath[58]);
                course4_5_teacher.Text = content;
            }
            else
            {
                File.Create(filePath[58]).Close();
            }
            //3-4-2 
            if (File.Exists(filePath[59]))
            {
                string content = File.ReadAllText(filePath[59]);
                course4_5_location.Text = content;
            }
            else
            {
                File.Create(filePath[59]).Close();
            }
            //4-0-0
            if (File.Exists(filePath[60]))
            {
                string content = File.ReadAllText(filePath[60]);
                course5_1_name.Text = content;
            }
            else
            {
                File.Create(filePath[60]).Close();
            }
            //4-0-1
            if (File.Exists(filePath[61]))
            {
                string content = File.ReadAllText(filePath[61]);
                course5_1_teacher.Text = content;
            }
            else
            {
                File.Create(filePath[61]).Close();
            }
            //4-0-2
            if (File.Exists(filePath[62]))
            {
                string content = File.ReadAllText(filePath[62]);
                course5_1_location.Text = content;
            }
            else
            {
                File.Create(filePath[62]).Close();
            }

            //4-1-0
            if (File.Exists(filePath[63]))
            {
                string content = File.ReadAllText(filePath[63]);
                course5_2_name.Text = content;
            }
            else
            {
                File.Create(filePath[63]).Close();
            }
            //4-1-1
            if (File.Exists(filePath[64]))
            {
                string content = File.ReadAllText(filePath[64]);
                course5_2_teacher.Text = content;
            }
            else
            {
                File.Create(filePath[64]).Close();
            }
            //4-1-2 
            if (File.Exists(filePath[65]))
            {
                string content = File.ReadAllText(filePath[65]);
                course5_2_location.Text = content;
            }
            else
            {
                File.Create(filePath[65]).Close();
            }

            //4-2-0
            if (File.Exists(filePath[66]))
            {
                string content = File.ReadAllText(filePath[66]);
                course5_3_name.Text = content;
            }
            else
            {
                File.Create(filePath[66]).Close();
            }
            //4-2-1
            if (File.Exists(filePath[67]))
            {
                string content = File.ReadAllText(filePath[67]);
                course5_3_teacher.Text = content;
            }
            else
            {
                File.Create(filePath[67]).Close();
            }
            //4-2-2 
            if (File.Exists(filePath[68]))
            {
                string content = File.ReadAllText(filePath[68]);
                course5_3_location.Text = content;
            }
            else
            {
                File.Create(filePath[68]).Close();
            }

            //4-3-0
            if (File.Exists(filePath[69]))
            {
                string content = File.ReadAllText(filePath[69]);
                course5_4_name.Text = content;
            }
            else
            {
                File.Create(filePath[69]).Close();
            }
            //4-3-1
            if (File.Exists(filePath[70]))
            {
                string content = File.ReadAllText(filePath[70]);
                course5_4_teacher.Text = content;
            }
            else
            {
                File.Create(filePath[70]).Close();
            }
            //4-3-2 
            if (File.Exists(filePath[71]))
            {
                string content = File.ReadAllText(filePath[71]);
                course5_4_location.Text = content;
            }
            else
            {
                File.Create(filePath[71]).Close();
            }
            //4-4-0
            if (File.Exists(filePath[72]))
            {
                string content = File.ReadAllText(filePath[72]);
                course5_5_name.Text = content;
            }
            else
            {
                File.Create(filePath[72]).Close();
            }
            //4-4-1
            if (File.Exists(filePath[73]))
            {
                string content = File.ReadAllText(filePath[73]);
                course5_5_teacher.Text = content;
            }
            else
            {
                File.Create(filePath[73]).Close();
            }
            //4-4-2 
            if (File.Exists(filePath[74]))
            {
                string content = File.ReadAllText(filePath[74]);
                course5_5_location.Text = content;
            }
            else
            {
                File.Create(filePath[74]).Close();
            }
        }
        private void Write_In_Button_Click(object sender, EventArgs e)
        {
            string content;
            // 使用 using 语句块自动关闭文件流
            //0-0-0
            content = course1_1_name.Text;
            using (StreamWriter sw = new StreamWriter(filePath[0]))
            {
                sw.Write(content);
            }
            //0-0-1
            content = course1_1_teacher.Text;
            using (StreamWriter sw = new StreamWriter(filePath[1]))
            {
                sw.Write(content);
            }
            //0-0-2
            content = course1_1_location.Text;
            using (StreamWriter sw = new StreamWriter(filePath[2]))
            {
                sw.Write(content);
            }

            //0-1-0
            content = course1_2_name.Text;
            using (StreamWriter sw = new StreamWriter(filePath[3]))
            {
                sw.Write(content);
            }
            //0-1-1
            content = course1_2_teacher.Text;
            using (StreamWriter sw = new StreamWriter(filePath[4]))
            {
                sw.Write(content);
            }
            //0-1-2 
            content = course1_2_location.Text;
            using (StreamWriter sw = new StreamWriter(filePath[5]))
            {
                sw.Write(content);
            }

            //0-2-0
            content = course1_3_name.Text;
            using (StreamWriter sw = new StreamWriter(filePath[6]))
            {
                sw.Write(content);
            }
            //0-2-1
            content = course1_3_teacher.Text;
            using (StreamWriter sw = new StreamWriter(filePath[7]))
            {
                sw.Write(content);
            }
            //0-2-2 
            content = course1_3_location.Text;
            using (StreamWriter sw = new StreamWriter(filePath[8]))
            {
                sw.Write(content);
            }

            //0-3-0
            content = course1_4_name.Text;
            using (StreamWriter sw = new StreamWriter(filePath[9]))
            {
                sw.Write(content);
            }
            //0-3-1
            content = course1_4_teacher.Text;
            using (StreamWriter sw = new StreamWriter(filePath[10]))
            {
                sw.Write(content);
            }
            //0-3-2 
            content = course1_4_location.Text;
            using (StreamWriter sw = new StreamWriter(filePath[11]))
            {
                sw.Write(content);
            }
            //0-4-0
            content = course1_5_name.Text;
            using (StreamWriter sw = new StreamWriter(filePath[12]))
            {
                sw.Write(content);
            }
            //0-4-1
            content = course1_5_teacher.Text;
            using (StreamWriter sw = new StreamWriter(filePath[13]))
            {
                sw.Write(content);
            }
            //0-4-2 
            content = course1_5_location.Text;
            using (StreamWriter sw = new StreamWriter(filePath[14]))
            {
                sw.Write(content);
            }
           //1-0-0
            content = course2_1_name.Text;
            using (StreamWriter sw = new StreamWriter(filePath[15]))
            {
                sw.Write(content); 
            }
            //1-0-1
            content = course2_1_teacher.Text;
            using (StreamWriter sw = new StreamWriter(filePath[16]))
            {
                sw.Write(content);
            }
            //1-0-2
            content = course2_1_location.Text;
            using (StreamWriter sw = new StreamWriter(filePath[17]))
            {
                sw.Write(content);
            }

            //1-1-0
            content = course2_2_name.Text;
            using (StreamWriter sw = new StreamWriter(filePath[18]))
            {
                sw.Write(content);
            }
            //1-1-1
            content = course2_2_teacher.Text;
            using (StreamWriter sw = new StreamWriter(filePath[19]))
            {
                sw.Write(content);
            }
            //1-1-2 
            content = course2_2_location.Text;
            using (StreamWriter sw = new StreamWriter(filePath[20]))
            {
                sw.Write(content);
            }

            //1-2-0
            content = course2_3_name.Text;
            using (StreamWriter sw = new StreamWriter(filePath[21]))
            {
                sw.Write(content);
            }
            //1-2-1
            content = course2_3_teacher.Text;
            using (StreamWriter sw = new StreamWriter(filePath[22]))
            {
                sw.Write(content);
            }
            //1-2-2 
            content = course2_3_location.Text;
            using (StreamWriter sw = new StreamWriter(filePath[23]))
            {
                sw.Write(content);
            }

            //1-3-0
            content = course2_4_name.Text;
            using (StreamWriter sw = new StreamWriter(filePath[24]))
            {
                sw.Write(content);
            }
            //1-3-1
            content = course2_4_teacher.Text;
            using (StreamWriter sw = new StreamWriter(filePath[25]))
            {
                sw.Write(content);
            }
            //1-3-2 
            content = course2_4_location.Text;
            using (StreamWriter sw = new StreamWriter(filePath[26]))
            {
                sw.Write(content);
            }
            //1-4-0
            content = course2_5_name.Text;
            using (StreamWriter sw = new StreamWriter(filePath[27]))
            {
                sw.Write(content);
            }
            //1-4-1
            content = course2_5_teacher.Text;
            using (StreamWriter sw = new StreamWriter(filePath[28]))
            {
                sw.Write(content);
            }
            //1-4-2 
            content = course2_5_location.Text;
            using (StreamWriter sw = new StreamWriter(filePath[29]))
            {
                sw.Write(content);
            }
            //2-0-0
            content = course3_1_name.Text;
            using (StreamWriter sw = new StreamWriter(filePath[30]))
            {
                sw.Write(content);
            }
            //2-0-1
            content = course3_1_teacher.Text;
            using (StreamWriter sw = new StreamWriter(filePath[31]))
            {
                sw.Write(content);
            }
            //2-0-2
            content = course3_1_location.Text;
            using (StreamWriter sw = new StreamWriter(filePath[32]))
            {
                sw.Write(content);
            }

            //2-1-0
            content = course3_2_name.Text;
            using (StreamWriter sw = new StreamWriter(filePath[33]))
            {
                sw.Write(content);
            }
            //2-1-1
            content = course3_2_teacher.Text;
            using (StreamWriter sw = new StreamWriter(filePath[34]))
            {
                sw.Write(content);
            }
            //2-1-2 
            content = course3_2_location.Text;
            using (StreamWriter sw = new StreamWriter(filePath[35]))
            {
                sw.Write(content);
            }
            //2-2-0
            content = course3_3_name.Text;
            using (StreamWriter sw = new StreamWriter(filePath[36]))
            {
                sw.Write(content);
            }
            //2-2-1
            content = course3_3_teacher.Text;
            using (StreamWriter sw = new StreamWriter(filePath[37]))
            {
                sw.Write(content);
            }

            //2-2-2 
            content = course3_3_location.Text;
            using (StreamWriter sw = new StreamWriter(filePath[38]))
            {
                sw.Write(content);
            }

            //2-3-0
            content = course3_4_name.Text;
            using (StreamWriter sw = new StreamWriter(filePath[39]))
            {
                sw.Write(content);
            }
            //2-3-1
            content = course3_4_teacher.Text;
            using (StreamWriter sw = new StreamWriter(filePath[40]))
            {
                sw.Write(content);
            }
            //2-3-2 
            content = course3_4_location.Text;
            using (StreamWriter sw = new StreamWriter(filePath[41]))
            {
                sw.Write(content);
            }
            //2-4-0
            content = course3_5_name.Text;
            using (StreamWriter sw = new StreamWriter(filePath[42]))
            {
                sw.Write(content);
            }
            //2-4-1
            content = course3_5_teacher.Text;
            using (StreamWriter sw = new StreamWriter(filePath[43]))
            {
                sw.Write(content);
            }
            //2-4-2 
            content = course3_5_location.Text;
            using (StreamWriter sw = new StreamWriter(filePath[44]))
            {
                sw.Write(content);
            }
            //3-0-0
            content = course4_1_name.Text;
            using (StreamWriter sw = new StreamWriter(filePath[45]))
            {
                sw.Write(content);
            }
            //3-0-1
            content = course4_1_teacher.Text;
            using (StreamWriter sw = new StreamWriter(filePath[46]))
            {
                sw.Write(content);
            }
            //3-0-2
            content = course4_1_location.Text;
            using (StreamWriter sw = new StreamWriter(filePath[47]))
            {
                sw.Write(content);
            }

            //3-1-0
            content = course4_2_name.Text;
            using (StreamWriter sw = new StreamWriter(filePath[48]))
            {
                sw.Write(content);
            }
            //3-1-1
            content = course4_2_teacher.Text;
            using (StreamWriter sw = new StreamWriter(filePath[49]))
            {
                sw.Write(content);
            }
            //3-1-2 
            content = course4_2_location.Text;
            using (StreamWriter sw = new StreamWriter(filePath[50]))
            {
                sw.Write(content);
            }

            //3-2-0
            content = course4_3_name.Text;
            using (StreamWriter sw = new StreamWriter(filePath[51]))
            {
                sw.Write(content);
            }
            //3-2-1
            content = course4_3_teacher.Text;
            using (StreamWriter sw = new StreamWriter(filePath[52]))
            {
                sw.Write(content);
            }
            //3-2-2 
            content = course4_3_location.Text;
            using (StreamWriter sw = new StreamWriter(filePath[53]))
            {
                sw.Write(content);
            }

            //3-3-0
            content = course4_4_name.Text;
            using (StreamWriter sw = new StreamWriter(filePath[54]))
            {
                sw.Write(content);
            }
            //3-3-1
            content = course4_4_teacher.Text;
            using (StreamWriter sw = new StreamWriter(filePath[55]))
            {
                sw.Write(content);
            }
            //3-3-2 
            content = course4_4_location.Text;
            using (StreamWriter sw = new StreamWriter(filePath[56]))
            {
                sw.Write(content);
            }
            //3-4-0
            content = course4_5_name.Text;
            using (StreamWriter sw = new StreamWriter(filePath[57]))
            {
                sw.Write(content);
            }
            //3-4-1
            content = course4_5_teacher.Text;
            using (StreamWriter sw = new StreamWriter(filePath[58]))
            {
                sw.Write(content);
            }
            //3-4-2 
            content = course4_5_location.Text;
            using (StreamWriter sw = new StreamWriter(filePath[59]))
            {
                sw.Write(content);
            }
            //4-0-0
            content = course5_1_name.Text;
            using (StreamWriter sw = new StreamWriter(filePath[60]))
            {
                sw.Write(content);
            }
            //4-0-1
            content = course5_1_teacher.Text;
            using (StreamWriter sw = new StreamWriter(filePath[61]))
            {
                sw.Write(content);
            }
            //4-0-2
            content = course5_1_location.Text;
            using (StreamWriter sw = new StreamWriter(filePath[62]))
            {
                sw.Write(content);
            }

            //4-1-0
            content = course5_2_name.Text;
            using (StreamWriter sw = new StreamWriter(filePath[63]))
            {
                sw.Write(content);
            }
            //4-1-1
            content = course5_2_teacher.Text;
            using (StreamWriter sw = new StreamWriter(filePath[64]))
            {
                sw.Write(content);
            }
            //4-1-2 
            content = course5_2_location.Text;
            using (StreamWriter sw = new StreamWriter(filePath[65]))
            {
                sw.Write(content);
            }

            //4-2-0
            content = course5_3_name.Text;
            using (StreamWriter sw = new StreamWriter(filePath[66]))
            {
                sw.Write(content);
            }
            //4-2-1
            content = course5_3_teacher.Text;
            using (StreamWriter sw = new StreamWriter(filePath[67]))
            {
                sw.Write(content);
            }
            //4-2-2 
            content = course5_3_location.Text;
            using (StreamWriter sw = new StreamWriter(filePath[68]))
            {
                sw.Write(content);
            }

            //4-3-0
            content = course5_4_name.Text;
            using (StreamWriter sw = new StreamWriter(filePath[69]))
            {
                sw.Write(content);
            }
            //4-3-1
            content = course5_4_teacher.Text;
            using (StreamWriter sw = new StreamWriter(filePath[70]))
            {
                sw.Write(content);
            }
            //4-3-2 
            content = course5_4_location.Text;
            using (StreamWriter sw = new StreamWriter(filePath[71]))
            {
                sw.Write(content);
            }
            //4-4-0
            content = course5_5_name.Text;
            using (StreamWriter sw = new StreamWriter(filePath[72]))
            {
                sw.Write(content);
            }
            //4-4-1
            content = course5_5_teacher.Text;
            using (StreamWriter sw = new StreamWriter(filePath[73]))
            {
                sw.Write(content);
            }
            //4-4-2 
            content = course5_5_location.Text;
            using (StreamWriter sw = new StreamWriter(filePath[74]))
            {
                sw.Write(content);
            }
        }

    
        

        private void button1_Click(object sender, EventArgs e)
        {
             String[] Date = new String[]
           {
                Monday.Text,
                Tuesday.Text,
                Wednesday.Text,
                Thursday.Text,
                Friday.Text
           };
         String[] Jieshu = new String[]
         {
               one.Text,
               two.Text,
               three.Text,
               four.Text,
               five.Text,
               six.Text,
               seven.Text,
               eight.Text,
               nine.Text,
               ten.Text,

      };
         String[] course_infor = new String[]
         {
                course1_1_name.Text,
                course1_1_teacher.Text,
                course1_1_location.Text,

                 course1_2_name.Text,
                course1_2_teacher.Text,
                course1_2_location.Text,

                 course1_3_name.Text,
                course1_3_teacher.Text,
                course1_3_location.Text,

                 course1_4_name.Text,
                course1_4_teacher.Text,
                course1_4_location.Text,

                 course1_5_name.Text,
                course1_5_teacher.Text,
                course1_5_location.Text,

                 course2_1_name.Text,
                course2_1_teacher.Text,
                course2_1_location.Text,

                course2_2_name.Text,
                course2_2_teacher.Text,
                course2_2_location.Text,

                 course2_3_name.Text,
                course2_3_teacher.Text,
                course2_3_location.Text,

                course2_4_name.Text,
                course2_4_teacher.Text,
                course2_4_location.Text,

                course2_5_name.Text,
                course2_5_teacher.Text,
                course2_5_location.Text,

                course3_1_name.Text,
                course3_1_teacher.Text,
                course3_1_location.Text,

                course3_2_name.Text,
                course3_2_teacher.Text,
                course3_2_location.Text,

                course3_3_name.Text,
                course3_3_teacher.Text,
                course3_3_location.Text,

                course3_4_name.Text,
                course3_4_teacher.Text,
                course3_4_location.Text,

                course3_5_name.Text,
                course3_5_teacher.Text,
                course3_5_location.Text,

                course4_1_name.Text,
                course4_1_teacher.Text,
                course4_1_location.Text,

                course4_2_name.Text,
                course4_2_teacher.Text,
                course4_2_location.Text,

                course4_3_name.Text,
                course4_3_teacher.Text,
                course4_3_location.Text,

                course4_4_name.Text,
                course4_4_teacher.Text,
                course4_4_location.Text,

                course4_5_name.Text,
                course4_5_teacher.Text,
                course4_5_location.Text,

                course5_1_name.Text,
                course5_1_teacher.Text,
                course5_1_location.Text,

                course5_2_name.Text,
                course5_2_teacher.Text,
                course5_2_location.Text,

                course5_3_name.Text,
                course5_3_teacher.Text,
                course5_3_location.Text,

                course5_4_name.Text,
                course5_4_teacher.Text,
                course5_4_location.Text,

                course5_5_name.Text,
                course5_5_teacher.Text,
                course5_5_location.Text,
         };
        // 创建一个位图对象，作为画布
        Bitmap bitmap = new Bitmap(890, 570);
            // 创建一个绘图对象
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                // 设置绘图属性
                //划线
                Pen Draw_line = new Pen(Color.Gray);
                //填充紫色
                Brush Purple_brush= new SolidBrush(Color.FromArgb(102, 51, 153));
                //填充白色
                Brush White_brush = new SolidBrush(Color.White);
                //填充灰色
                Brush Gray_brush = new SolidBrush(Color.LightGray);
                //设置黑色字体和白色字体
                Font Myfont = new Font("Arial", 12);
                Font Coursefont = new Font("Arial", 10);
                Brush Black_text = Brushes.Black;
                Brush White_text = Brushes.White;
                //
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                graphics.Clear(Color.White);
                //画节次周次
                Rectangle jieci_zhouci = new Rectangle(20, 20, 100, 30);
                graphics.DrawRectangle(Draw_line, jieci_zhouci);
                graphics.FillRectangle(Gray_brush, jieci_zhouci);
                string text = "节次/周次";
                graphics.DrawString(text, Myfont, Black_text, jieci_zhouci, new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                });
                //画周天
                for(int i = 0; i <5; i++)
                {
                    //计算位置
                    int rectX = 20 + 100 + i * 150;
                    int rectY = 20;
                    //画矩形并填充
                    graphics.DrawRectangle(Draw_line, rectX, rectY,150, 30);
                    graphics.FillRectangle(Gray_brush, rectX, rectY, 150, 30);
                    float textX = rectX + 150 / 2;
                    float textY = rectY + 30 / 2;
                    //设置文本居中
                    StringFormat stringFormat = new StringFormat();
                    stringFormat.Alignment = StringAlignment.Center;
                    stringFormat.LineAlignment = StringAlignment.Center;
                    //写文本
                    graphics.DrawString(Date[i], Myfont, Black_text, textX, textY, stringFormat);
                }
                //画节次
                for(int i = 0; i < 10; i++)
                {
                    int dX = 20;
                    int dY = 20 + 30+i * 50;
                    graphics.DrawRectangle(Draw_line, dX, dY, 100, 50);
                    graphics.FillRectangle(Gray_brush, dX, dY, 100, 50);
                    float tX = dX + 100 / 2;
                    float tY = dY + 50 / 2;
                    StringFormat stringFormat = new StringFormat();
                    stringFormat.Alignment = StringAlignment.Center;
                    stringFormat.LineAlignment = StringAlignment.Center;
                    graphics.DrawString(Jieshu[i], Myfont, Black_text, tX, tY, stringFormat);
                }
                //填写课程信息
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        //此时间有课
                        if (course_infor[15 * i + 3 * j] != "")
                        {
                            float courseX = 20 + 100 + i * 150 + 5;
                            float courseY = 20 + 30 + j * 50 *2  + 5;
                            graphics.DrawRectangle(Draw_line, courseX, courseY, 140, 90);
                            graphics.FillRectangle(Purple_brush, courseX, courseY, 140, 90);
                            
                            // 定义文本框的位置和大小
                            RectangleF textRect = new RectangleF(courseX, courseY, 140, 90);

                            StringFormat stringFormat = new StringFormat
                            {
                                Alignment = StringAlignment.Center,
                                LineAlignment = StringAlignment.Center
                            };
                            // 写入文本
                            // 每行文本的间距
                             float lineSpacing = textRect.Height / 3;
                            // 写入第一行文本：课程名称
                            PointF line1Position = new PointF(textRect.Left + textRect.Width / 2, textRect.Top + lineSpacing / 2);
                            graphics.DrawString(course_infor[i * 15 + j * 3], Coursefont, White_text, line1Position, stringFormat);

                            // 写入第二行文本：授课教师
                            PointF line2Position = new PointF(textRect.Left + textRect.Width / 2, textRect.Top + lineSpacing * 1.5f);
                            graphics.DrawString(course_infor[i * 15 + j * 3+1], Coursefont, White_text, line2Position, stringFormat);

                            // 写入第三行文本：上课地点
                            PointF line3Position = new PointF(textRect.Left + textRect.Width / 2, textRect.Top + lineSpacing * 2.5f);
                            graphics.DrawString(course_infor[i * 15 + j * 3+2], Coursefont, White_text, line3Position, stringFormat);
                            
                        }

                    }
                }
            }
            
            




            // 保存图像文件
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "PNG Image|*.png";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;
                    bitmap.Save(filePath, System.Drawing.Imaging.ImageFormat.Png);
                    MessageBox.Show("图像保存成功！");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("图像保存失败：" + ex.Message);
            }
        }
    


      
      
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void four_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }


}
