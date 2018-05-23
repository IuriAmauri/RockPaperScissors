using System;
using System.Collections.Generic;
using System.Linq;

namespace RockPaperScissors
{
    class Program
    {
        private Dictionary<string, string> keyValues { get; set; }

        static void Main(string[] args)
        {

        }

        public void rps_game_winner(Dictionary<string, string> plays)
        {
            if (plays.Count() != 2)
                throw new WrongNumberOfPlayersException("Wrong number of players!");

            if (plays.Any())
        }
    }
}
