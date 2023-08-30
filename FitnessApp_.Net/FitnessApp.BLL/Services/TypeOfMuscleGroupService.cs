using FitnessApp.DAL.interfaceRepositories;
using FitnessApp.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.BLL.Interface
{
    public class TypeOfMuscleGroupService : ITypeOfMuscleGroupService
    {
        private readonly ITypeOfMuscleGroupRepository _typeOfMuscleGroupRepository;
        public TypeOfMuscleGroupService(ITypeOfMuscleGroupRepository typeOfMuscleGroupRepository)
        {
            _typeOfMuscleGroupRepository = typeOfMuscleGroupRepository;
        }

        public async Task<TypeOfMuscleGroup> GetTypeOfMuscleGroupByIdAsync(int typeOfMuscleGroupRepositoryId)
        {
            return await _typeOfMuscleGroupRepository.GetTypeOfMuscleGroupByIdAsync(typeOfMuscleGroupRepositoryId);
        }

    }
}
