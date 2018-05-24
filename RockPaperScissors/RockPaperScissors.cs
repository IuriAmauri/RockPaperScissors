using RockPaperScissors.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RockPaperScissors
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Run match or tournament? Type 'M' or 'T':");
            var type = Console.ReadLine();

            if (type.Equals("M"))
                RunMatch(getMatchPlays());
            else if (type.Equals("T"))
                RunTournament(getTournamentPlays());
            else
            {
                Console.WriteLine("Invalid option!");
                Main(args);
            }
        }

        private static void RunTournament(Dictionary<string, string> plays)
        {
            for (int i = 0; i < (plays.Count()/2); i++)
            {
                Dictionary<string, string> matchPlays = new Dictionary<string, string>();
                RunMatch(matchPlays);
            }           
        }

        private static void RunMatch(Dictionary<string, string> plays)
        {
            try
            {
                var winner = Rps_Game_Winner(plays);
                Console.WriteLine(String.Format("Match winner is: {0} - play: {1}", winner.Key, winner.Value));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                foreach (var play in plays)
                {
                    Console.WriteLine(string.Format("{0} - {1}", play.Key, play.Value));
                }
            }
        }

        public static KeyValuePair<string, string> Rps_Game_Winner(Dictionary<string, string> plays)
        {
            if (plays.Count() != 2)
                throw new WrongNumberOfPlayersException("Wrong number of players!");

            if (ExistsInvalidPlays(plays))
                throw new NoSuchStrategyException("No such strategy!");

            return CheckWinner(plays);
        }

        private static bool ExistsInvalidPlays(Dictionary<string, string> plays)
        {
            var validPlays = plays.Where(w => w.Value.Equals("R") || w.Value.Equals("P") || w.Value.Equals("S"));
            return plays.Count() != validPlays.Count();
        }

        public static KeyValuePair<string, string> CheckWinner(Dictionary<string, string> plays)
        {
            var winner = new KeyValuePair<string, string>();

            var move1 = plays.First();
            var move2 = plays.Last();

            if (move1.Value.Equals("R"))
                winner = move2.Value.Equals("P") ? move2 : move1;
            else if (move1.Value.Equals("P"))
                winner = move2.Value.Equals("S") ? move2 : move1;
            else
                winner = move2.Value.Equals("R") ? move2 : move1;

            return winner;
        }

        private static Dictionary<string, string> getMatchPlays()
        {
            Dictionary<string, string> plays = new Dictionary<string, string>();
            plays.Add("Armando", "S");
            plays.Add("Dave", "S");

            return plays;
        }

        private static Dictionary<string, string> getTournamentPlays()
        {
            Dictionary<string, string> plays = new Dictionary<string, string>();
            plays.Add("Armando", "S");
            plays.Add("Dave", "S");

            return plays;
        }
    }
}
