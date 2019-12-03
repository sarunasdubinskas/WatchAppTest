using System;
using System.Collections.Generic;
using System.Text;
using WatchAppTest.Enums;

namespace WatchAppTest.Classes
{
    class InputReader
    {
        public int Hours { get; private set; }
        public int Minutes { get; private set; }

        public bool InputCorrect = false;

        public InputReader ()
        {
        }

        public void ParseInput(string input)
        {
            int separatorPos;
            switch (CasePicker(input))
                {
                case HoursSeparators.Unrecognized:
                    {
                        Console.WriteLine("Wasn't able to process time input. Try one of these formats: HH:MM; HH.MM; HH,MM");
                        break;
                    }
                case HoursSeparators.Normal:
                    {
                        separatorPos = input.IndexOf((char)HoursSeparators.Normal);
                        Hours = Convert.ToInt32(input.Substring(0, separatorPos));
                        Minutes = Convert.ToInt32(input.Substring(separatorPos+1));
                        InputCorrect = !InputCorrect;
                        break;
                    }
                case HoursSeparators.Dot:
                    {
                        separatorPos = input.IndexOf((char)HoursSeparators.Dot);
                        Hours = Convert.ToInt32(input.Substring(0, separatorPos));
                        Minutes = Convert.ToInt32( 60 * Convert.ToDouble("0," + input.Substring(separatorPos+1)));
                        InputCorrect = !InputCorrect;
                        break;
                    }
                case HoursSeparators.Comma:
                    {
                        separatorPos = input.IndexOf((char)HoursSeparators.Comma);
                        Hours = Convert.ToInt32(input.Substring(0, separatorPos));
                        Minutes = Convert.ToInt32(60 * Convert.ToDouble("0," + input.Substring(separatorPos+1)));
                        InputCorrect = !InputCorrect;
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Unexpected case switch value at InputReader.cs");
                        break;
                    }
                }

            while (Minutes>=60)
            {
                Minutes %= 60;
                Hours++;
            }

            while (Hours >= 12)
            {
                Hours %= 12;
            }
        }

        private HoursSeparators CasePicker (string input)
        {
            if(input.Contains(":"))
            { return HoursSeparators.Normal; }
            else if (input.Contains("."))
            { return HoursSeparators.Dot; }
            else if (input.Contains(","))
            { return HoursSeparators.Comma; }
            else
            { return HoursSeparators.Unrecognized; }
        }
    }
}
