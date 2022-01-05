using BowlingGame;
using BowlingGame.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Pomelo.EntityFrameworkCore.MySql;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



//Add MySql connection
var serverVersion = new MySqlServerVersion(new Version("8.0.27"));
//register the db conext in services
builder.Services.AddDbContext<BowlingDbContext>(
    dbContextOptions => 
    dbContextOptions.UseMySql("server=localhost;user=root;password=Password123;database=bowling", serverVersion)
    .LogTo(Console.WriteLine, LogLevel.Information)
    .EnableSensitiveDataLogging()
    .EnableDetailedErrors()
    );

builder.Services.AddMvc(options =>
{
    options.SuppressAsyncSuffixInActionNames = false;
});

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      builder =>
                      {
                          builder.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod();
                      });
});


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

