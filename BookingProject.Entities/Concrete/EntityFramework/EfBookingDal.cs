using BookingProject.Common.DataAccess.EntityFramework;
using BookingProject.Common.Entities;
using BookingProject.DataAccess.Abstract;
using BookingProject.Entities.DTOs;
using BookingProject.Entities.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Linq.Expressions;
using System.Numerics;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace BookingProject.DataAccess.Concrete.EntityFramework
{
    public class EfBookingDal : EfEntityRepositoryBase<Booking, booking1661538931410oilduxjtefmbtrtwContext>, IBookingDal
    {

        public List<BookingDetailsDTO> GetBookingDetailsDtos(Expression<Func<BookingDetailsDTO, bool>> filter=null)
        {
            using (booking1661538931410oilduxjtefmbtrtwContext context = new booking1661538931410oilduxjtefmbtrtwContext())
            {
                var result = from bookings in context.Bookings
                             join appartments in context.Appartments
                             on bookings.ApartmentId equals appartments.Id
                             join users in context.Users
                             on bookings.UserId equals users.Id

                             select new BookingDetailsDTO
                             {
                                 FirstName = users.FirstName,
                                 LastName = users.LastName,
                                 Phone = users.Phone,
                                 Email = users.Email,

                                 AppartmentName = appartments.Name,
                                 Country = appartments.Country,
                                 City = appartments.City,
                                 ZipCode = appartments.ZipCode,
                                 AppartmentAddress = appartments.Address,

                                 StartsAt = bookings.StartsAt,
                                 BookedFor=bookings.BookedFor,
                                 Confirmed=bookings.Confirmed
                                 
};           if (filter != null)
                {
                    return result.Where(filter).ToList(); 
                }
                else
                {
                    return result.ToList();
                }
           
            
            
            
            }
            }
        }







        }

