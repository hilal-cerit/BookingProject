﻿using BookingProject.Common.DataAccess.EntityFramework;
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
    public class EfCompanyDal : EfEntityRepositoryBase<Company, booking1661538931410oilduxjtefmbtrtwContext>, ICompanyDal
    {


        public void Add(Company entity)
        {
            using (booking1661538931410oilduxjtefmbtrtwContext context = new booking1661538931410oilduxjtefmbtrtwContext())
            {

                var latestRow = context.Companies.AsNoTrackingWithIdentityResolution().OrderByDescending(a => a.Id).FirstOrDefault();
                entity.Id = latestRow.Id + 1;

                context.Database.ExecuteSqlRaw("INSERT INTO company (Id,Name, Age, Address, Salary)" +
                    " VALUES ({0}, {1}, {2}, {3},{4});", entity.Id, entity.Name, entity.Age, entity.Address, entity.Salary);

                context.SaveChanges();

            }
        }
        public void Delete(Company entity)
        {
            using (booking1661538931410oilduxjtefmbtrtwContext context = new booking1661538931410oilduxjtefmbtrtwContext())
            {
               
                    context.Database.ExecuteSqlRaw("DELETE FROM company WHERE Id={0};", entity.Id);
                    context.SaveChanges();
              

            }



        }
        public void Update(Company entity)
        {
            using (booking1661538931410oilduxjtefmbtrtwContext context = new booking1661538931410oilduxjtefmbtrtwContext())
            {
                context.Database.ExecuteSqlRaw("UPDATE company SET name={1}, age={2}, full_name={3}, address={4}, salary={5} WHERE id = {0}", entity.Id, entity.Name, entity.Age, entity.Address, entity.Salary);
                context.SaveChanges();
            }
        }















    }
}
