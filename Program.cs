using Microsoft.EntityFrameworkCore;
using StackUnderdose.Entities;
using StackUnderdose.Seeders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<StackUnderdoseContext>(
        option => option.UseSqlServer(builder.Configuration.GetConnectionString("StackUnderdoseConnectionString"))
    );

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using var scope = app.Services.CreateScope();
var dbContext = scope.ServiceProvider.GetService<StackUnderdoseContext>();

Seeder.Seed(dbContext);


app.Run();

