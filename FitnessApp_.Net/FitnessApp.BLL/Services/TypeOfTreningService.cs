using FitnessApp.BLL.Interface;
using FitnessApp.DAL.interfaceRepositories;
using FitnessApp.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.BLL.Services
{
    public class TypeOfTreningService : ITypeOfTreningService
    {
        private readonly ITypeOfTreningRepository _typeOfTreningRepository;
        public TypeOfTreningService(ITypeOfTreningRepository typeOfTreningRepository)
        {
            _typeOfTreningRepository = typeOfTreningRepository;
        }

        public async Task<TypeOfTrening> GetTypeOfTreningByIdAsync(int id)
        {
            return await _typeOfTreningRepository.GetTypeOfTreningByIdAsync(id);
        }
    }
}
