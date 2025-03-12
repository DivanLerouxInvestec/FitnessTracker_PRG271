using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker_PRG271
{
    // Custom exception for invalid inputs
    public class InvalidInputException : Exception
    {
        public InvalidInputException(string message) : base(message) { }
    }
}
