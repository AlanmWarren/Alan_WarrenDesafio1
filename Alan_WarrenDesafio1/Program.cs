using Application;
using Domain.Services;
using FluentValidation.AspNetCore;
using Infrastructure.Data.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Linq;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var assemblie = Assembly.Load("Application");
builder.Services.AddControllers()
    .AddFluentValidation(options =>
    {
        options.RegisterValidatorsFromAssembly(assemblie);
    });

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseMySql(builder.Configuration.GetConnectionString("Default"),
                    ServerVersion.Parse("8.0.29-mysql"),
                    config => config.MigrationsAssembly("Infrastructure.Data"));
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<ICustomerService, CustomerService>();
builder.Services.AddTransient<ICustomerAppService, CustomerAppService>();
builder.Services.AddAutoMapper((_, mapperConfiguration) => mapperConfiguration.AddMaps(assemblie), assemblie);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var supportedCultures = "en-US";
var localizationOptions = new RequestLocalizationOptions().SetDefaultCulture(supportedCultures)
    .AddSupportedCultures(supportedCultures)
    .AddSupportedUICultures(supportedCultures);

app.UseRequestLocalization(localizationOptions);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();