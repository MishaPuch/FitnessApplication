using FitnessApp.DAL.DiRepositories;
using FitnessApp.DAL.Models;
using FitnessApp.DAL;
using FitnessApp.Models;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitnessApp.DAL.interfaceRepositories;
using FitnessApp.BLL.Interface;
using FitnessApp.DAL.InterfaceRepositories;

namespace FitnessApp.BLL.Services
{
    public class VereficationUserService:IVereficationUserService
    { 
        private readonly IVereficationUserRepository _vereficationUserRepository;
        private readonly IUserRepository _userRepository;
        public VereficationUserService(IVereficationUserRepository vereficationUserRepository, IUserRepository userRepository)
        {
            _vereficationUserRepository = vereficationUserRepository;
            _userRepository = userRepository;
        }
        public async Task CheckThePassword(string email, int verificationCode)
        {
            VereficationUser vereficationUser = await GetVereficationUserByEmailAsync(email);
            if (vereficationUser != null && vereficationUser.VereficationCode == verificationCode)
            {
                User user = await _userRepository.GetUserByEmailAsync(email);
                user.IsEmailConfirmed = true;
                await _userRepository.UpdateUserAsync(user);
            }
        }

        public async Task<VereficationUser> GetUserVereficationByIdAsync(int id)
        {
            return await _vereficationUserRepository.GetUserVereficationByIdAsync(id);
        }
        public async Task<VereficationUser> GetVereficationUserByEmailAsync(string email)
        {
            return await _vereficationUserRepository.GetVereficationUserByEmailAsync(email);
        }
    }
}
