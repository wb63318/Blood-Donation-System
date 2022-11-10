using Blood_Donation_System.Data;
using Blood_Donation_System.Models.Entities.BloodBank;
using Blood_Donation_System.Repos.BloodBank.Interfaces;
using Blood_Donation_System.Repos.BloodBank.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(x =>
{
    x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddDbContext<DonationSystemDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DonationSystem"));
});
builder.Services.AddScoped<BloodRequestInterface,BloodRequestRp>();
builder.Services.AddScoped<DonationInterface,DonationRp>();
builder.Services.AddScoped<DonorInterface,DonorRp>();
builder.Services.AddScoped<SupplyInterface,SupplyRp>();

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
