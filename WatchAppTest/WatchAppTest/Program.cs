using System;
using WatchAppTest.Classes;

namespace WatchAppTest
{
    class Program
    {
        static void Main()
        {
            CountDegreesBetweenInputHoursProgram();
            Console.ReadLine();
        }

        private static void CountDegreesBetweenInputHoursProgram()
        {
            Console.WriteLine("Please input time");
            InputReader input = new InputReader();
            while (!input.InputCorrect)
            {
                input.ParseInput(Console.ReadLine());
            }
            Watch watch = new Watch(input.Hours, input.Minutes);
            Console.WriteLine("Inputed: " + input.Hours + ":" + input.Minutes);
            watch.CountDegreesBetweenArrows();
            watch.PrintDegreesBetweenArrows();
        }
    }
}
