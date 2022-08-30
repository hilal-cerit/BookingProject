using BookingProject.Business.Abstract;
using BookingProject.Business.Concrete;
using BookingProject.Common.DataAccess;
using BookingProject.DataAccess.Abstract;
using BookingProject.DataAccess.Concrete.EntityFramework;
using BookingProject.Entities.DTOs;
using BookingProject.Entities.Models;
using System.Net.Mail;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Dependency resolvers
builder.Services.AddScoped<BookingDetailsDTO>();

builder.Services.AddScoped<booking1661538931410oilduxjtefmbtrtwContext>();
builder.Services.AddSingleton<IUserDal,EfUserDal>();
builder.Services.AddScoped<IUserService,UserManager>();


builder.Services.AddScoped<booking1661538931410oilduxjtefmbtrtwContext>();
builder.Services.AddSingleton<IBookingDal, EfBookingDal>();
builder.Services.AddScoped<IBookingService, BookingManager>();

builder.Services.AddScoped<booking1661538931410oilduxjtefmbtrtwContext>();
builder.Services.AddSingleton<ICompanyDal, EfCompanyDal>();
builder.Services.AddScoped< ICompanyService,CompanyManager >();


builder.Services.AddScoped<booking1661538931410oilduxjtefmbtrtwContext>();
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
