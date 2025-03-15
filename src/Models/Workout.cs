using FitnessTracker_PRG271.Interfaces;

namespace FitnessTracker_PRG271.Classes
{
    public abstract class Workout : ILogActivity
    {
        public string Type { get; set; }
        public int Duration { get; set; }
        public int CaloriesBurned { get; set; }

        protected Workout(string type, int duration, int caloriesBurned)
        {
            Type = type;
            Duration = duration;
            CaloriesBurned = caloriesBurned;
        }

        public abstract void Log();
    }
}
