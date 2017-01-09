using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace somSchedule
{
    class ScheduleItem
    {
        int gameDay;
        string awayTeam;
        string homeTeam;
        bool nightGame;

        public ScheduleItem() {
        }

        public bool parseLine( string line) {
            string[] values = line.Split(',');
            GameDay = Convert.ToInt32(values[0]);
            AwayTeam = values[1];
            HomeTeam = values[2];
            NightGame = values[3].Equals("N");
            return true;
        }


        public int GameDay {
            get { return gameDay; }
            set { gameDay = value;  }
        }
        public string AwayTeam {
            get { return awayTeam; }
            set { awayTeam = value; }
        }
        public string HomeTeam {
            get { return homeTeam; }
            set { homeTeam = value; }
        }
        public bool NightGame {
            get { return nightGame; }
            set { nightGame = value; }
        }

    }
}
