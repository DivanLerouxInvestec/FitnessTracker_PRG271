using FitnessTracker_PRG271.Classes;
using FitnessTracker_PRG271.Delegates;
using FitnessTracker_PRG271.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading;

namespace FitnessTracker_PRG271.Services
{
    public class FitnessTracker
    {
        private List<ILogActivity> activities; // Using ILogActivity for polymorphism
        private Progress progress;
        private WorkoutLogger workoutLogger;
        private MealLogger mealLogger;

        // Custom event for progress updates
        public event Action<string> OnProgressUpdated;

        public FitnessTracker()
        {
            activities = new List<ILogActivity>();
            progress = new Progress();
            workoutLogger = new WorkoutLogger(activities, progress);
            mealLogger = new MealLogger(activities, progress);
            workoutLogger.OnProgressUpdated += OnProgressUpdated;
            mealLogger.OnProgressUpdated += OnProgressUpdated;
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
            // Start a thread to send reminders every 2 minutes
            Thread reminderThread = new Thread(() =>
            {
                while (true)
                {
                    Thread.Sleep(120000); // Sleep for 2 minutes
                    OnProgressUpdated?.Invoke("Don't forget to log your activities!");
                }
            });
            reminderThread.IsBackground = true;
            reminderThread.Start();
        }

        public void LogWorkout()
        {
            workoutLogger.LogWorkout();
        }

        public void LogMeal()
        {
            mealLogger.LogMeal();
        }

        public void ViewProgress()
        {
            Console.WriteLine("Progress Summary:");
            Console.WriteLine($"Total Calories: {progress.TotalCalories}");
            Console.WriteLine($"Workouts Logged: {progress.WorkoutsLogged}");
            Console.WriteLine($"Meals Logged: {progress.MealsLogged}");

            // Display the logged activities
            Console.WriteLine("\nLogged Activities:");
            if (activities.Count == 0)
            {
                Console.WriteLine("No activities logged yet.");
            }
            else
            {
                foreach (var activity in activities)
                {
                    activity.Log(); // This will call the Log method of each activity
                }
            }
        }
    }
}
