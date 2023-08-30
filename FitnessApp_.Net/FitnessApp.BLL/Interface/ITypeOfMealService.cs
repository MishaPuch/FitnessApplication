using FitnessApp.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.BLL.Interface
{
    public interface ITypeOfMealService
    {
        public Task<TypeOfMeal> GetTypeOfMealByIdAsync(int typeOfMealId);
       
    }
}
