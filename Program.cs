using Microsoft.EntityFrameworkCore;
using Employee_DomainLayer.Data;
using Employee_DomainLayer.Models;
using Employee_RepositoryLayer.IRepository;
using Employee_RepositoryLayer.Repository;
using Employee_ServiceLayer.ICustomServices;
using Employee_ServiceLayer.CustomServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<Employee_DomainLayer.Data.SQLiteDBContext>
    (options => options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

#region Injected Services
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<ICustomService<Employee>, EmployeeService>();
#endregion

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
