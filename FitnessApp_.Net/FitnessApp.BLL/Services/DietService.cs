﻿using FitnessApp.BLL.Interface;
using FitnessApp.DAL.DiRepositories;
using FitnessApp.DAL.interfaceRepositories;
using FitnessApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.BLL.Services
{
    public class DietService : IDietService
    {
        private readonly IDietRepository _dietRepository;
        public DietService(IDietRepository dietRepository)
        {
            _dietRepository = dietRepository;
        }

        public async Task<Diet> GetDietByIdAsync(int dietId)
        {
            return await _dietRepository.GetDietByIdAsync(dietId);
        }

        public async Task<List<Diet>> GetDietByTreningScheduleIdAsync(int treningScheduleId)
        {
            return await _dietRepository.GetDietByTreningScheduleIdAsync(treningScheduleId);
        }
    }
}
