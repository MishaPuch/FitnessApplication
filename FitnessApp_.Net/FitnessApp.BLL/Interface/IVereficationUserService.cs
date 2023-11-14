using FitnessApp.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.BLL.Interface
{
    public interface IVereficationUserService
    {
        public Task CheckThePassword(string email, int verificationCode);
        public Task<VereficationUser> GetUserVereficationByIdAsync(int id);
        public Task<VereficationUser> GetVereficationUserByEmailAsync(string email);

    }
}
