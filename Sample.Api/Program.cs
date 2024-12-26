using Microsoft.EntityFrameworkCore;
using Sample.Datahub;
using Sample.Datahub.Models.Domain;
using Sample.Datahub.Repository;
using Sample.Services.BusinessLogic;
using Sample.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<SampleDbContext>(options => 
options.UseSqlServer(builder.Configuration.GetConnectionString("SampleConnectionString")));
builder.Services.AddTransient<IEmployeeData, EmployeeData>();
builder.Services.AddTransient<IBranchData, BranchData>();
builder.Services.AddTransient<ITeamData, TeamData>();
builder.Services.AddTransient<IEmployeeServices, EmployeeServices>();
builder.Services.AddTransient<ITeamServices,TeamServices>();
builder.Services.AddTransient<IBranchServices, BranchServices>();

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
