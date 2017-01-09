using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace somSchedule.analysis
{
    class GameInfo
    {
        private int m_nightGameCount=0;
        private int m_dayGameCount = 0;

        private List<bool> m_NightGames = new List<bool>();
        private Dictionary<string, int> awayGames = new Dictionary<string, int>();
        private Dictionary<string, int> homeGames = new Dictionary<string, int>();

        public GameInfo() {

        }

        public void addHomeGame(int gameDay, string awayTeam, bool nightGame) {

            m_NightGames.Add(nightGame);
            if (nightGame)
                m_nightGameCount++;
            else
                m_dayGameCount++;

            if (!homeGames.ContainsKey(awayTeam))
                homeGames[awayTeam] = 0;

            homeGames[awayTeam]++;
        }

        public void addAwayGame(int gameDay, string homeTeam, bool nightGame)
        {
            m_NightGames.Add(nightGame);
            if (nightGame)
                m_nightGameCount++;
            else
                m_dayGameCount++;

            if (!awayGames.ContainsKey(homeTeam))
                awayGames[homeTeam] = 0;

            awayGames[homeTeam]++;
        }

        public int getHomeGameCount() {
            int homeGameCount = 0;
            foreach (string team in homeGames.Keys) {
                homeGameCount += homeGames[team];
            }
            return homeGameCount;
        }

        public int getAwayGameCount()
        {
            int awayGameCount = 0;
            foreach (string team in awayGames.Keys)
            {
                awayGameCount += awayGames[team];
            }
            return awayGameCount;
        }
    }
}
