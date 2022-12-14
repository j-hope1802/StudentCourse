using Domain.Entities;
using Infrastructure.Context;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddControllers();
var connection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<DataContext>(op => op.UseNpgsql(connection));
builder.Services.AddAutoMapper(typeof(ServiceProfile), typeof(ServiceProfile) );
builder.Services.AddScoped<StudentService>();
builder.Services.AddScoped<CourseService>();
builder.Services.AddScoped<Enrollmentservice>();




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
