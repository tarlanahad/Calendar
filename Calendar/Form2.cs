using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlServerCe;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calendar
{
    public partial class Form2 : Form
    {


        public Form2()
        {
            InitializeComponent();



        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();

        }


        private void am_pm_Click(object sender, EventArgs e)
        {
            if (((Button)sender).Text.Equals("AM"))
                ((Button)sender).Text = "PM";
            else
                ((Button)sender).Text = "AM";

        }

        public TextBox getTitleView()
        {
            return eventTitle;
        }

        public TextBox getLocationView()
        {
            return eventLocation;
        }

        public Label getSelectedDayView()
        {
            return selectedDate;
        }

        private void add_Click(object sender, EventArgs e)
        {
            Dictionary<int, List<Event>> mEvents = new Dictionary<int, List<Event>>();
            SaveXML<Dictionary<int, List<Event>>> saver = new SaveXML<Dictionary<int, List<Event>>>();
            if (File.Exists(Form1.eventFileName))
            {
                mEvents = saver.GetData(mEvents, Form1.eventFileName);
            }

            List<Event> eventslist = new List<Event>();

            if (mEvents.ContainsKey(selectedDate.Text.ToString().GetHashCode()))
                eventslist = mEvents[selectedDate.Text.ToString().GetHashCode()];

            eventslist.Add(new Event(eventTitle.Text, eventLocation.Text, hourTxt.Text + ":" + minuteTxt.Text + " " + am_pm.Text, selectedDate.Text));

            mEvents.Remove(selectedDate.Text.ToString().GetHashCode());

            mEvents.Add(selectedDate.Text.ToString().GetHashCode(), eventslist);

            saver.SaveData(mEvents, Form1.eventFileName);

        }





    }
}
