    using FitnessApp.BLL.DI_Service;
using FitnessApp.BLL.Interface;
using FitnessApp.BLL.Services;
    using FitnessApp.DAL;
using FitnessApp.DAL.DiRepositories;
using FitnessApp.DAL.interfaceRepositories;
using FitnessApp.DAL.InterfaceRepositories;
    using FitnessApp.DAL.repositories;
using FitnessApp.Models;
using Microsoft.EntityFrameworkCore;

    var builder = WebApplication.CreateBuilder(args);



    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();


    var AppConfig = builder.Configuration;


    IConfigurationSection configuration = AppConfig.GetSection("ConnectionStrings");
    string connectionString = configuration.GetSection("Data").Value;

    builder.Services.AddDbContext<FitnessAppContext>(options => options.UseSqlServer(connectionString));

    builder.Services.AddTransient<IUserRepository, UserRepository>();
    builder.Services.AddTransient<FitnessApp.DAL.interfaceRepositories.ITrainingAndDietSchedule, FitnessApp.DAL.DiRepositories.TrainingAndDietSchedule>();
    builder.Services.AddTransient<ITypeOfMuscleGroupRepository, TypeOfMuscleGroupRepository>();
    builder.Services.AddTransient<ITreningRepository, TreningRepository>();
    builder.Services.AddTransient<IExerciseRepository, ExerciseRepository>();
    builder.Services.AddTransient<IDietRepository, DietRepository>();
    builder.Services.AddTransient<IMealRepository, MealRepository>();
    builder.Services.AddTransient<ITypeOfMealRepository, TypeOfMealRepository>();
    builder.Services.AddTransient<ICalorificCoefficientRepository, CalorificCoefficientRepository>();

    builder.Services.AddTransient<IUserService, UserService>();   
    builder.Services.AddTransient<FitnessApp.BLL.Interface.ITrainingAndDietSchedule, FitnessApp.BLL.Services.TrainingAndDietSchedule>();
    builder.Services.AddTransient<IExerciseService, ExerciseService>();
    builder.Services.AddTransient<ITreningService, TreningService>();
    builder.Services.AddTransient<ITypeOfMuscleGroupService, TypeOfMuscleGroupService>();
    builder.Services.AddTransient<IDietService, DietService>();
    builder.Services.AddTransient<IMealService, MealService>();
    builder.Services.AddTransient<ITypeOfMealService, TypeOfMealService>();
  //  builder.Services.AddTransient<ICalorificCoefficientValueService, CalorificCoefficientValueService>();




////////////////////////////////////
builder.Services.AddCors(options =>
    {
        options.AddDefaultPolicy(builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
    });
////////////////////////////////////

var app = builder.Build();
    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    using (var scope = app.Services.CreateScope())
    {
        var dbContext = scope.ServiceProvider
            .GetRequiredService<FitnessAppContext>();

        dbContext.Database.Migrate();
    }
    ///////
    app.UseCors();
    //////
    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
