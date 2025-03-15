using FitnessTracker_PRG271.Classes;
using System;

namespace FitnessTracker_PRG271.Models.WorkoutTypes
{
    public class CardioWorkout : Workout
    {
        public int HeartRate { get; set; }

        public CardioWorkout(string type, int duration, int caloriesBurned, int heartRate)
            : base(type, duration, caloriesBurned)
        {
            HeartRate = heartRate;
        }

        public override void Log()
        {
            Console.WriteLine($"Cardio Workout Logged: {Type}, Duration: {Duration} mins, Calories Burned: {CaloriesBurned}, Heart Rate: {HeartRate} bpm");
        }
    }
}
