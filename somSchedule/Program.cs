using System;
using somSchedule.utils;
using somSchedule.schedule;
using System.Collections.Generic;

namespace somSchedule
{
    class Program
    {
        static void Main(string[] args)
        {
            Config cfg = new Config("scheduleConfig.txt");
            Dictionary<string, string> data = cfg.readConfiguration();

            ScheduleMaker schedMaker = new ScheduleMaker("ScheduleTemplate.csv", "ScheduleOut.TXT", data);
            schedMaker.buildSchedule();

            printVerification("ScheduleOut.csv");


            Console.WriteLine("Press ESC to exit");
            ConsoleKey key;
            do
            {
                key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.S)
                {

                }
            } while (key != ConsoleKey.Escape);
        }

        private static void printVerification(String fileName) { 
            VerifySchedule verify = new VerifySchedule(fileName);
            verify.verify(16, 8);

        }

    }
}
