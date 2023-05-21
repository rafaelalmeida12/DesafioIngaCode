using IngaCode.Infrastructure.Context;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.EntityFrameworkCore;
using IngaCode.Application.Interfaces;
using IngaCode.Application.Services;
using IngaCode.Infrastructure.Repository;
using IngaCode.Infrastructure.UnitOfWork;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>(); //Used by ActiveRouteTagHelper    
builder.Services.AddDbContext<IngaCodeContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("IngaCodeConnection")));

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();


builder.Services.AddScoped<IProjectsService, ProjectsService>();
builder.Services.AddScoped<ITasksService, TasksService>();
builder.Services.AddScoped<ITimeTrackersService, TimeTrackersService>();
builder.Services.AddScoped<IUsersService, UsersService>();
builder.Services.AddScoped<ICollaboratorsService, CollaboratorsService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
