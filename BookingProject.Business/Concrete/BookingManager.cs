using BookingProject.Business.Abstract;
using BookingProject.Common.Entities;
using BookingProject.DataAccess.Abstract;
using BookingProject.DataAccess.Concrete.EntityFramework;
using BookingProject.Entities.DTOs;
using BookingProject.Entities.Models;
using ChatApp.Common.Result;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingProject.Business.Concrete
{
    public class BookingManager : IBookingService
    {
        IBookingDal _bookingDal;
        public BookingManager(IBookingDal bookingDal)
        {
            _bookingDal= bookingDal;    
        }
        


        public  async Task<Booking> Add(Booking booking)
        {
            
            return await _bookingDal.Add(booking);
        }

        public async Task Delete(int bookingId)
        {

            if (await _bookingDal.Get(p => p.Id == bookingId) != null)
            {
                await _bookingDal.Delete(await _bookingDal.Get(p => p.Id == bookingId));
            }
            else
            {
                throw new Exception("There isn't any data with this Id!");
            }
           
        }

        public async Task<IEnumerable<Booking>> GetAll()
        {
            return await _bookingDal.GetAll();
        }

        public async Task<Booking> GetById(int bookingId)
        {
            return await _bookingDal.Get(p => p.Id == bookingId);
        }

        public List<BookingDetailsDTO> SearchForBooking(string? userName=null, string? userSurname = null, string? startDate = null, string? finishDate = null, string? appartmentName = null, int? confirmed = null)
        {
            return _bookingDal.GetBookingDetailsDtos(x =>
                                              (string.IsNullOrEmpty(userName) || x.FirstName == userName) &&
                                              (string.IsNullOrEmpty(userSurname) || x.LastName == userSurname) &&
                                              (string.IsNullOrEmpty(startDate) || x.StartsAt == startDate) &&
                                              (string.IsNullOrEmpty(finishDate) || x.FinishesAt == finishDate) &&
                                              (string.IsNullOrEmpty(appartmentName) || x.AppartmentName == appartmentName) &&
                                              (!confirmed.HasValue || x.Confirmed == confirmed) 
                                             );
        }
       
      

        public async Task<Booking> Update(Booking booking)
        {
            if (await _bookingDal.Get(p => p.Id == booking.Id) !=null)
            { 
                return await _bookingDal.Update(booking);
            }
            else
            {
                throw new Exception("There isn't any data with this Id!");
            }
        }
    }
}
