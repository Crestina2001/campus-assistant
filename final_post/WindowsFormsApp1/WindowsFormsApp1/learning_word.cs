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
    public partial class learning_word : Form
    {
      
        //对单词进行处理
        class WordProcessor
        {
            public List<string[]> words = new List<string[]>();
            public int[] unknown_words  = new int[10000];// 存储不认识的单词的索引值
            public double[] words_strength = new double[10000];// 存储单词的不认识强度值
            public double[] words_time = new double[10000];// 存储单词的记忆时间
            public double strengthMultiplier = 2;
            public double unknown_strength = 1;
            public double initialStrength = 1;
            public double initialTime = DateTime.Now.Ticks;
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
                words.Clear();
                int count = 0;
                totalWordCount = 0;
                wordsToReviewCount = 0;
                // 打开 CSV 文件
                FileStream fs = new FileStream(@"../../database/english_words.csv", FileMode.Open, FileAccess.Read);
                StreamReader filereader = new StreamReader(fs);
                

                // 读取每一列数据
                while (filereader.Peek()!=-1)
                {
                    string line = filereader.ReadLine();
                    int index = line.IndexOf(',');
                  
                      
                    string[] word = new string[2];
                    word[0] = line.Substring(0,index);
                    word[1] = line.Substring(index+1);
                  
                    words.Add(word);
                    unknown_words[count] = 1;
                    words_strength[count] = initialStrength;
                    words_time[count] = initialTime;
                    count++;
                }
                filereader.Close();



                totalWordCount = words.Count;
                wordsToReviewCount = totalWordCount;
            }
            //获取下一个单词的索引
            public int GetNextWordIndex()
            {
                DateTime now = DateTime.Now;
                double currentTicks = now.Ticks;
                double maxProbability = 1;
                int minIndex = 0;
                
                //遍历words列表中的所有单词，计算每个单词的复习概率，然后选出概率最小的单词作为下一个要复习的单词。
                for (int i = 0; i < totalWordCount; i++)
                {
                    double timeElapsed = (currentTicks -words_time[i]) / ticksConversion;
                    double strength = words_strength[i];
                    //不认识的概率：和强度以及时间正相关
                    double probability =strength * timeElapsed;

                    if (probability > maxProbability)
                    {
                        maxProbability = probability;
                        minIndex = i;
                    }

                 
                }

            

                return minIndex;
            }
            //更新单词的强度
            public void UpdateWord(int wordIndex, bool isKnown)
            {

                double currentTicks = DateTime.Now.Ticks;
                double strength = words_strength[wordIndex];
                double updatedStrength;

                //如果用户认识该单词，减少单词的强度值
                if (isKnown)
                {
                    updatedStrength =  strength / strengthMultiplier;
                }
                //如果用户不认识该单词，增加单词的强度值
                else
                {               
                    updatedStrength =  strength * strengthMultiplier;
                }
                //如果更新后的强度值满足了不认识的标准，将其加入不认识的单词

                if (updatedStrength >= unknown_strength && unknown_words[wordIndex] == 0)
                {
                    unknown_words[wordIndex] = 1;
                    wordsToReviewCount++;
                }
                    
                if (updatedStrength < unknown_strength && unknown_words[wordIndex] == 1)
                {
                    unknown_words[wordIndex] = 0;
                    wordsToReviewCount--;
                }
                 

                //更新words的强度和时间值
                words_strength[wordIndex] = updatedStrength;
                words_time[wordIndex] = currentTicks;



            }
            //添加单词
            public void AddNewWord(string key, string value)
            {
                
                string[] newWord = { key, value };
                words.Add(newWord);

                // 按行读取CSV文件
                var lines = new List<string>();
                using (var reader = new StreamReader(@".\english_words.csv"))
                {
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        lines.Add(line);
                    }
                    reader.Close();
                }
        
                // 添加新行数据
                string newRow = key+","+value;
                lines.Add(newRow);

                // 将行数据写入CSV文件
                using (var writer = new StreamWriter(@".\english_words.csv"))
                {
                    foreach (string line in lines)
                    {
                        int index = line.IndexOf(',');
                        if (index >= 0)
                        {
                            string part1 = line.Substring(0, index);
                            string part2 = line.Substring(index + 1);
                            writer.WriteLine(part1 + "," + part2);
                        }
                    }
                    writer.Close();
                }
          
                totalWordCount++;
                
            }
            //修改单词
            public void ModifyWord(string key, string value, int wordIndex)
            {
           
                words[wordIndex][0] = key;
                words[wordIndex][1] = value;
                // 按行读取CSV文件
                var lines = new List<string>();
                using (var reader = new StreamReader(@".\english_words.csv"))
                {
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        lines.Add(line);
                    }
                    reader.Close();
                }

                // 修改某一行数据
                int rowIndex = wordIndex; // 假设要修改第二行数据
                string rowContent = lines[rowIndex]; // 获取要修改的行内容
                string[] rowColumns = rowContent.Split(','); // 将行内容按逗号分隔成字符串数组
                rowColumns[0] = key; // 修改第一个列的值
                rowColumns[1] = value; // 修改第二个列的值
                string newRowContent = string.Join(",", rowColumns); // 将修改后的列重新拼接成一行内容
                lines[rowIndex] = newRowContent; // 将修改后的行内容替换到原来的行

                // 将行数据写入CSV文件
                using (var writer = new StreamWriter(@".\english_words.csv"))
                {
                    foreach (string line in lines)
                    {
                        int index = line.IndexOf(',');
                        if (index >= 0)
                        {
                            string part1 = line.Substring(0, index);
                            string part2 = line.Substring(index + 1);
                            writer.WriteLine(part1 + "," + part2);
                        }
                    }
                    writer.Close();
                }

            }
            //删除单词
            public void DeleteWord(string key, string value, int wordIndex)
            {
                if(unknown_words[wordIndex] == 1)
                {
                    unknown_words[wordIndex]=0;
                    wordsToReviewCount--;
                }
                // 遍历列表，找到要删除的单词所在的索引
                words.RemoveAt(wordIndex);

  

                // 按行读取CSV文件
                var lines = new List<string>();
                using (var reader = new StreamReader(@".\english_words.csv"))
                {
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        lines.Add(line);
                    }
                    reader.Close();
                }

                // 删除某一行数据
                int rowIndex = wordIndex; // 假设要删除第二行数据
                lines.RemoveAt(rowIndex); // 删除第二行数据

                // 将行数据写入CSV文件
                using (var writer = new StreamWriter(@".\english_words.csv"))
                {
                    foreach (string line in lines)
                    {
                        int index = line.IndexOf(',');
                        if (index >= 0)
                        {
                            string part1 = line.Substring(0, index);
                            string part2 = line.Substring(index + 1);
                            writer.WriteLine(part1 + "," + part2);
                        }
                    }
                    writer.Close();
                }
                totalWordCount--;
                
            }
        }
        WordProcessor wordProcessor = new WordProcessor();
        int nextWordIndex = -1;

        public learning_word()
        {
            InitializeComponent();
            this.DoubleBuffered = true; // 双缓冲

            Show();
        }
        //展示单词
        void Show()
        {
            nextWordIndex = wordProcessor.GetNextWordIndex();

            if (nextWordIndex == -1)
            {
                MessageBox.Show("该学习新的了");
                
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
                button3.Enabled = true;
                button1.Enabled = true;
                button2.Enabled = true;
                button4.Enabled = true;
                button5.Enabled = true;
            }

            zcsn.Text = wordProcessor.totalWordCount.ToString();
            xyfxn.Text = wordProcessor.wordsToReviewCount.ToString();
        
        }
        //点击事件
        private void button2_Click(object sender, EventArgs e)
        {
            wordProcessor.UpdateWord(nextWordIndex, false);
            Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string word = textBox1.Text;
            string meaning = textBox2.Text;

            if (string.IsNullOrEmpty(word) || string.IsNullOrEmpty(meaning))
            {
                MessageBox.Show("同学请在输入框中输入内容哦~~~");
            }
            else
            {
                wordProcessor.AddNewWord(word, meaning);
                Show();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            wordProcessor.UpdateWord(nextWordIndex,true);
            Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox2.Text = wordProcessor.words[nextWordIndex][1].Trim('\"');
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string word = textBox1.Text;
            string meaning = textBox2.Text;

            if (string.IsNullOrEmpty(word) || string.IsNullOrEmpty(meaning))
            {
                MessageBox.Show("同学请在输入框中输入内容哦~~~");
            }
            else
            {
                wordProcessor.ModifyWord(textBox1.Text, textBox2.Text, nextWordIndex);
                Show();
            }
          
        }
        private void button6_Click(object sender, EventArgs e)
        {

            string word = textBox1.Text;
            string meaning = textBox2.Text;
            if (string.IsNullOrEmpty(word) || string.IsNullOrEmpty(meaning))
            {
                MessageBox.Show("同学请在输入框中输入内容哦~~~");
            }
            else
            {
                wordProcessor.DeleteWord(word,meaning,nextWordIndex);
                Show();
            }
          
        }
        private void button7_Click(object sender, EventArgs e)
        {
            wordProcessor.Initialize();
            Show();
        }

        private void learning_word_Load(object sender, EventArgs e)
        {

        }
    }
}
