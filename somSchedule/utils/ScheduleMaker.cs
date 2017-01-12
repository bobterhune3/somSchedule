using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace somSchedule.utils
{
    class ScheduleMaker
    {
        private string m_fileName;
        private string m_fileOutName;
        private Dictionary<string, string> m_cfg;

        public ScheduleMaker(string fileIn, string fileOut, Dictionary<string, string> cfg ) {
            m_fileName = fileIn;
            m_fileOutName = fileOut;
            m_cfg = cfg;
        }


        public void buildSchedule()
        {
            System.IO.StreamReader fileIn = null;
            System.IO.StreamWriter fileOut = null;
            try
            {
                string line;
                // Read the file and display it line by line.
                fileIn = new System.IO.StreamReader(m_fileName);
                fileOut = new System.IO.StreamWriter(m_fileOutName);
                while ((line = fileIn.ReadLine()) != null)
                {
                    string[] values = line.Split(',');
                    if( !values[0].Equals("Day")) {
                        int day = Convert.ToInt32(values[0]);
                        string road = values[1];
                        string home = values[2];
                        string daynight = values[3];

                        StringBuilder sb = new StringBuilder();
                        sb.Append(day);
                        sb.Append(",");
                        sb.Append(lookupTeam(road));
                        sb.Append(",");
                        sb.Append(lookupTeam(home));
                        sb.Append(",");
                        sb.Append(daynight);

                        fileOut.WriteLine(sb.ToString());
                    }
                }
            }
            finally
            {
                if (fileIn != null)
                    fileIn.Close();
                if (fileOut != null)
                    fileOut.Close();
            }
        }

        private string lookupTeam(string code) {
            return m_cfg[code];
        }
    }
}
