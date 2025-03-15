using FitnessTracker_PRG271.Interfaces;
using System;

namespace FitnessTracker_PRG271.Classes
{
    // Class to represent a meal
    public class Meal : ILogActivity
    {
        public string Name { get; set; }
        public int Calories { get; set; }
        public string MealType { get; set; } // e.g., Breakfast, Lunch, Dinner

        public Meal(string name, int calories, string mealType)
        {
            Name = name;
            Calories = calories;
            MealType = mealType;
        }

        public void Log()
        {
            Console.WriteLine($"Meal Logged: {Name}, Calories: {Calories}, Meal Type: {MealType}");
        }
    }
}
