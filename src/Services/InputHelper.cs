using System;

namespace FitnessTracker_PRG271.Services
{
    public static class InputHelper
    {
        public static int GetValidInteger(string prompt)
        {
            int result;
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();
                if (int.TryParse(input, out result) && result >= 0)
                {
                    return result;
                }
                Console.WriteLine("Invalid input. Please enter a valid non-negative integer.");
            }
        }
    }
}
