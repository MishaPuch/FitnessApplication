﻿using FitnessApp.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.DAL.interfaceRepositories
{
    public interface ITypeOfMealRepository
    {
        public Task<TypeOfMeal> GetTypeOfMealByIdAsync(int TypeOfMealId);

    }
}
