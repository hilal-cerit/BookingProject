using BookingProject.Common.DataAccess.EntityFramework;
using BookingProject.Common.Entities;
using BookingProject.DataAccess.Abstract;
using BookingProject.Entities.DTOs;
using BookingProject.Entities.Models;
using Microsoft.EntityFrameworkCore;
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
        public void Add(Booking entity)
        {
            using (booking1661538931410oilduxjtefmbtrtwContext context = new booking1661538931410oilduxjtefmbtrtwContext())
            {

                var latestRow = context.Bookings.AsNoTrackingWithIdentityResolution().OrderByDescending(a => a.Id).FirstOrDefault();
                entity.Id = latestRow.Id + 1;
             
                context.Database.ExecuteSqlRaw("INSERT INTO bookings (id,user_id, starts_At, booked_at, booked_for,apartment_id,confirmed)" +
                    " VALUES ({0}, {1}, {2}, {3},{4},{5},{6});", entity.Id, entity.UserId, entity.StartsAt, entity.BookedAt, entity.BookedFor,entity.ApartmentId,entity.Confirmed);

                context.SaveChanges();

            }
        }
        public void Delete(Booking entity)
        {
            using (booking1661538931410oilduxjtefmbtrtwContext context = new booking1661538931410oilduxjtefmbtrtwContext())
            {
                int isConfirmed = context.Database.ExecuteSqlRaw("SELECT confirmed FROM bookings  WHERE bookings.Id={0} ;", entity.Id);
                if (isConfirmed == 0)
                {

                    context.Database.ExecuteSqlRaw("DELETE FROM bookings WHERE Id={0};", entity.Id);
                    context.SaveChanges();

                }
                else
                {
                    throw new Exception("Can't delete this data because it is not confirmed");
                }
            }



        }
        public void Update(Booking entity)
        {
            using (booking1661538931410oilduxjtefmbtrtwContext context = new booking1661538931410oilduxjtefmbtrtwContext())
            {
                context.Database.ExecuteSqlRaw("UPDATE bookings SET user_id={1}, starts_At={2}, booked_at={3}, booked_for={4}, apartment_id={5} confirmed={6} WHERE id = {0}",
                    entity.Id, entity.UserId, entity.StartsAt, entity.BookedAt, entity.BookedFor, entity.ApartmentId, entity.Confirmed);

             
                context.SaveChanges();
            }
        }
     



    }

}

