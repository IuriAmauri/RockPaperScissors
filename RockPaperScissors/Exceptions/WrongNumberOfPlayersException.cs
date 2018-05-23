using System;

namespace RockPaperScissors
{
    public class WrongNumberOfPlayersException : Exception
    {
        public WrongNumberOfPlayersException() : base()
        {
        }

        public WrongNumberOfPlayersException(string message) : base(message)
        {
        }
    }
}
