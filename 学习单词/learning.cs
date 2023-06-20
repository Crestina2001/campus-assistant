using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;


namespace 日历
{
    public partial class learning : Form
    {
        //存储单词数据
        class MyData
        {
            private const string _ConString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=abcd.mdb";
            OleDbConnection con;
            public MyData()
            {
                try
                {
                    con = new OleDbConnection(_ConString);
                    con.Open();
                }
                catch (Exception)
                {
                    con.Close();
                }
            }
            public void close()
            {
                con.Close();
            }
            public OleDbDataReader select(string cmdTxt)
            {
                OleDbCommand cmd = new OleDbCommand(cmdTxt, con);
                OleDbDataReader dr = cmd.ExecuteReader();
                cmd.Dispose();
                return dr;
            }
            public OleDbDataAdapter selectAdapter(string cmdTxt)
            {
                OleDbDataAdapter da = new OleDbDataAdapter(cmdTxt, con);
                return da;
            }
            public bool Update(string cmdTxt)
            {
                try
                {
                    OleDbCommand cmd = new OleDbCommand(cmdTxt, con);
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
                finally
                {
                    con.Close();
                }
            }
        }
        //对单词进行处理
        class WordProcessor
        {
            public List<string[]> words = new List<string[]>();
            public double strengthMultiplier = 2;
            public double lowerThreshold = 0.8;
            public double initialStrength = 0.02;
            public int totalWordCount;
            public int wordsToReviewCount;
            public double ticksConversion = 10000000;

            public WordProcessor()
            {
                totalWordCount = 0;
                Initialize();
            }
            //对单词进行初始化
            public void Initialize()
            {
                totalWordCount = 0;
                wordsToReviewCount = 0;
                words.Clear();
                MyData dataAccess = new MyData();
                string sql = "SELECT * FROM words";
                OleDbDataReader reader = dataAccess.select(sql);
                //读取单词
                while (reader.Read())
                {
                    string[] word = new string[4];
                    word[0] = reader.GetString(0).ToString();
                    word[1] = reader.GetString(1).ToString();
                    word[2] = reader.GetString(2).ToString();
                    word[3] = reader.GetString(3).ToString();

                    words.Add(word);
                }

                totalWordCount = words.Count;
                wordsToReviewCount = totalWordCount;
            }
            //获取下一个单词的索引
            public int GetNextWordIndex()
            {
                DateTime now = DateTime.Now;
                double currentTicks = now.Ticks;
                double minProbability = 1;
                int minIndex = 0;
                wordsToReviewCount = 0;
                //遍历words列表中的所有单词，计算每个单词的复习概率，然后选出概率最小的单词作为下一个要复习的单词。
                for (int i = 0; i < totalWordCount; i++)
                {
                    double timeElapsed = (currentTicks - Convert.ToDouble(words[i][3])) / ticksConversion;
                    double strength = Convert.ToDouble(words[i][2]);
                    double probability = Math.Exp(-strength * timeElapsed);

                    if (probability < minProbability)
                    {
                        minProbability = probability;
                        minIndex = i;
                    }

                    if (probability < lowerThreshold)
                    {
                        wordsToReviewCount++;
                    }
                }

                if (minProbability >= lowerThreshold)
                {
                    return -1;
                }

                return minIndex;
            }
            //更新单词的强度
            public void UpdateWordStrength(int wordIndex, bool isKnown)
            {
                double currentTicks = DateTime.Now.Ticks;
                double timeElapsed = (currentTicks - Convert.ToDouble(words[wordIndex][3])) / ticksConversion;
                double strength = Convert.ToDouble(words[wordIndex][2]);
                double updatedStrength;
                //如果用户认识该单词，减少单词的强度值
                if (isKnown)
                {
                    double newStrength = -Math.Log(lowerThreshold) / timeElapsed;
                    updatedStrength = Math.Min(newStrength, strength) / strengthMultiplier;
                }
                //如果用户不认识该单词，增加单词的强度值
                else
                {
                    double newStrength = -Math.Log(lowerThreshold) / timeElapsed;
                    updatedStrength = Math.Max(newStrength, strength) * strengthMultiplier * 4;
                }

                words[wordIndex][2] = updatedStrength.ToString();
                words[wordIndex][3] = currentTicks.ToString();

                MyData dataAccess = new MyData();
                string sql = $"UPDATE words SET a='{updatedStrength}', t='{currentTicks}' WHERE key='{words[wordIndex][0]}'";
                dataAccess.Update(sql);
            }
            //添加单词
            public void AddNewWord(string key, string value)
            {
                DateTime now = DateTime.Now;
                string currentTicks = now.Ticks.ToString();
                string[] newWord = { key, value, initialStrength.ToString(), currentTicks };
                words.Add(newWord);

                MyData dataAccess = new MyData();
                string sql = $"INSERT INTO words VALUES('{key}','{value}','{initialStrength}','{currentTicks}')";
                dataAccess.Update(sql);

                totalWordCount++;
                
            }
            //修改单词
            public void ModifyWord(string key, string value, int wordIndex)
            {
                words[wordIndex][0] = key;
                words[wordIndex][1] = value;

                MyData dataAccess = new MyData();
                string sql = $"UPDATE words SET val='{value}' WHERE key='{key}'";
                dataAccess.Update(sql);
            }
            //修改单词
            public void DeleteWord(string key, string value, int wordIndex)
            {
                // 遍历列表，找到要删除的单词所在的索引
                words.RemoveAt(wordIndex);

                // 在此执行数据库删除操作，替换为适合你的实现方法
                MyData dataAccess = new MyData();
                string sql = $"DELETE FROM words WHERE key='{key}'";
                dataAccess.Update(sql);

                totalWordCount--;
                wordsToReviewCount--;
            }
        }
        WordProcessor wordProcessor = new WordProcessor();
        int nextWordIndex = -1;

        public learning()
        {
            InitializeComponent();
            this.DoubleBuffered = true; // 双缓冲
            this.BackgroundImage = Resource1.learning;
            this.BackgroundImageLayout = ImageLayout.Stretch; // 设置背景图片自动适应
            Show();
        }
        //展示单词
        void Show()
        {
            nextWordIndex = wordProcessor.GetNextWordIndex();

            if (nextWordIndex == -1)
            {
                //MessageBox.Show("该学习新的了");
                textBox1.Text = "";
                textBox2.Text = "";
                //button3.Enabled = true;
                button1.Enabled = false;
                button2.Enabled = false;
                button4.Enabled = false;
                //button5.Enabled = false;
            }
            else
            {
                textBox1.Text = wordProcessor.words[nextWordIndex][0];
                textBox2.Text = "";
                //button3.Enabled = false;
                button1.Enabled = true;
                button2.Enabled = true;
                button4.Enabled = true;
                //button5.Enabled = true;
            }

            zcsn.Text = wordProcessor.totalWordCount.ToString();
            xyfxn.Text = wordProcessor.wordsToReviewCount.ToString();
            button1.Focus();
        }
        //点击事件
        private void button2_Click(object sender, EventArgs e)
        {
            wordProcessor.UpdateWordStrength(nextWordIndex, false);
            nextWordIndex = wordProcessor.GetNextWordIndex();
            Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            wordProcessor.AddNewWord(textBox1.Text, textBox2.Text);
            Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            wordProcessor.UpdateWordStrength(nextWordIndex,true);
            nextWordIndex = wordProcessor.GetNextWordIndex();
            Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox2.Text = wordProcessor.words[nextWordIndex][1];
        }

        private void button5_Click(object sender, EventArgs e)
        {
            wordProcessor.ModifyWord(textBox1.Text, textBox2.Text, nextWordIndex);
            Show();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            wordProcessor.DeleteWord(textBox1.Text, textBox2.Text, nextWordIndex);
            Show();
        }
        private void button7_Click(object sender, EventArgs e)
        {
            wordProcessor.Initialize();
            Show();
        }


       
    }
}
