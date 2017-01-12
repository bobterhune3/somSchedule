using System;
using System.Collections.Generic;
using System.IO;

namespace somSchedule.utils
{
    class Config
    {
        private string m_configFileName = "";
        private int m_year = 2015;

        public Config(String configFileName)
        {
            if (!File.Exists(configFileName))
                throw new Exception("File " + configFileName + " cannot be found");

            this.m_configFileName = configFileName;
        }

        public Dictionary<string, string> readConfiguration()
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            System.IO.StreamReader file = null;
            try
            {
                string line;

                List<ScheduleItem> items = new List<ScheduleItem>();

                // Read the file and display it line by line.
                file = new System.IO.StreamReader(m_configFileName);
                while ((line = file.ReadLine()) != null)
                {
                    if (line.Length > 0) {
                        
                        string[] values = line.Split('=');
                        string key = values[0];
                        string value = values[1];
                        if (value.Equals("YEAR"))
                            m_year = Convert.ToInt32(value);
                        Console.WriteLine(key+"="+value);
                        result.Add(key, value);
                    }
                }     
            }
            finally
            {
                if (file != null)
                    file.Close();
            }
            return result;
        }
    }
}
