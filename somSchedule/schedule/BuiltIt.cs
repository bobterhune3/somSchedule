using System;
using System.Collections.Generic;
using somSchedule.analysis;

namespace somSchedule.schedule
{
    class BuiltIt
    {
        private string[] div_fed = { "FED1", "FED2", "FED3", "FED4", "FED5", "FED6" };

        public BuiltIt() {
        }

        public void go() {
            List<string> games2 = buildInRound( 2, div_fed );
            foreach(string s in games2) {
                Console.Out.WriteLine(s);
            }
        }

        public List<string> buildInRound( int gamesInRound, string[] div1 ) {
            List<string> games = new List<string>();

            Dictionary<string, TeamData> data = new Dictionary<string, TeamData>();
            foreach (string team in div1)
                data[team] = new TeamData(team);
               
            for( int i1 = 0; i1 < div1.Length; i1++ ) {
                TeamData td1 = data[div1[i1]];

                for (int i2 = 0; i2 < div1.Length; i2++)
                {
                    if( i1 != i2 ) {
                        TeamData td2 = data[div1[i2]];
                        games.AddRange(addGames(td1, td2, gamesInRound));
                    }
                }
            }

            return games;
        }

        public List<String> addGames(TeamData td1, TeamData td2, int gamesInRound) {
            int td1HomeStreak = td1.HomeGameInARowCount;

            bool homeSeries = true;

            if(td1.opponents.ContainsKey(td2.TeamName)) { 
                int td1HomeVs = td1.opponents[td2.TeamName].getHomeGameCount();
                int td1AwayVs = td1.opponents[td2.TeamName].getAwayGameCount();
                homeSeries = td1HomeVs <= td1AwayVs;

            }
            if (td1.HomeGameInARowCount >= 2)
                homeSeries = false;


            List<String> games = new List<String>();
            if(homeSeries) //td1 is home
            {
                for(int i=0; i < gamesInRound; i++) {
                    td1.addHomeGame(td1.GameCount, td2.TeamName, true);
                    td2.addAwayGame(td2.GameCount, td1.TeamName, true);
                    games.Add(td1.GameCount + "," +td2.TeamName + "," + td1.TeamName + ",N");
                }
            }
            else {
                for (int i = 0; i < gamesInRound; i++)
                {
                    td2.addHomeGame(td1.GameCount, td1.TeamName, true);
                    td1.addAwayGame(td2.GameCount, td2.TeamName, true);
                    games.Add(td1.GameCount + "," + td1.TeamName + "," + td2.TeamName + ",N");
                }
            }
            return games;
        }


    }
}
