using BookingProject.Common.DataAccess;
using BookingProject.Common.Entities;
using BookingProject.Entities.DTOs;
using BookingProject.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookingProject.DataAccess.Abstract
{
    public interface IBookingDal : IEntityRepository<Booking>
    {
        public List<BookingDetailsDTO> GetBookingDetailsDtos(Expression<Func<BookingDetailsDTO, bool>> filter);
        
        }
}
