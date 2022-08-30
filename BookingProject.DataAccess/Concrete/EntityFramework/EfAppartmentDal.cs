using BookingProject.Common.DataAccess.EntityFramework;
using BookingProject.Common.Entities;
using BookingProject.DataAccess.Abstract;
using BookingProject.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingProject.DataAccess.Concrete.EntityFramework
{
    public class EfAppartmentDal:EfEntityRepositoryBase<Appartment, booking1661538931410oilduxjtefmbtrtwContext>, IAppartmentDal
    {

        public async Task<Appartment> Add(Appartment entity)
        {
            using (booking1661538931410oilduxjtefmbtrtwContext context = new booking1661538931410oilduxjtefmbtrtwContext())
            {

                var latestRow = context.Appartments.AsNoTrackingWithIdentityResolution().OrderByDescending(a => a.Id).FirstOrDefault();
                entity.Id = latestRow.Id + 1;
       
                context.Database.ExecuteSqlRaw("INSERT INTO appartments (id,name, image, country, city, zip_code, address,address2,latitude,longitude,direction,booked)" +
                    " VALUES ({0}, {1}, {2}, {3},{4}, {5},{6},{7}, {8}, {9}, {10},{11});", entity.Id,entity.Name,entity.Image, entity.Country, entity.City, entity.ZipCode, entity.Address, entity.Address2, entity.Latitude,entity.Longitude, entity.Direction, entity.Booked);

                await context.SaveChangesAsync();
                return entity;

            }
        }
        public async Task Delete(Appartment entity)
        {
            using (booking1661538931410oilduxjtefmbtrtwContext context = new booking1661538931410oilduxjtefmbtrtwContext())
            {
                int isConfirmed = context.Database.ExecuteSqlRaw("SELECT confirmed FROM bookings join appartments on appartments.Id=bookings.apartment_id WHERE appartments.Id={0} ;", entity.Id);
                if (isConfirmed == 0)
                {
                    context.Database.ExecuteSqlRaw("DELETE FROM appartments WHERE Id={0};", entity.Id);
                    await context.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("Can't delete this data because it is not confirmed");
                }

            }



        }
        public async Task<Appartment> Update(Appartment entity)
        {
            using (booking1661538931410oilduxjtefmbtrtwContext context = new booking1661538931410oilduxjtefmbtrtwContext())
            {
                context.Database.ExecuteSqlRaw("UPDATE appartments SET name={1}, image={2}, country={3}, city={4}, zip_code={5}, address={6},address2={7},latitude={8},longitude={9},direction={10},booked={11}   WHERE id = {0}", entity.Id, entity.Name, entity.Image, entity.Country, entity.City, entity.ZipCode, entity.Address, entity.Address2, entity.Latitude, entity.Longitude, entity.Direction, entity.Booked);
                await context.SaveChangesAsync();
                return entity;
            }
        }

    }
}
