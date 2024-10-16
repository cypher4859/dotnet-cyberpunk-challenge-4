using dotnet_cyberpunk_challenge_4.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// builder.Services.AddDbContext<DataContext>(options =>
// 				options.UseMySql(
// 					builder.Configuration.GetConnectionString("mysql-database"),
// 					ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("mysql-database"))
// 				)
//                 .EnableSensitiveDataLogging() // Optional for debugging
//                 .EnableDetailedErrors()
// );
builder.Services.AddDbContext<DataContext>(
    opt => 
        opt.UseSqlite(builder.Configuration.GetConnectionString("sqlite-database"))
            .EnableSensitiveDataLogging() // Optional, helps in debugging
            .EnableDetailedErrors()
);


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
