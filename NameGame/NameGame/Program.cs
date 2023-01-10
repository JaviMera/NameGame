using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using NameGame.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Fluent Validation middleware
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);

// Database middleware
builder.Services.AddDbContext<NameGameContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Local"));
});

builder.Services.AddAutoMapper(typeof(Program).Assembly);

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

using (var scope = app.Services.CreateScope())
{     
    await SeedData.Initialize(scope.ServiceProvider);
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
