namespace FitnessApp.Models
{
    public class Diet
    {
        public int id { get; set; }
        public string foodName { get; set; }
        public string foodIngredients { get; set; }
        public string foodInstructions { get; set; }
        public string foto { get; set; }
        public double protein { get; set; }
        public double carbonFat { get; set; }
        public int calorificValue { get; set; }
        public int typeOfMeal { get; set; }

    }
}
    