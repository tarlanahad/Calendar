using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Calendar
{
    [Serializable]
    public class Event
    {
        public String Title, Location, Time, Date;

        public Event()
        {

        }

        public Event(String Title, String Location, String Time, String Date)
        {
            this.Title = Title;
            this.Location = Location;
            this.Time = Time;
            this.Date = Date;
        }

        public String getTitle()
        {
            return Title;
        }

        public String getLocation()
        {
            return Location;
        }

        public String getTime()
        {
            return Time;
        }

        public String getDate()
        {
            return Date;
        }

    }
}
