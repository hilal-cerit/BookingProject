using BookingProject.Common.DataAccess;
using BookingProject.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookingProject.DataAccess.Abstract
{
    public interface IAppartmentDal : IEntityRepository<Appartment>
    {
    
    }

}
