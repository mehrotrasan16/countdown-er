using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CountDown_Timer
{
    public partial class TimerDemo : Form
    {
        Timer Clock;
        DateTimePicker dtp1 = new DateTimePicker();
        //LinkLabel lbTime = new LinkLabel();
        Label lbTime = new Label();
        Label lbText = new Label();
        DateTime StartDate = DateTime.Now;
        DateTime EndDate = DateTime.Parse("20-Nov-2019 12:00 am");
        Image bck;


        public TimerDemo()
        {
            //add the labels
            this.Controls.Add(lbText);
            this.Controls.Add(lbTime);
            this.BackColor = Color.Black;
            InitializeComponent();          //initialze the labels so that they can be used later (otherwie they remain uninitialized -> null)

            //set the date picker/calendar to todays date 
            dtp1.Value = this.EndDate;
            TimeSpan datediff = (EndDate - StartDate);

            Clock = new Timer();
            Clock.Interval = 1000;//(int)datediff.TotalSeconds;
            Clock.Start();
            Clock.Tick += new EventHandler(Timer_Tick);

            
            //lbTime.BackColor = Color.Black;
            lbTime.ForeColor = Color.LightGreen;
            lbTime.Size = new Size(500, 100);
            lbTime.Location = new Point(70, 0);
            //lbTime.Font = new Font("Times New Roman", 15);
            lbTime.Font = new Font("Dubai Light", 25);
            lbTime.Text = GetTime();
            lbTime.Visible = true;
            lbTime.Click += new EventHandler(lbTime_click);
            

            lbText.Text = "Your Next Deadline: Assignment 5 - Machine Learning";
            lbText.Font = new Font("Dubai Light", 20);
            lbText.BackColor = Color.Transparent;
            lbText.ForeColor = Color.White;
            lbText.Location = new Point(70, 100);
            lbText.Size = new Size(300,200);
            lbText.SendToBack();
            lbText.Visible = true;


            dtp1.Enabled= false;
            dtp1.Location = new Point(100,300);
            dtp1.Width = 80;
            dtp1.CalendarForeColor = Color.White;
            dtp1.Format = DateTimePickerFormat.Short;
            dtp1.CalendarTitleBackColor = Color.Gold;
            this.Controls.Add(dtp1);
            //InitializeComponent();

        }

        public string GetTime()
        {
            string TimeInString = "";
            int hour = DateTime.Now.Hour;
            int min = DateTime.Now.Minute;
            int sec = DateTime.Now.Second;

            //update startdate to now 
            StartDate = DateTime.Now;
            TimeSpan datediff = (EndDate - StartDate);

            TimeInString = ((int)datediff.TotalDays).ToString() + " days ";
            TimeInString += " " + ((datediff.Hours < 10) ? "0" + ((int)datediff.Hours).ToString() : ((int)datediff.Hours).ToString());
            TimeInString += ":" + ((datediff.Minutes < 10) ? "0" + datediff.Minutes.ToString() : ((int)datediff.Minutes).ToString());
            TimeInString += ":" + ((datediff.Seconds < 10) ? "0" + ((int)datediff.Seconds).ToString() : ((int)datediff.Seconds).ToString());
            return TimeInString;
        }

        public void Timer_Tick(object sender, EventArgs eArgs)
        {
            if (sender == Clock)
            {
                lbTime.Text = GetTime();
            }
        }

        public void lbTime_click(object sender, EventArgs lArgs)
        {
            MonthCalendar cal = new MonthCalendar();
            this.Controls.Add(cal);
            cal.SetDate(this.EndDate);
            cal.Location = new Point(400, 100);
            cal.Visible = true;
        }

    }
}
