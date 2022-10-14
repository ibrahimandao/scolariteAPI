using Microsoft.EntityFrameworkCore;
using APIStudent.DAO.Data;
using APIStudent.DAO.Services;
using APIStudent.DAO.Interfaces;
using log4net.Config;

var builder = WebApplication.CreateBuilder(args);

XmlConfigurator.Configure(new FileInfo("log4net.config"));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ScolariteDBContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"), b => b.MigrationsAssembly("APIStudent.DAO")));
builder.Services.AddTransient<IStudentService, StudentService>();
builder.Services.AddTransient<IFormationService, FormationService>();

builder.Services.AddCors(p => p.AddPolicy("corspolicy", build =>
{
    build.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseCors("corspolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();

