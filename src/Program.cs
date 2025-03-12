using FitnessTracker_PRG271.Classes;
using FitnessTracker_PRG271.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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
                Console.WriteLine("==========================");
                Console.WriteLine("==========================");
                Console.WriteLine("");

                fitnessTracker.ShowMenu();
                Console.Write("Choose an option: ");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        fitnessTracker.LogWorkout();
                        break;
                    case 2:
                        fitnessTracker.LogMeal();
                        break;
                    case 3:
                        fitnessTracker.ViewProgress();
                        break;
                    case 4:
                        Console.WriteLine("Exiting the application. Stay healthy!");
                        break;
                    default:
                        Console.WriteLine("Invalid choice! Please select again.");
                        break;
                }
            } while (choice != 4);
        }
    }
}
