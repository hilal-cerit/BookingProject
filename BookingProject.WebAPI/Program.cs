using BookingProject.Business.Abstract;
using BookingProject.Business.Concrete;
using BookingProject.Common.DataAccess;
using BookingProject.Common.DataAccess.EntityFramework;
using BookingProject.Common.Entities;
using BookingProject.DataAccess.Abstract;
using BookingProject.DataAccess.Concrete.EntityFramework;
using BookingProject.Entities.DTOs;
using BookingProject.Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using System.Configuration;
using System.Data.SqlClient;
using System.Net.Mail;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

string npsqlConnectionString = builder.Configuration.GetConnectionString("BookingProjectConnection");

builder.Services.AddDbContextPool<booking1661538931410oilduxjtefmbtrtwContext>(options =>
options.UseNpgsql(npsqlConnectionString));






// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Dependency resolvers
builder.Services.AddScoped<BookingDetailsDTO>();

builder.Services.AddScoped<DbContext,booking1661538931410oilduxjtefmbtrtwContext>();

builder.Services.AddSingleton<IUserDal,EfUserDal>();
builder.Services.AddScoped<IUserService,UserManager>();


builder.Services.AddSingleton<IBookingDal, EfBookingDal>();
builder.Services.AddScoped<IBookingService, BookingManager>();

builder.Services.AddSingleton<ICompanyDal, EfCompanyDal>();
builder.Services.AddScoped< ICompanyService,CompanyManager >();


builder.Services.AddSingleton<IAppartmentDal, EfAppartmentDal>();
builder.Services.AddScoped<IAppartmentService, AppartmentManager>();




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
