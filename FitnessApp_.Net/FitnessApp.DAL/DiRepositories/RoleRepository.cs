using FitnessApp.DAL.interfaceRepositories;
using FitnessApp.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.DAL.DiRepositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly FitnessAppContext _context;    
        public RoleRepository(FitnessAppContext context)
        {
            _context = context;
        }

        public async Task<Role> GetByIdAsync(int id)
        {
            return await _context.Roles.FindAsync(id);
        }

    
    }
}
