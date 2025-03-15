using FitnessTracker_PRG271.Classes;
using System;

namespace FitnessTracker_PRG271.Models.WorkoutTypes
{
    public class StrengthWorkout : Workout
    {
        public int WeightLifted { get; set; }

        public StrengthWorkout(string type, int duration, int caloriesBurned, int weightLifted)
            : base(type, duration, caloriesBurned)
        {
            WeightLifted = weightLifted;
        }

        public override void Log()
        {
            Console.WriteLine($"Strength Workout Logged: {Type}, Duration: {Duration} mins, Calories Burned: {CaloriesBurned}, Weight Lifted: {WeightLifted} kg");
        }
    }
}