using FitnessTracker_PRG271.Classes;
using FitnessTracker_PRG271.Delegates;
using FitnessTracker_PRG271.Exceptions;
using FitnessTracker_PRG271.Interfaces;
using System;
using System.Collections.Generic;

namespace FitnessTracker_PRG271.Services
{
    public class MealLogger
    {
        private List<ILogActivity> activities;
        private Progress progress;
        public event Action<string> OnProgressUpdated;
        public LogActivityDelegate LogActivity;

        public MealLogger(List<ILogActivity> activities, Progress progress)
        {
            this.activities = activities;
            this.progress = progress;
            LogActivity += Log; // Subscribe to the delegate
        }

        public void LogMeal()
        {
            try
            {
                Console.Write("Enter meal name: ");
                string name = Console.ReadLine();
                int calories = InputHelper.GetValidInteger("Enter calories: ");
                Console.Write("Enter meal type (Breakfast, Lunch, Dinner): ");
                string mealType = Console.ReadLine();

                // Validate input
                if (calories < 0)
                    throw new InvalidInputException("Calories must be non-negative.");

                Meal meal = new Meal(name, calories, mealType);
                activities.Add(meal);
                progress.TotalCalories += calories;
                progress.MealsLogged++;

                // Use the delegate to log the meal
                LogActivity?.Invoke(meal);

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

        private void Log(ILogActivity activity)
        {
            activity.Log();
        }
    }
}
