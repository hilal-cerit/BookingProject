using BookingProject.Common.DataAccess;
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
        public Task<IEnumerable<BookingDetailsDTO>> GetBookingDetailsDtos(string? firstName = null, string? lastName = null, string? startDate = null, string? finishDate = null, string? appartmentName = null, int? confirmed = null);
        
        }
}
