using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace somSchedule.analysis
{
    class TeamData
    {
        private string m_abrv = "";
        private int m_gameCount = 0;
        private int m_DayGameCount = 0;
        public Dictionary<string, GameInfo> opponents = new Dictionary<string, GameInfo>();
        private char[] m_gameDays = new char[200];
        private int m_HomeGameInARowCount = 0;

        public TeamData(string abrv) {
            m_abrv = abrv;
        }

        public string TeamName {
            get { return m_abrv; }
        }

        public int GameCount {
            get { return m_gameCount; }
        }

        public int DayGameCount {
            get { return m_DayGameCount; }
        }

        public int HomeGames() {
            int games = 0;
            foreach( string team in opponents.Keys ) {
                games += opponents[team].getHomeGameCount();
            }
            return games;
        }

        public int AwayGames() {
            int games = 0;
            foreach (string team in opponents.Keys)
            {
                games += opponents[team].getHomeGameCount();
            }
            return games;
        }

        public int HomeGameInARowCount
        {
            get { return m_HomeGameInARowCount; }
        }

        public void addHomeGame( int gameDay, string awayTeam, bool nightGame) {
            m_gameDays[gameDay] = 'H';
            m_gameCount++;
            if( !opponents.ContainsKey(awayTeam) ) {
                opponents[awayTeam] = new GameInfo(); 
            }
            opponents[awayTeam].addHomeGame(gameDay, awayTeam, nightGame);
            if (!nightGame)
                m_DayGameCount++;
            m_HomeGameInARowCount++;
        }

        public void addAwayGame( int gameDay, string homeTeam, bool nightGame)
        {
            m_gameDays[gameDay] = 'V';
            m_gameCount++;
            if (!opponents.ContainsKey(homeTeam)) {
                opponents[homeTeam] = new GameInfo();
            }
            opponents[homeTeam].addAwayGame(gameDay, homeTeam, nightGame);
            if (!nightGame)
                m_DayGameCount++;
            m_HomeGameInARowCount = 0;
        }

        public int daysOff(int numOfDays) {
            int daysOff = 0;
            int counter = 0;
            foreach( char gtype in m_gameDays ) {
                if (counter > numOfDays)
                    break;
                if (gtype != 'H' && gtype != 'V')
                    daysOff++;
                counter++;
            }
            return daysOff;
        }

        public string buidlGameDayString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (char gtype in m_gameDays)
            {
                sb.Append(gtype);
            }
            return sb.ToString();
        }
    }
}
