using FitnessApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace FitnessApp.DAL.Models
{
    public class Meal
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
        public virtual TypeOfMeal TypeOfMeal { get; set; }
    }
}
