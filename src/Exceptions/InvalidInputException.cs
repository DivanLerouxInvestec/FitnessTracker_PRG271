using System;

namespace FitnessTracker_PRG271.Exceptions
{
    // Custom exception for invalid inputs
    public class InvalidInputException : Exception
    {
        public InvalidInputException(string message) : base(message) { }
    }
}
