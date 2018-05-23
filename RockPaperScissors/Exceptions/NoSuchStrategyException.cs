using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
