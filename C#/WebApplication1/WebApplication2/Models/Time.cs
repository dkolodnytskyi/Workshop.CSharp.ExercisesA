﻿namespace WebApplication2.Models
{
    public class Time
    {
        public DateOnly Day { get; set; }
        public TimeOnly StartHour { get; set; }
        public TimeOnly EndHour { get; set; }
        public bool BookedUp { get; set; }

        public Time(DateOnly day, TimeOnly startHour, TimeOnly endHour)
        {
            Day = day;
            StartHour = startHour;
            EndHour = endHour;
            BookedUp = false;
        }

        public void SetStatus(bool Booked)
        {
            BookedUp = Booked;
        }

        public override string ToString()
        {
            return Day.ToString() + " " + StartHour.ToString();
        }
    }
}