﻿// <auto-generated />
using System;
using FitnessApp.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FitnessApp.DAL.Migrations
{
    [DbContext(typeof(FitnessAppContext))]
    partial class FitnessAppContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FitnessApp.DAL.Models.CalorificCoefficientValue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("CalorificCoefficient")
                        .HasColumnType("float");

                    b.Property<double>("CalorificValue")
                        .HasColumnType("float");

                    b.Property<int>("TypeOfMealId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TypeOfMealId");

                    b.ToTable("CalorificCoefficientValues");
                });

            modelBuilder.Entity("FitnessApp.DAL.Models.ChangingTreningPlan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ActualUserTreningPlan")
                        .HasColumnType("int");

                    b.Property<int>("DisiredTreningPlan")
                        .HasColumnType("int");

                    b.Property<bool?>("IsApproved")
                        .HasColumnType("bit");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("ChangingTreningPlans");
                });

            modelBuilder.Entity("FitnessApp.DAL.Models.Meal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("CalorificOfMeal")
                        .HasColumnType("float");

                    b.Property<double>("Carbon")
                        .HasColumnType("float");

                    b.Property<double>("Fat")
                        .HasColumnType("float");

                    b.Property<string>("FoodIngredients")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FoodInstructions")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FoodName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Foto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Protein")
                        .HasColumnType("float");

                    b.Property<int>("Statistic")
                        .HasColumnType("int");

                    b.Property<int>("TypeOfMealId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TypeOfMealId");

                    b.ToTable("Meals");
                });

            modelBuilder.Entity("FitnessApp.DAL.Models.Role", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("FitnessApp.DAL.Models.Trening", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ExerciseId")
                        .HasColumnType("int");

                    b.Property<string>("Times")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TrainingAndDietSchedulesId")
                        .HasColumnType("int");

                    b.Property<int>("TreningPlanId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ExerciseId");

                    b.HasIndex("TrainingAndDietSchedulesId");

                    b.ToTable("Trenings");
                });

            modelBuilder.Entity("FitnessApp.DAL.Models.TreningPlan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("TreningPlanValue")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TreningPlans");
                });

            modelBuilder.Entity("FitnessApp.DAL.Models.TypeOfMeal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("NameFoodType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TypesOfMeal");
                });

            modelBuilder.Entity("FitnessApp.DAL.Models.TypeOfMuscleGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("FullBodyWorkoutProtogonistMuscleGroups")
                        .HasColumnType("int");

                    b.Property<string>("NameMuscleGroup")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TypeOfMuscleGroups");
                });

            modelBuilder.Entity("FitnessApp.DAL.Models.TypeOfTrening", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("TypeOfTreningValue")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TypesOfTrening");
                });

            modelBuilder.Entity("FitnessApp.DAL.Models.VereficationUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VereficationCode")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("VereficationUsers");
                });

            modelBuilder.Entity("FitnessApp.Models.Diet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("MealId")
                        .HasColumnType("int");

                    b.Property<int>("TrainingAndDietScheduleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MealId");

                    b.HasIndex("TrainingAndDietScheduleId");

                    b.ToTable("Diet");
                });

            modelBuilder.Entity("FitnessApp.Models.Exercise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ExerciseDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ExerciseName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ExerciseVideo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MuscleGroupId")
                        .HasColumnType("int");

                    b.Property<int>("Statistic")
                        .HasColumnType("int");

                    b.Property<int>("TypeOfTreningId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MuscleGroupId");

                    b.HasIndex("TypeOfTreningId");

                    b.ToTable("Exercises");
                });

            modelBuilder.Entity("FitnessApp.Models.TreningAndDietSchedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Day")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("TrainingAndDietSchedule");
                });

            modelBuilder.Entity("FitnessApp.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Avatar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CalorificValue")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOFLastPayment")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsEmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("RestTime")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("Sex")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TreningPlanId")
                        .HasColumnType("int");

                    b.Property<string>("UserEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("TreningPlanId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("FitnessApp.DAL.Models.CalorificCoefficientValue", b =>
                {
                    b.HasOne("FitnessApp.DAL.Models.TypeOfMeal", "TypeOfMeal")
                        .WithMany()
                        .HasForeignKey("TypeOfMealId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TypeOfMeal");
                });

            modelBuilder.Entity("FitnessApp.DAL.Models.ChangingTreningPlan", b =>
                {
                    b.HasOne("FitnessApp.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("FitnessApp.DAL.Models.Meal", b =>
                {
                    b.HasOne("FitnessApp.DAL.Models.TypeOfMeal", "TypeOfMeal")
                        .WithMany()
                        .HasForeignKey("TypeOfMealId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TypeOfMeal");
                });

            modelBuilder.Entity("FitnessApp.DAL.Models.Trening", b =>
                {
                    b.HasOne("FitnessApp.Models.Exercise", "Exercise")
                        .WithMany()
                        .HasForeignKey("ExerciseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FitnessApp.Models.TreningAndDietSchedule", "TrainingAndDietSchedules")
                        .WithMany("Trainings")
                        .HasForeignKey("TrainingAndDietSchedulesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exercise");

                    b.Navigation("TrainingAndDietSchedules");
                });

            modelBuilder.Entity("FitnessApp.Models.Diet", b =>
                {
                    b.HasOne("FitnessApp.DAL.Models.Meal", "Meal")
                        .WithMany()
                        .HasForeignKey("MealId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FitnessApp.Models.TreningAndDietSchedule", "TrainingAndDietSchedule")
                        .WithMany("Diets")
                        .HasForeignKey("TrainingAndDietScheduleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Meal");

                    b.Navigation("TrainingAndDietSchedule");
                });

            modelBuilder.Entity("FitnessApp.Models.Exercise", b =>
                {
                    b.HasOne("FitnessApp.DAL.Models.TypeOfMuscleGroup", "MuscleGroup")
                        .WithMany()
                        .HasForeignKey("MuscleGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FitnessApp.DAL.Models.TypeOfTrening", "TypeOfTrening")
                        .WithMany()
                        .HasForeignKey("TypeOfTreningId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MuscleGroup");

                    b.Navigation("TypeOfTrening");
                });

            modelBuilder.Entity("FitnessApp.Models.TreningAndDietSchedule", b =>
                {
                    b.HasOne("FitnessApp.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("FitnessApp.Models.User", b =>
                {
                    b.HasOne("FitnessApp.DAL.Models.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FitnessApp.DAL.Models.TreningPlan", "TreningPlan")
                        .WithMany()
                        .HasForeignKey("TreningPlanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("TreningPlan");
                });

            modelBuilder.Entity("FitnessApp.Models.TreningAndDietSchedule", b =>
                {
                    b.Navigation("Diets");

                    b.Navigation("Trainings");
                });
#pragma warning restore 612, 618
        }
    }
}
