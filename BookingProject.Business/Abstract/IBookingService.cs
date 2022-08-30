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
        Task<Booking> GetById(int bookingId);
        Task<IEnumerable<Booking>> GetAll();
        Task<Booking> Add(Booking booking);
        Task Delete(int bookingId);
        Task<Booking> Update(Booking booking);
        Task<IEnumerable<BookingDetailsDTO>> SearchForBooking(string? firstName = null, string? lastName = null, string? startDate = null, string? finishDate = null, string? appartmentName = null, int? confirmed = null);


    }
}