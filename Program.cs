using System.Reflection;
using CQRSWithMediatR.Data;
using CQRSWithMediatR.Validators;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Register MediatR services manually
builder.Services.AddMediatR(service => service.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

// Configure DbContext to use InMemoryDatabase
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseInMemoryDatabase("ProductDb"));

// Register FluentValidation and validators
builder.Services.AddControllers()
    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreateProductCommandValidator>());

var app = builder.Build();

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
