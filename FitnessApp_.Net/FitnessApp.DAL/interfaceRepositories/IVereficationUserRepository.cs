using FitnessApp.DAL.Models;
using FitnessApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.DAL.interfaceRepositories
{
    public interface IVereficationUserRepository
    {

        public Task<VereficationUser> GetUserVereficationByIdAsync(int id);

        public Task<VereficationUser> GetVereficationUserByEmailAsync(string email);
      
    }
}
