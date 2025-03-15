namespace FitnessTracker_PRG271.Classes
{
    // Class to represent progress
    public class Progress
    {
        public int TotalCalories { get; set; }
        public int WorkoutsLogged { get; set; }
        public int MealsLogged { get; set; }

        public Progress()
        {
            TotalCalories = 0;
            WorkoutsLogged = 0;
            MealsLogged = 0;
        }
    }
}
