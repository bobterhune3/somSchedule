using System;
using System.Collections.Generic;
using System.IO;

namespace somSchedule.utils
{
    class Config
    {
        private string m_configFileName = "";

        public Config(String configFileName)
        {
            if (!File.Exists(configFileName))
                throw new Exception("File " + configFileName + " cannot be found");

            this.m_configFileName = configFileName;
        }

        public void readConfiguration()
        {
            System.IO.StreamReader file = null;
            try
            {
                string line;

                List<ScheduleItem> items = new List<ScheduleItem>();

                // Read the file and display it line by line.
                file = new System.IO.StreamReader(m_configFileName);
                while ((line = file.ReadLine()) != null)
                {
     
                }

                Console.Out.WriteLine("Total Number of Games = " + items.Count);

       
            }
            finally
            {
                if (file != null)
                    file.Close();
            }
        }
    }
}
