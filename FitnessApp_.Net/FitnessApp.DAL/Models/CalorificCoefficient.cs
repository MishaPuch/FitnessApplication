using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.DAL.Models
{
    public class CalorificCoefficientValue
    {
        public int Id { get; set; }
        public double CalorificValue { get; set; }
        public double CalorificCoefficient { get; set; }
        public int TypeOfMeal { get; set; }
    }
}
