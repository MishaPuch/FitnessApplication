using System;
using System.Collections.Generic;
using EmailVereficationMicroservice.Model;
using Microsoft.EntityFrameworkCore;

namespace EmailVereficationMicroservice;

public partial class FitnessAppContext : DbContext
{
    public FitnessAppContext()
    {
    }

    public FitnessAppContext(DbContextOptions<FitnessAppContext> options)
        : base(options)
    {
    }

   

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<VereficationUser> VereficationUsers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=MIHSA;Database=FitnessApp;Trusted_Connection=True;Encrypt=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasIndex(e => e.RoleId, "IX_Users_RoleId");

            entity.HasIndex(e => e.TreningPlanId, "IX_Users_TreningPlanId");

            entity.Property(e => e.DateOflastPayment).HasColumnName("DateOFLastPayment");
            entity.Property(e => e.IsEmailConfirmed)
                .IsRequired()
                .HasDefaultValueSql("(CONVERT([bit],(0)))");
            entity.Property(e => e.Password).HasMaxLength(100);
            entity.Property(e => e.UserName).HasMaxLength(100);

        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
