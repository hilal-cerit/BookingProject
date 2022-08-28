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

        public void Delete(Appartment appartment)
        {
            using (booking1661538931410oilduxjtefmbtrtwContext context = new booking1661538931410oilduxjtefmbtrtwContext())
            {    
                //    context.Remove(context.Set<TEntity>().Single(a => a.Equals(entity)));
                var deletedEntity = context.Entry(appartment);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();

            }
        }
    }
}
