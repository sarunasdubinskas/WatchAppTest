using System;
using System.Collections.Generic;
using System.Text;

namespace WatchAppTest.Classes
{
    class Watch
    {
        private float degreesInClock = 360f;
        private float minutesInHour = 60f;
        private float HoursInClock = 12f;

        private float hours;
        private float minutes;
        private float degreesBtwArrows;


        public Watch(int hours, int minutes)
        {
            this.hours = Convert.ToSingle(hours);
            this.minutes = Convert.ToSingle(minutes);
        }

        public void CountDegreesBetweenArrows()
        {
            degreesBtwArrows = Math.Abs((degreesInClock * (minutes / minutesInHour)) - (degreesInClock * ((minutes + hours * minutesInHour) / (HoursInClock*minutesInHour))));
            if (degreesBtwArrows>180)
            {
                degreesBtwArrows = 360 - degreesBtwArrows;
            }
        }

        public void PrintDegreesBetweenArrows()
        {
            Console.WriteLine("Degreees between arrows: "+degreesBtwArrows);
        }
    }
}
