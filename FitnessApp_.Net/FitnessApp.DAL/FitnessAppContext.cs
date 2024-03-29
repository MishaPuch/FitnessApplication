﻿using FitnessApp.DAL.Models;
using FitnessApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.DAL
{
    public class FitnessAppContext : DbContext
    {
        public FitnessAppContext(DbContextOptions<FitnessAppContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<TreningAndDietSchedule> TrainingAndDietSchedule { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Diet> Diet { get; set; }
        public DbSet<CalorificCoefficientValue> CalorificCoefficientValues { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<Trening> Trenings { get; set; }
        public DbSet<TypeOfMeal> TypesOfMeal { get; set; }
        public DbSet<TypeOfMuscleGroup> TypeOfMuscleGroups { get; set; }
        public DbSet<TypeOfTrening> TypesOfTrening { get; set; }
        public DbSet<TreningPlan> TreningPlans { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<VereficationUser> VereficationUsers { get; set; }
        public DbSet<ChangingTreningPlan> ChangingTreningPlans { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Diet>().HasKey(d => d.Id);
        }
        
    }
}
