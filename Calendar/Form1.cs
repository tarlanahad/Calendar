using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Device.Location;
using System.IO;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;
using System.Data.SqlClient;
using System.Security.AccessControl;
using System.Security.Principal;

namespace Calendar
{
    public partial class Form1 : Form
    {

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();


        int currentMonthCounter = 0;

        DateTime TODAY;

        private GeoCoordinateWatcher Watcher = null;

        CalndarGridItem selectedGridItem;

        Label previouslySelected;

        Dictionary<int, List<Event>> mEvents = new Dictionary<int, List<Event>>();

        public static String eventFileName =  "C:\\Calendar\\events.bin";

        public Form1()
        {

            GrantAccess("C:\\Calendar");

            InitializeComponent();


            initView();

        }

        private void initView()
        {

            mainPanel.MouseDown += dragger_MouseDown;
            closeApp.Click += stopApp;

            TODAY = DateTime.Today;
            selectedGridItem = new CalndarGridItem();
            previouslySelected = selectedGridItem.getTextView();

            selectedGridItem.setText(TODAY.Day + "");
            selectedGridItem.setDateTime(TODAY);


            nextMonthBtn.RotateLeft();
            prevMonthBtn.RotateRight();


            prevMonthBtn.addOnButtonClickHandler(new EventHandler(prevMonthBtn_onClick));
            nextMonthBtn.addOnButtonClickHandler(new EventHandler(nextMonthBtn_onClick));


            createGrid(0);

            String currenDayOfMonthString = (int)DateTime.Today.Day + "";
            currentDayOfMonth.Text = (currenDayOfMonthString.Length < 2 ? "0" + currenDayOfMonthString : currenDayOfMonthString);
            currentDayOfWeek.Text = TODAY.DayOfWeek + "";

            setWeatherCondition();
        }

        private void createGrid(int addMonth)
        {


            if (File.Exists(eventFileName))
            {
                SaveXML<Dictionary<int, List<Event>>> saver = new SaveXML<Dictionary<int, List<Event>>>();
                mEvents = saver.GetData(mEvents, eventFileName);
            }

            gridView.Controls.Clear();


            String[] months = {
                              "su",
                              "mo",
                              "tu",
                              "we",
                              "th",
                              "fr",
                              "sa"
                              };

            for (int i = 0; i < 7; i++)
            {
                CalndarGridItem item = new CalndarGridItem();
                item.setText(months[i]);
                item.setTextColor(Color.FromArgb(50, 63, 86));
                gridView.Controls.Add(item);
            }

            DateTime temp;

            DateTime today = DateTime.Today;

            if (addMonth != 0)
                today = today.AddMonths(addMonth);

            DateTime nextMonth = today.AddMonths(1);

            DateTime prevMonth = today.AddMonths(-1);


            temp = new DateTime(today.Year, today.Month, 1);


            int dayOfWeek = (int)temp.DayOfWeek;

            int dayOfPrevMonth = System.DateTime.DaysInMonth(prevMonth.Year, prevMonth.Month);

            for (int i = dayOfWeek - 1; i >= 0; i--)
            {
                CalndarGridItem item = new CalndarGridItem();
                item.setText((dayOfPrevMonth - i) + "");
                item.setTextColor(Color.FromArgb(50, 63, 86));
                gridView.Controls.Add(item);
            }


            int daysOfCurrentMonth = System.DateTime.DaysInMonth(today.Year, today.Month);


            for (int i = 1; i <= daysOfCurrentMonth; i++)
            {
                CalndarGridItem item = new CalndarGridItem();
                item.setText(i + "");

                if (addMonth == 0 && i == (int)DateTime.Today.Day)
                    item.makeToDay();

                item.setDateTime(today);

                item.getTextView().Cursor = Cursors.Hand;

                item.setOnGridItemClickListener(new EventHandler(onGridItemClickListener));

                String key = i + " " + today.ToString("MMMM").Substring(0, 3) + " " + today.Year;

                if (mEvents.ContainsKey(key.GetHashCode()))
                {
                    if (addMonth <= 0 && i < TODAY.Day)
                        item.hadNote();
                    else
                        item.hasNote();
                }

                gridView.Controls.Add(item);
            }

            int daysOfNextMonth = dayOfWeek - 1 + daysOfCurrentMonth;

            for (int i = 1; i < 35 - daysOfNextMonth; i++)
            {
                CalndarGridItem item = new CalndarGridItem();
                item.setText(i + "");
                item.setTextColor(Color.FromArgb(50, 63, 86));
                gridView.Controls.Add(item);
            }

            currentMonth.Text = today.ToString("MMMM");
            currentYear.Text = today.Year + "";

        }

        private void prevMonthBtn_onClick(object sender, EventArgs e)
        {
            currentMonthCounter--;
            createGrid(currentMonthCounter);
        }

        private void nextMonthBtn_onClick(object sender, EventArgs e)
        {
            currentMonthCounter++;
            createGrid(currentMonthCounter);
        }

        private void prevMonthBtn_Load(object sender, EventArgs e)
        {

        }

        private void setWeatherCondition()
        {
            getLanLong();
        }

        private async void getWeatherCondition(String lat, String lng)
        {
            string weburl = "http://api.openweathermap.org/data/2.5/weather?lat=" + lat + "&lon=" + lng + "&appid=691c5eb36e73b5e06f53817f27b5308b&mode=xml";

            try
            {
                var xml = await new WebClient().DownloadStringTaskAsync(new Uri(weburl));



                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xml);

                string szTemp = doc.DocumentElement.SelectSingleNode("temperature").Attributes["value"].Value;
                double temp = double.Parse(szTemp) - 273.16;
                weatherDegree.Text = temp.ToString("N0") + "°";

                String weatherCondition = doc.DocumentElement.SelectSingleNode("weather").Attributes["value"].Value;
                weatherCondition = Char.ToUpper(weatherCondition[0]).ToString() + weatherCondition.Substring(1, weatherCondition.Length - 1);
                if (weatherCondition.Length > 9)
                {
                    if (weatherCondition.Contains(" "))
                        weatherCondition = weatherCondition.Replace(" ", "\n");
                    else
                        weatherCondition = weatherCondition.Substring(0, 7) + "...";
                }
                weatherConditionText.Text = weatherCondition;

                setWeatherIcon(doc.DocumentElement.SelectSingleNode("weather").Attributes["icon"].Value);

            }
            catch (Exception e)
            {
                return;
            }
        }

        private void setWeatherIcon(String iconId)
        {

            String link = "http://openweathermap.org/img/w/" + iconId + ".png";

            WebClient client = new WebClient();
            Stream stream = client.OpenRead(link);
            Bitmap bitmap;
            bitmap = new Bitmap(stream);
            stream.Flush();
            stream.Close();
            client.Dispose();

            bitmap = changeColor(bitmap, 255, 255, 255);

            weatherIconPb.Image = bitmap;


        }

        private void getLanLong()
        {

            Watcher = new GeoCoordinateWatcher();

            Watcher.StatusChanged += Watcher_StatusChanged;

            Watcher.Start();

        }

        private void Watcher_StatusChanged(object sender, GeoPositionStatusChangedEventArgs e)
        {
            if (e.Status == GeoPositionStatus.Ready)
            {
                // Display the latitude and longitude.
                if (Watcher.Position.Location.IsUnknown)
                {
                    weatherDegree.Text = "404";
                }
                else
                {
                    String lat = Watcher.Position.Location.Latitude.ToString();
                    String lng = Watcher.Position.Location.Longitude.ToString();

                    getWeatherCondition(lat, lng);

                }
            }
        }

        private Bitmap changeColor(Bitmap sourceBitmap, float blueTint, float greenTint, float redTint)
        {
            BitmapData sourceData = sourceBitmap.LockBits(new Rectangle(0, 0,
                                    sourceBitmap.Width, sourceBitmap.Height),
                                    ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);


            byte[] pixelBuffer = new byte[sourceData.Stride * sourceData.Height];


            Marshal.Copy(sourceData.Scan0, pixelBuffer, 0, pixelBuffer.Length);


            sourceBitmap.UnlockBits(sourceData);


            float blue = 0;
            float green = 0;
            float red = 0;


            for (int k = 0; k + 4 < pixelBuffer.Length; k += 4)
            {
                blue = pixelBuffer[k] + (255 - pixelBuffer[k]) * blueTint;
                green = pixelBuffer[k + 1] + (255 - pixelBuffer[k + 1]) * greenTint;
                red = pixelBuffer[k + 2] + (255 - pixelBuffer[k + 2]) * redTint;


                if (blue > 255)
                { blue = 255; }


                if (green > 255)
                { green = 255; }


                if (red > 255)
                { red = 255; }


                pixelBuffer[k] = (byte)blue;
                pixelBuffer[k + 1] = (byte)green;
                pixelBuffer[k + 2] = (byte)red;


            }


            Bitmap resultBitmap = new Bitmap(sourceBitmap.Width, sourceBitmap.Height);


            BitmapData resultData = resultBitmap.LockBits(new Rectangle(0, 0,
                                    resultBitmap.Width, resultBitmap.Height),
                                    ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);


            Marshal.Copy(pixelBuffer, 0, resultData.Scan0, pixelBuffer.Length);
            resultBitmap.UnlockBits(resultData);


            return resultBitmap;
        }

        private void initEventList()
        {



        }

        private void addNoteToDay_Click_1(object sender, EventArgs e)
        {

            Form2 dialog = new Form2();

            DateTime dt = TODAY;

            dt = dt.AddMonths(currentMonthCounter);

            dialog.getSelectedDayView().Text = previouslySelected.Text + " " + dt.ToString("MMMM").Substring(0, 3) + " " + dt.Year;

            DialogResult dr = dialog.ShowDialog();

            if (dr == DialogResult.OK)
            {
                createGrid(currentMonthCounter);

                startEventsList();

            }



        }

        private void onGridItemClickListener(object sender, EventArgs e)
        {
            previouslySelected.BorderStyle = BorderStyle.None;

            if (int.Parse(((Label)sender).Text.ToString()) != TODAY.Day)
                ((Label)sender).BorderStyle = BorderStyle.Fixed3D;

            previouslySelected = ((Label)sender);

            startEventsList();

        }

        private void initEventsList(List<Event> events)
        {

            for (int i = 0; i < events.Count; i++)
            {
                EventItem item = new EventItem();
                item.getTime().Text = events[i].getTime();
                item.getLocation().Text = events[i].getLocation();
                item.getTitle().Text = events[i].getTitle();
                eventsScrollingView.Controls.Add(item);
            }

        }

        private void startEventsList()
        {

            DateTime temp = TODAY;
            temp = temp.AddMonths(currentMonthCounter);


            String key_temp = previouslySelected.Text + " " + temp.ToString("MMMM").Substring(0, 3) + " " + temp.Year;

            eventsScrollingView.Controls.Clear();

            if (mEvents.ContainsKey(key_temp.GetHashCode()))
                initEventsList(mEvents[key_temp.GetHashCode()]);
            else
                initEventsList(new List<Event>());

        }

        private void dragger_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void stopApp(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void GrantAccess(string fullPath)
        {
            if(!File.Exists(fullPath))
                Directory.CreateDirectory(fullPath);

            DirectoryInfo dInfo = new DirectoryInfo(fullPath);
            DirectorySecurity dSecurity = dInfo.GetAccessControl();
            dSecurity.AddAccessRule(new FileSystemAccessRule("everyone", FileSystemRights.FullControl,
                                                             InheritanceFlags.ObjectInherit | InheritanceFlags.ContainerInherit,
                                                             PropagationFlags.NoPropagateInherit, AccessControlType.Allow));
            dInfo.SetAccessControl(dSecurity);

            dInfo.SetAccessControl(dSecurity);

        }

    }
}
