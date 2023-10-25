using FitnessApp.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.BLL.GetModels
{
    public class GetMeal
    {
        public int Id { get; set; }
        public string FoodName { get; set; }
        public string FoodIngredients { get; set; }
        public string FoodInstructions { get; set; }
        public string Foto { get; set; }
        public double Protein { get; set; }
        public double Fat { get; set; }
        public double Carbon { get; set; }
        public double CalorificOfMeal { get; set; }
        public int TypeOfMealId { get; set; }
    }
}
