using System;
using somSchedule.utils;


namespace somSchedule
{
    class Program
    {
        static void Main(string[] args)
        {
            Config cfg = new Config("scheduleConfig.txt");
            cfg.readConfiguration();

            printVerification();

        }

        private static void printVerification() { 
            VerifySchedule verify = new VerifySchedule("2015N2SC.TXT");
            verify.verify(16, 8);

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
    }
}
