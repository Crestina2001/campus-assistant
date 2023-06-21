using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiveCharts;
using LiveCharts.Wpf;
using System.Windows.Forms;
using System.IO;
using LiveCharts.Wpf.Charts.Base;
using System.Windows.Media;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;
using LiveCharts.WinForms;
using LiveCharts.Definitions.Charts;
using static System.Drawing.Color;

namespace 日历
{
    public partial class timeStatistic : Form
    {
        DateTime today = DateTime.Today;
        private int focusFailToday = 0;
        private int focusFailWeek = 0;
        private int focusFailMonth = 0;
        private LineSeries todaySeries = new LineSeries { 
            Title = "专注时长",
            Values = new ChartValues<int>()
        };
        private LineSeries weekSeries = new LineSeries
        {
            Title = "专注时长",
            Values = new ChartValues<int>()
        };
        private LineSeries monthSeries = new LineSeries
        {
            Title = "专注时长",
            Values = new ChartValues<int>()
        };
        public timeStatistic()
        {
            InitializeComponent();
                       
            todaySeries.Values.Add(0); // 0点
            todaySeries.Values.Add(0); // 1点
            todaySeries.Values.Add(0); // 2点
            todaySeries.Values.Add(0); // 3点
            todaySeries.Values.Add(0); // 4点
            todaySeries.Values.Add(0); // 5点
            todaySeries.Values.Add(0); // 6点
            todaySeries.Values.Add(0); // 7点
            todaySeries.Values.Add(0); // 8点
            todaySeries.Values.Add(0); // 9点
            todaySeries.Values.Add(0); // 10点
            todaySeries.Values.Add(0); // 11点
            todaySeries.Values.Add(0); // 12点
            todaySeries.Values.Add(0); // 13点
            todaySeries.Values.Add(0); // 14点
            todaySeries.Values.Add(0); // 15点
            todaySeries.Values.Add(0); // 16点
            todaySeries.Values.Add(0); // 17点
            todaySeries.Values.Add(0); // 18点
            todaySeries.Values.Add(0); // 19点
            todaySeries.Values.Add(0); // 20点
            todaySeries.Values.Add(0); // 21点
            todaySeries.Values.Add(0); // 22点
            todaySeries.Values.Add(0); // 23点

           
            weekSeries.Values.Add(0);//周一
            weekSeries.Values.Add(0);//周二
            weekSeries.Values.Add(0);//周三
            weekSeries.Values.Add(0);//周四
            weekSeries.Values.Add(0);//周五
            weekSeries.Values.Add(0);//周六
            weekSeries.Values.Add(0);//周日
          
            monthSeries.Values.Add(0);//1
            monthSeries.Values.Add(0);//2
            monthSeries.Values.Add(0);
            monthSeries.Values.Add(0);
            monthSeries.Values.Add(0);
            monthSeries.Values.Add(0);
            monthSeries.Values.Add(0);
            monthSeries.Values.Add(0);
            monthSeries.Values.Add(0);
            monthSeries.Values.Add(0);
            monthSeries.Values.Add(0);
            monthSeries.Values.Add(0);
            monthSeries.Values.Add(0);
            monthSeries.Values.Add(0);
            monthSeries.Values.Add(0);
            monthSeries.Values.Add(0);
            monthSeries.Values.Add(0);
            monthSeries.Values.Add(0);
            monthSeries.Values.Add(0);
            monthSeries.Values.Add(0);
            monthSeries.Values.Add(0);
            monthSeries.Values.Add(0);
            monthSeries.Values.Add(0);
            monthSeries.Values.Add(0);
            monthSeries.Values.Add(0);
            monthSeries.Values.Add(0);
            monthSeries.Values.Add(0);
            monthSeries.Values.Add(0);
            monthSeries.Values.Add(0);
            monthSeries.Values.Add(0);//30
            monthSeries.Values.Add(0);


            // 创建图表并添加数据序列
            updateSeries();
            //cartesianChart1.Series.Add(todaySeries);
            cartesianChart1.AxisX.Add(new Axis
            {
                Title = "今日",
                Labels = new[] { "0点", "1点", "2点", "3点", "4点", "5点", "6点", "7点", "8点", "9点", "10点", "11点", "12点", "13点", "14点", "15点", "16点", "17点", "18点", "19点", "20点", "21点", "22点", "23点" },
                Foreground = System.Windows.Media.Brushes.Black,
            }
            ) ;
            cartesianChart1.AxisY.Add(new Axis
            {
                Title = "专注时长（分钟）",
                MinValue = 0,
                Foreground = System.Windows.Media.Brushes.Black,

            });   
            cartesianChart1.Visible = true;
            

            //cartesianChart2.Series.Add(weekSeries);
            cartesianChart2.AxisX.Add(new Axis
            {
                Title = "过去七天",
                Labels= new[] {"6天前","5天前","4天前","3天前","2天前","1天前","今天"},
                Foreground = System.Windows.Media.Brushes.Black,
            });
            cartesianChart2.AxisY.Add(new Axis
            {
                Title = "专注时长（分钟）",
                MinValue = 0,
                Foreground = System.Windows.Media.Brushes.Black,

            });
            cartesianChart2.Visible = false;

            //cartesianChart3.Series.Add(monthSeries);
            cartesianChart3.AxisX.Add(new Axis
            {
                Title = "本月",
                Labels = new[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24" ,"25","26","27","28","29","30","31"},
                Foreground = System.Windows.Media.Brushes.Black,
            }
            );
            cartesianChart3.AxisY.Add(new Axis
            {
                Title = "专注时长（分钟）",
                MinValue = 0,
                Foreground = System.Windows.Media.Brushes.Black,

            });
            
            cartesianChart3.Visible = false;
            label1.Visible = true;
            label2.Visible = false;
            label3.Visible = false;

        }
        public void updateSeries()
        {
            for (int i = 0; i < monthSeries.Values.Count; i++)
            {
                monthSeries.Values[i] = 0;
            }
            for (int i = 0; i <weekSeries.Values.Count; i++)
            {
                weekSeries.Values[i] = 0;
            }
            for (int i = 0; i < todaySeries.Values.Count; i++)
            {
                todaySeries.Values[i] = 0;
            }
            focusFailToday = 0;
            focusFailWeek = 0;
            focusFailMonth = 0;
            using (StreamReader sr = new StreamReader("C:\\Users\\Lancet\\Desktop\\time_log.txt"))
            {
                string line;
                int[] dayTimeMonth = new int[31];
                int[] dayTimeWeek = new int[7];
                while ((line = sr.ReadLine()) != null)
                {
                    // 处理每行数据
                    // 将时间字符串转换为 DateTime 对象                   
                    string[] parts = line.Split(' ');
                    string dateString = parts[0] + " " + parts[1];
                    DateTime dateTime = DateTime.ParseExact(dateString, "yyyy-MM-dd HH:mm:ss.ffffff", null);
                    int year = dateTime.Year;
                    int month = dateTime.Month;
                    int day = dateTime.Day;
                    int hour = dateTime.Hour;
                    int minute = dateTime.Minute;
                    int duration = int.Parse(parts[2]);
                    if (duration == -1)
                    {
                        //TODO
                        //统计未完成的次数
                        if(day == today.Day)
                            focusFailToday++;
                        if(month == today.Month)
                            focusFailMonth++;
                        if (month == today.Month)
                        {
                            int interval = today.Day - day;
                            if (interval > 6)
                            {
                                continue;
                            }
                            else
                            {
                                focusFailWeek++;
                            }
                        }
                        else if (month == today.Month - 1)
                        {
                            if (today.Day >= 7)
                                continue;
                            //大月有1 3 5 7 8 10 12
                            if (month == 1 || month == 3 || month == 5 || month == 7 || month == 8 || month == 10 || month == 12)
                            {
                                if (32 - day >= 7)
                                    continue;
                                else if (today.Day + 32 - day > 7)
                                    continue;
                                else if (today.Day + 32 - day <= 7)
                                {
                                    focusFailWeek++;
                                }
                            }
                            //小月有 4 6 9 11
                            else if (month != 2)
                            {
                                if (31 - day >= 7)
                                    continue;
                                else if (today.Day + 31 - day > 7)
                                    continue;
                                else if (today.Day + 31 - day <= 7)
                                {
                                    focusFailWeek++;
                                }
                            }
                            //2月看情况
                            else
                            {

                            }
                        }
                        else//跨年
                        {
                            continue;
                        }
                        continue;
                    }
                    //更新月视图显示本月的专注时长
                    if (month != today.Month)
                    {
                        //continue;
                    }
                    else
                    {
                        dayTimeMonth[day - 1] += duration;
                        monthSeries.Values.RemoveAt(day - 1);
                        monthSeries.Values.Insert(day - 1, dayTimeMonth[day - 1]);
                    }
                    //更新周视图（过去7天）
                    //需要考虑跨年，跨月
                    //计算读取日期和当前日期之间的差值
                    //如果是同月份
                    if (month == today.Month)
                    {
                        int interval = today.Day - day;
                        if (interval > 6)
                        {
                            continue;
                        }
                        else
                        {
                            dayTimeWeek[6 + day - today.Day] += duration;
                            weekSeries.Values.RemoveAt(6 + day - today.Day);
                            weekSeries.Values.Insert(6 + day - today.Day, dayTimeWeek[6 + day - today.Day]);
                        }
                    }
                    else if (month == today.Month - 1)
                    {
                        if (today.Day >= 7)
                            continue;
                        //大月有1 3 5 7 8 10 12
                        if (month == 1 || month == 3 || month == 5 || month == 7 || month == 8 || month == 10 || month == 12)
                        {
                            if (32 - day >= 7)
                                continue;
                            else if (today.Day + 32 - day > 7)
                                continue;
                            else if (today.Day + 32 - day <= 7)
                            {
                                dayTimeWeek[7 - (32 - day + today.Day)] += duration;
                                weekSeries.Values.RemoveAt(7 - (32 - day + today.Day));
                                weekSeries.Values.Insert(6 + day - today.Day, dayTimeWeek[7 - (32 - day + today.Day)]);
                            }
                        }
                        //小月有 4 6 9 11
                        else if (month != 2)
                        {
                            if (31 - day >= 7)
                                continue;
                            else if (today.Day + 31 - day > 7)
                                continue;
                            else if (today.Day + 31 - day <= 7)
                            {
                                dayTimeWeek[7 - (31 - day + today.Day)] += duration;
                                weekSeries.Values.RemoveAt(7 - (31 - day + today.Day));
                                weekSeries.Values.Insert(6 + day - today.Day, dayTimeWeek[7 - (31 - day + today.Day)]);
                            }
                        }
                        //2月看情况
                        else
                        {

                        }
                    }
                    else//跨年
                    {
                        continue;
                    }
                    // 判断是否为今天
                    if (dateTime.Date == today)
                    {
                        // 提取时、分和时长                     
                        if (duration > minute) { hour -= 1; }
                        int oldValue = (int)todaySeries.Values[hour];
                        int newValue = oldValue + duration;
                        todaySeries.Values.RemoveAt(hour);
                        todaySeries.Values.Insert(hour, newValue);
                    }

                }
                cartesianChart1.Series.Clear();
                cartesianChart2.Series.Clear();
                cartesianChart3.Series.Clear();
                cartesianChart1.Series.Add(todaySeries);
                cartesianChart2.Series.Add(weekSeries);
                cartesianChart3.Series.Add(monthSeries);
                label1.Text = "今日专注失败次数：" + focusFailToday.ToString();
                label2.Text = "过去七天专注失败次数："+focusFailWeek.ToString();
                label3.Text ="本月专注失败次数："+focusFailMonth.ToString();
               
                sr.Close();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            updateSeries();
            label1.Visible = true; 
            label2.Visible = false; 
            label3.Visible = false;
            cartesianChart1.Visible = true; 
            cartesianChart2.Visible = false;
            cartesianChart3.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            updateSeries();
            label1.Visible = false;
            label2.Visible = true;
            label3.Visible = false;
            cartesianChart1.Visible = false;
            cartesianChart2.Visible = true;
            cartesianChart3.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            updateSeries();
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = true;
            cartesianChart1.Visible = false;
            cartesianChart2.Visible = false;
            cartesianChart3.Visible = true;
        }


    }
}
