using System;
using System.Collections.Generic;
using System.IO;
using somSchedule.analysis;

namespace somSchedule
{
    public class VerifySchedule
    {
        private string m_scheduleFileName = "";

        public VerifySchedule(String scheduleFileName ) {
            if (!File.Exists(scheduleFileName))
                throw new Exception("File " + scheduleFileName + " cannot be found");

            this.m_scheduleFileName = scheduleFileName;
        }

        public void verify( int expectedInDivision, int expectedOutOfDivision) {
            System.IO.StreamReader file = null;
            try
            {
                string line;

                List<ScheduleItem> items = new List<ScheduleItem>();

                // Read the file and display it line by line.
                file = new System.IO.StreamReader(m_scheduleFileName);
                while ((line = file.ReadLine()) != null)
                {
                    ScheduleItem item = buildScheduleLine(line);
                    items.Add(item);
                }

                Console.Out.WriteLine("Total Number of Games = " + items.Count);

                reviewSchedule(items);
            }
            finally
            {
                if (file != null)
                    file.Close();
            }
        }


        private ScheduleItem buildScheduleLine( string line) {
            ScheduleItem item = new ScheduleItem();
            item.parseLine(line);
            return item;
        }

        private void reviewSchedule( List<ScheduleItem> items) {
            int NumberOfDays = 0;
            int CurrentDayProcessed = 0;
            Dictionary<string, TeamData> teams = new Dictionary<string, TeamData>();
            foreach( ScheduleItem item in items ) {
                if(CurrentDayProcessed < item.GameDay) {
                    CurrentDayProcessed = item.GameDay;
                    NumberOfDays++;
                }
                if ( !teams.ContainsKey(item.HomeTeam))
                    teams[item.HomeTeam] = new TeamData(item.HomeTeam);
                if (!teams.ContainsKey(item.AwayTeam))
                    teams[item.AwayTeam] = new TeamData(item.AwayTeam);

                teams[item.HomeTeam].addHomeGame(item.GameDay, item.AwayTeam, item.NightGame);
                teams[item.AwayTeam].addAwayGame(item.GameDay, item.HomeTeam, item.NightGame);
            }

            Console.Out.WriteLine("Total Days of Games = " + NumberOfDays);


            foreach( string team in teams.Keys) {
                TeamData data = teams[team];
                Console.Out.WriteLine("  " + team +
                                          ": " + data.GameCount +
                                          "/ " + data.HomeGames() +
                                          "H-" + data.AwayGames() +
                                          "A days off=" + data.daysOff(NumberOfDays) +
                                          ", day games=" + data.DayGameCount
                                        );

                Console.Out.WriteLine(data.buidlGameDayString());

                foreach ( string opponent in data.opponents.Keys) {
                    GameInfo gi = data.opponents[opponent];
                    Console.Out.WriteLine("    vs " + opponent +
                              "/ " + gi.getHomeGameCount() +
                              "H-" + gi.getAwayGameCount()+"A"
                            );
                }
            }


        }

    }

}
