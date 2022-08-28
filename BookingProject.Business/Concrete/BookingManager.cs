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



        public IResult Add(Booking booking)
        {
            _bookingDal.Add(booking);
            return new SuccessResult();
        }

        public IResult Delete(int bookingId)
        {
          
            _bookingDal.Delete(_bookingDal.Get(p => p.Id == bookingId));
            return new SuccessResult();
        }

        public IDataResult<List<Booking>> GetAll()
        {
            return new SuccessDataResult<List<Booking>>(_bookingDal.GetAll());
        }

        public IDataResult<Booking> GetById(int bookingId)
        {
            return new SuccessDataResult<Booking>(_bookingDal.Get(p => p.Id == bookingId));
        }

        public IDataResult<List<BookingDetailsDTO>> SearchForBooking(string? userName=null, string? userSurname = null, string? startDate = null, string? finishDate = null, string? appartmentName = null, int? confirmed = null)
        {
            return new SuccessDataResult<List<BookingDetailsDTO>>(
                _bookingDal.GetBookingDetailsDtos(x =>
                                              (string.IsNullOrEmpty(userName) || x.FirstName == userName) &&
                                              (string.IsNullOrEmpty(userSurname) || x.LastName == userSurname) &&
                                              (string.IsNullOrEmpty(startDate) || x.StartsAt == startDate) &&
                                              (string.IsNullOrEmpty(finishDate) || x.StartsAt == startDate) &&
                                              (string.IsNullOrEmpty(appartmentName) || x.StartsAt == startDate) &&
                                              (!confirmed.HasValue || x.Confirmed == confirmed) 
                                             ));
        }

        public IResult Update(Booking booking)
        {
            _bookingDal.Update(booking);
            return new SuccessResult();
        }
    }
}
