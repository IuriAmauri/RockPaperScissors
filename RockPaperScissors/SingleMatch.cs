using RockPaperScissors.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors
{
    public class SingleMatch
    {
        public static Dictionary<string, string> getMatchPlays()
        {
            Dictionary<string, string> plays = new Dictionary<string, string>
            {
                { "Armando", "P" },
                { "Dave", "S" }
            };

            return plays;
        }

        public KeyValuePair<string, string> RunMatch(Dictionary<string, string> plays)
        {
            Console.WriteLine(String.Format("Match: {0}:{1} against {2}:{3}", plays.First().Key, plays.First().Value,
                                                                              plays.Last().Key, plays.Last().Value));
            var winner = Rps_Game_Winner(plays);

            Console.WriteLine(String.Format("Match winner is: {0} - play: {1}", winner.Key, winner.Value));
            Console.WriteLine("");
            return winner;
        }

        public static KeyValuePair<string, string> Rps_Game_Winner(Dictionary<string, string> plays)
        {
            CheckPlays(plays);
            return CheckWinner(plays);
        }

        private static void CheckPlays(Dictionary<string, string> plays)
        {
            if (plays.Count() != 2)
                throw new WrongNumberOfPlayersException("Wrong number of players!");

            if (ExistsInvalidPlays(plays))
                throw new NoSuchStrategyException("No such strategy!");
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
    }
}
