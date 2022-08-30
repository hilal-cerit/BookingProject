using BookingProject.Business.Abstract;
using BookingProject.DataAccess.Abstract;
using BookingProject.DataAccess.Concrete.EntityFramework;
using BookingProject.Entities.DTOs;
using BookingProject.Entities.Models;
using ChatApp.Common.Result;
using System;
using System.Collections.Generic;
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
          
            
           await _bookingDal.Delete(await _bookingDal.Get(p => p.Id == bookingId));
        }

        public async Task<IEnumerable<Booking>> GetAll()
        {
            return await _bookingDal.GetAll();
        }

        public async Task<Booking> GetById(int bookingId)
        {
            return await _bookingDal.Get(p => p.Id == bookingId);
        }

        public async Task<IEnumerable<BookingDetailsDTO>> SearchForBooking(string? firstName = null, string? lastName = null, string? startDate = null, string? finishDate = null, string? appartmentName = null, int? confirmed = null)
        {
            return await
                _bookingDal.GetBookingDetailsDtos(firstName: firstName, lastName: lastName, startDate: startDate, finishDate: finishDate, appartmentName: appartmentName, confirmed: confirmed);
                                             /*    x =>
                                                                   (string.IsNullOrEmpty(userName) || x.FirstName == userName) &&
                                                                       (string.IsNullOrEmpty(userSurname) || x.LastName == userSurname) &&
                                                                       (string.IsNullOrEmpty(startDate) || x.StartsAt == startDate) &&
                                                                       (string.IsNullOrEmpty(finishDate) || x.FinishesAt == finishDate) &&
                                                                       (string.IsNullOrEmpty(appartmentName) || x.AppartmentName == appartmentName) &&
                                                                       (!confirmed.HasValue || x.Confirmed == confirmed) 
                                             );*/
        }

        public async Task<Booking> Update(Booking booking)
        {
           
            return await _bookingDal.Update(booking);
        }
    }
}
