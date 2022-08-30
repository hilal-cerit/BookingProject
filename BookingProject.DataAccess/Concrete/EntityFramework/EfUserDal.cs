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
    public class EfUserDal : EfEntityRepositoryBase<User, booking1661538931410oilduxjtefmbtrtwContext>, IUserDal
    {

        public async Task<User> Add(User entity)
        {
            using (booking1661538931410oilduxjtefmbtrtwContext context = new booking1661538931410oilduxjtefmbtrtwContext())
            {

                 var latestRow =  context.Users.AsNoTrackingWithIdentityResolution().OrderByDescending(a => a.Id).FirstOrDefault();
                entity.Id = latestRow.Id + 1;
               
                context.Database.ExecuteSqlRaw("INSERT INTO users (Id,first_name, last_name, full_name, job_title, job_type, phone,email,image,country,city,onboarding_completion)" +
                    " VALUES ({0}, {1}, {2}, {3},{4}, {5},{6},{7}, {8}, {9}, {10},{11});", entity.Id, entity.FirstName,entity.LastName, entity.FullName, entity.JobTitle, entity.JobType, entity.Phone, entity.Email, entity.Image, entity.Country, entity.City, entity.OnboardingCompletion);

                await context.SaveChangesAsync();
                return entity;  

            }
        }
        public async Task Delete(User entity)
        {
            using (booking1661538931410oilduxjtefmbtrtwContext context = new booking1661538931410oilduxjtefmbtrtwContext())
            {
                int isConfirmed = context.Database.ExecuteSqlRaw("SELECT confirmed FROM bookings join users on users.Id=bookings.user_id WHERE users.Id={0} ;", entity.Id);
                if(isConfirmed==0) {
                context.Database.ExecuteSqlRaw("DELETE FROM users WHERE Id={0};",entity.Id);
                await context.SaveChangesAsync();
             
                }
                else
                {
                    throw new Exception("Can't delete this data because it is not confirmed");
                }

            }



        }
        public async Task<User> Update(User entity)
        {
            using (booking1661538931410oilduxjtefmbtrtwContext context = new booking1661538931410oilduxjtefmbtrtwContext())
            {
                context.Database.ExecuteSqlRaw("UPDATE users SET first_name={1}, last_name={2}, full_name={3}, job_title={4}, job_type={5}, phone={6},email={7},image={8},country={9},city={10},onboarding_completion={11}   WHERE id = {0}", entity.Id, entity.FirstName, entity.LastName, entity.FullName, entity.JobTitle, entity.JobType, entity.Phone, entity.Email, entity.Image, entity.Country, entity.City, entity.OnboardingCompletion);
                await context.SaveChangesAsync();
                return entity;
            }
        }





    }
}
