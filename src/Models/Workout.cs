using FitnessTracker_PRG271.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker_PRG271.Classes
{
    // Class to represent a workout
    public class Workout : ILogActivity
    {
        public string Type { get; set; }
        public int Duration { get; set; } // Duration in minutes
        public int CaloriesBurned { get; set; }

        public Workout(string type, int duration, int caloriesBurned)
        {
            Type = type;
            Duration = duration;
            CaloriesBurned = caloriesBurned;
        }

        public void Log()
        {
            Console.WriteLine($"Workout Logged: {Type}, Duration: {Duration} mins, Calories Burned: {CaloriesBurned}");
        }
    }
}
