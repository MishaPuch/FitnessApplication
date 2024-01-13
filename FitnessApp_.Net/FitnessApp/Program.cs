using FitnessApp.BLL.DI_Service;
using FitnessApp.BLL.Interface;
using FitnessApp.BLL.Services;
using FitnessApp.BLL.Services.FileServices;
using FitnessApp.DAL;
using FitnessApp.DAL.DiRepositories;
using FitnessApp.DAL.interfaceRepositories;
using FitnessApp.DAL.InterfaceRepositories;
using FitnessApp.Models;
using Microsoft.EntityFrameworkCore;
using NLog.Config;
using NLog.Targets;
using NLog;
using FitnessApp.BLL.Interface.FileServiceInterface;
using FitnessApp.DAL.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    var jwtSettings = builder.Configuration.GetSection("JwtSettings");
    x.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidIssuer = jwtSettings["Issuer"],
        ValidAudience = jwtSettings["Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"])),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
    };
});

builder.Services.AddAuthorization();


var AppConfig = builder.Configuration;

IConfigurationSection configuration = AppConfig.GetSection("ConnectionStrings");
string connectionString = configuration.GetSection("Data").Value;

builder.Services.AddDbContext<FitnessAppContext>(options => options.UseSqlServer(connectionString), ServiceLifetime.Scoped);
builder.Services.AddSingleton<IMealFileService, MealFileService>();
builder.Services.AddSingleton<IUserFileService, UserFileService>();
builder.Services.AddSingleton<ITreningFileService,TreningFileService>();
builder.Services.AddSingleton<QueueHelper>();

builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<ITrainingAndDietScheduleRepository, TrainingAndDietScheduleRepository>();
builder.Services.AddTransient<ITypeOfMuscleGroupRepository, TypeOfMuscleGroupRepository>();
builder.Services.AddTransient<ITreningRepository, TreningRepository>();
builder.Services.AddTransient<IExerciseRepository, ExerciseRepository>();
builder.Services.AddTransient<IDietRepository, DietRepository>();
builder.Services.AddTransient<IMealRepository, MealRepository>();
builder.Services.AddTransient<ITypeOfMealRepository, TypeOfMealRepository>();
builder.Services.AddTransient<ICalorificCoefficientRepository, CalorificCoefficientRepository>();
builder.Services.AddTransient<ITreningPlanRepository,TreningPlanRepository>();
builder.Services.AddTransient<IRoleRepository, RoleRepository>();
builder.Services.AddTransient<ITypeOfTreningRepository, TypeOfTreningRepository>();
builder.Services.AddTransient<IVereficationUserRepository, VereficationUserRepository>();
builder.Services.AddTransient<IChangingTreningPlanRepository, ChangingTreningPlanRepository>(); 

builder.Services.AddTransient<IUserService, UserService>();   
builder.Services.AddTransient<ITrainingAndDietSchedule, TrainingAndDietSchedule>();
builder.Services.AddTransient<IExerciseService, ExerciseService>();
builder.Services.AddTransient<ITreningService, TreningService>();
builder.Services.AddTransient<ITypeOfMuscleGroupService, TypeOfMuscleGroupService>();
builder.Services.AddTransient<IDietService, DietService>();
builder.Services.AddTransient<IMealService, MealService>();
builder.Services.AddTransient<ITreningPlanService, TreningPlanService>();
builder.Services.AddTransient<ITypeOfMealService, TypeOfMealService>();
builder.Services.AddTransient<IRoleService, RoleService>();
builder.Services.AddTransient<ITypeOfTreningService, TypeOfTreningService>();
builder.Services.AddTransient<IVereficationUserService, VereficationUserService>();
builder.Services.AddTransient<IChangingTreningPlanService, ChangingTreningPlanService>();

#region NLog Initializator

var LogConfig = new NLog.Config.LoggingConfiguration();
LogManager.Configuration = new LoggingConfiguration();
var consoleTarget = new ColoredConsoleTarget("Console Target")
{
    Layout = @"${longdate}|${level:uppercase=true}|${logger}|${message}"
};
// Rules for mapping loggers to targets
LogConfig.AddRule(NLog.LogLevel.Trace, NLog.LogLevel.Fatal, consoleTarget);
// Apply config
NLog.LogManager.Configuration = LogConfig;

#endregion NLog Initializator


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

app.UseAuthentication();

app.UseAuthorization();
    
app.MapControllers();

app.Run();
