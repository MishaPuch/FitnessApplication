using FitnessApp.DAL.interfaceRepositories;
using FitnessApp.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.BLL.Interface
{
    public class TreningService : ITreningService
    {
        private readonly ITreningRepository _treningRepository;
        public TreningService(ITreningRepository treningRepository)
        {
            _treningRepository = treningRepository;
        }

        public async Task<Trening> GetTreningByIdAsync(int treningId)
        {
            return await _treningRepository.GetTreningByIdAsync(treningId);
        }

    }
}
