using FitnessApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.DAL
{
    public class FitnessAppContext:DbContext
    {
        public FitnessAppContext(DbContextOptions<FitnessAppContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Calendar> Calendars { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Diet> Diet { get; set; }

    }
}
