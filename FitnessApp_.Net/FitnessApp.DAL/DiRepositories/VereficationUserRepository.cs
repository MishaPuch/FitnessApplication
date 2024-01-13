using FitnessApp.DAL.interfaceRepositories;
using FitnessApp.DAL;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitnessApp.DAL.Models;
using Microsoft.EntityFrameworkCore;
using FitnessApp.DAL.DiRepositories;
using FitnessApp.Models;
using FitnessApp.DAL.InterfaceRepositories;

namespace FitnessApp.BLL.Services
{
    public class VereficationUserRepository:IVereficationUserRepository
    {
        private readonly FitnessAppContext _context;
        private readonly Logger Logger = LogManager.GetCurrentClassLogger();
        public VereficationUserRepository(FitnessAppContext context )
        {
            _context = context;
        }        
        public async Task<VereficationUser> GetUserVereficationByIdAsync(int id)
        { 
            return await _context.VereficationUsers.FindAsync(id);
        }
        public async Task<VereficationUser> GetVereficationUserByEmailAsync(string email)
        {
            return await _context.VereficationUsers.OrderBy(u=>u.Id).LastOrDefaultAsync(x => x.Email == email);
        }
       
    }
}
