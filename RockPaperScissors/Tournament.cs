using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors
{
    public class Tournament
    {
        public static List<Dictionary<string, string>> getTournamentPlays()
        {
            List<Dictionary<string, string>> plays = new List<Dictionary<string, string>>
            {
                AddBracket(new KeyValuePair<string, string>("Armando", "P"), new KeyValuePair<string, string>("Dave", "S")),
                AddBracket(new KeyValuePair<string, string>("Richard", "R"), new KeyValuePair<string, string>("Michael", "S")),
                AddBracket(new KeyValuePair<string, string>("Allen", "S"), new KeyValuePair<string, string>("Omer", "P")),
                AddBracket(new KeyValuePair<string, string>("David E.", "R"), new KeyValuePair<string, string>("Richard X.", "P"))
            };

            return plays;
        }

        private static Dictionary<string, string> AddBracket(KeyValuePair<string, string> move1, KeyValuePair<string, string> move2)
        {
            var bracket = new Dictionary<string, string>
            {
                { move1.Key, move1.Value },
                { move2.Key, move2.Value }
            };

            return bracket;
        }

        public void RunTournament(List<Dictionary<string, string>> brackets)
        {
            CheckBrackets(brackets);
            var matchWinners = new List<KeyValuePair<string, string>>();

            foreach (var gamePlays in brackets)
            {
                matchWinners.Add(new SingleMatch().RunMatch(gamePlays));
            }

            if (matchWinners.Count() == 1)
            {
                Console.WriteLine(String.Format("Tournament winner is: {0} - play: {1}", matchWinners.First().Key, matchWinners.First().Value));
                return;
            }

            brackets.Clear();

            for (int i = 0; i < matchWinners.Count() / 2; i++)
            {
                brackets.Add(AddBracket(matchWinners[i], matchWinners[(i + 1)]));
                matchWinners.RemoveAt(i);
                matchWinners.RemoveAt(i + 1);
            }

            RunTournament(brackets);
        }

        public void CheckBrackets(List<Dictionary<string, string>> brackets)
        {
            if (brackets.Count() > 1 && brackets.Count() % 2 != 0)
                throw new WrongNumberOfPlayersException("Wrong number of brackets!");
        }
    }
}
