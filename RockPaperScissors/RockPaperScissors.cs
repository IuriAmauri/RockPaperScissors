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
            Console.WriteLine("Run match or tournament? Type 'M' for match or 'T' for tournament.");
            var type = Console.ReadLine();

            try
            {
                if (type.Equals("M") || type.Equals("m"))
                    new SingleMatch().RunMatch(SingleMatch.getMatchPlays());
                else if (type.Equals("T") || type.Equals("t"))
                    new Tournament().RunTournament(Tournament.getTournamentPlays());
                else
                {
                    Console.WriteLine("Invalid option!");
                    Main(args);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);                
            }
        }
    }
}
