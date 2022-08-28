using BookingProject.Entities.DTOs;
using BookingProject.Entities.Models;
using ChatApp.Common.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingProject.Business.Abstract
{
    public interface IBookingService
    {
        IDataResult<Booking> GetById(int bookingId);
        IDataResult<List<Booking>> GetAll();
        IResult Add(Booking booking);
        IResult Delete(int bookingId);
        IResult Update(Booking booking);
        IDataResult<List<BookingDetailsDTO>> SearchForBooking(string? userName = null, string? userSurname = null, string? startDate = null, string? finishDate = null, string? appartmentName = null, int? confirmed = null);


    }
}