using FitnessTracker_PRG271.Services;
using System;

namespace FitnessTracker_PRG271
{
    class Program
    {
        static void Main(string[] args)
        {
            FitnessTracker fitnessTracker = new FitnessTracker();
            fitnessTracker.OnProgressUpdated += (message) => Console.WriteLine(message);
            fitnessTracker.StartReminder();

            int choice;
            do
            {
                Console.WriteLine("");
                Console.WriteLine("==============================================================================");
                Console.WriteLine("==============================================================================");
                Console.WriteLine("");

                fitnessTracker.ShowMenu();
                choice = GetValidInteger("Choose an option: ");

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("");
                        fitnessTracker.LogWorkout();
                        break;
                    case 2:
                        Console.WriteLine("");
                        fitnessTracker.LogMeal();
                        break;
                    case 3:
                        Console.WriteLine("");
                        fitnessTracker.ViewProgress();
                        break;
                    case 4:
                        Console.WriteLine("");
                        Console.WriteLine("Exiting the application. Stay healthy!");
                        Console.ReadLine();
                        break;
                    default:
                        Console.WriteLine("");
                        Console.WriteLine("Invalid choice! Please select again.");
                        break;
                }
            } while (choice != 4);
        }

        static int GetValidInteger(string prompt)
        {
            int result;
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();
                if (int.TryParse(input, out result))
                {
                    return result;
                }
                Console.WriteLine("Invalid input. Please enter a valid integer.");
            }
        }
    }
}