using FitnessTracker_PRG271.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FitnessTracker_PRG271.Services
{
    // Class to manage the fitness tracker
    public class FitnessTracker
    {
        private List<Workout> workouts;
        private List<Meal> meals;
        private Progress progress;

        // Custom event for progress updates
        public event Action<string> OnProgressUpdated;

        public FitnessTracker()
        {
            workouts = new List<Workout>();
            meals = new List<Meal>();
            progress = new Progress();
        }

        public void LogWorkout()
        {
            try
            {
                Console.Write("Enter workout type: ");
                string type = Console.ReadLine();
                Console.Write("Enter duration (in minutes): ");
                int duration = int.Parse(Console.ReadLine());
                Console.Write("Enter calories burned: ");
                int caloriesBurned = int.Parse(Console.ReadLine());

                // Validate input
                if (duration < 0 || caloriesBurned < 0)
                    throw new InvalidInputException("Duration and calories burned must be non-negative.");

                Workout workout = new Workout(type, duration, caloriesBurned);
                workouts.Add(workout);
                progress.TotalCalories -= caloriesBurned;
                progress.WorkoutsLogged++;

                // Log the workout
                workout.Log();

                // Notify progress update
                OnProgressUpdated?.Invoke($"Workout logged! Total Calories: {progress.TotalCalories}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input format. Please enter a valid number.");
            }
            catch (InvalidInputException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void LogMeal()
        {
            try
            {
                Console.Write("Enter meal name: ");
                string name = Console.ReadLine();
                Console.Write("Enter calories: ");
                int calories = int.Parse(Console.ReadLine());
                Console.Write("Enter meal type (Breakfast, Lunch, Dinner): ");
                string mealType = Console.ReadLine();

                // Validate input
                if (calories < 0)
                    throw new InvalidInputException("Calories must be non-negative.");

                Meal meal = new Meal(name, calories, mealType);
                meals.Add(meal);
                progress.TotalCalories += calories;
                progress.MealsLogged++;

                // Log the meal
                meal.Log();

                // Notify progress update
                OnProgressUpdated?.Invoke($"Meal logged! Total Calories: {progress.TotalCalories}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input format. Please enter a valid number.");
            }
            catch (InvalidInputException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void ViewProgress()
        {
            Console.WriteLine("Progress Summary:");
            Console.WriteLine($"Total Calories: {progress.TotalCalories}");
            Console.WriteLine($"Workouts Logged: {progress.WorkoutsLogged}");
            Console.WriteLine($"Meals Logged: {progress.MealsLogged}");
        }

        public void ShowMenu()
        {
            Console.WriteLine("Health and Fitness Tracker");
            Console.WriteLine("1. Log Workout");
            Console.WriteLine("2. Log Meal");
            Console.WriteLine("3. View Progress");
            Console.WriteLine("4. Exit");
        }

        public void StartReminder()
        {
            // Start a thread to send reminders every hour
            Thread reminderThread = new Thread(() =>
            {
                while (true)
                {
                    //Thread.Sleep(3600000); // Sleep for 1 hour
                    Thread.Sleep(30000); // Sleep for 30 seconds - For Testing

                    OnProgressUpdated?.Invoke("Don't forget to log your activities!");
                }
            });
            reminderThread.IsBackground = true;
            reminderThread.Start();
        }
    }
}
