using FitnessApp.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.BLL.Interface
{
    public interface ITypeOfMuscleGroupService
    {
        public Task<TypeOfMuscleGroup> GetTypeOfMuscleGroupByIdAsync(int typeOfMuscleGroupRepositoryId);

    }
}
