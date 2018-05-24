using System;

namespace RockPaperScissors.Exceptions
{
    public class NoSuchStrategyException : Exception
    {
        public NoSuchStrategyException() : base()
        {
        }

        public NoSuchStrategyException(string message) : base(message)
        {
        }
    }
}
