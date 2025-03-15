using FitnessTracker_PRG271.Classes;
using FitnessTracker_PRG271.Delegates;
using FitnessTracker_PRG271.Exceptions;
using FitnessTracker_PRG271.Interfaces;
using FitnessTracker_PRG271.Models.WorkoutTypes;
using System;
using System.Collections.Generic;

namespace FitnessTracker_PRG271.Services
{
    public class WorkoutLogger
    {
        private List<ILogActivity> activities;
        private Progress progress;
        public event Action<string> OnProgressUpdated;
        public LogActivityDelegate LogActivity;

        public WorkoutLogger(List<ILogActivity> activities, Progress progress)
        {
            this.activities = activities;
            this.progress = progress;
            LogActivity += Log; // Subscribe to the delegate
        }

        public void LogWorkout()
        {
            try
            {
                Console.Write("Enter workout type (Cardio/Strength): ");
                string type = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(type) || (type != "Cardio" && type != "Strength"))
                    throw new InvalidInputException("Workout type must be either 'Cardio' or 'Strength'.");

                int duration = InputHelper.GetValidInteger("Enter duration (in minutes): ");
                int caloriesBurned = InputHelper.GetValidInteger("Enter calories burned: ");

                // Validate input
                if (duration < 0 || caloriesBurned < 0)
                    throw new InvalidInputException("Duration and calories burned must be non-negative.");

                ILogActivity workout;

                // Create specific workout type
                if (type.Equals("Cardio", StringComparison.OrdinalIgnoreCase))
                {
                    int heartRate = InputHelper.GetValidInteger("Enter heart rate: ");
                    workout = new CardioWorkout(type, duration, caloriesBurned, heartRate);
                }
                else // Strength
                {
                    int weightLifted = InputHelper.GetValidInteger("Enter weight lifted: ");
                    workout = new StrengthWorkout(type, duration, caloriesBurned, weightLifted);
                }

                activities.Add(workout);
                progress.TotalCalories -= caloriesBurned;
                progress.WorkoutsLogged++;

                // Use the delegate to log the workout
                LogActivity?.Invoke(workout);

                // Notify progress update
                OnProgressUpdated?.Invoke($"Workout logged! Total Calories: {progress.TotalCalories}");
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
