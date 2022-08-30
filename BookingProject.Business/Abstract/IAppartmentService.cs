using BookingProject.Entities.Models;
using ChatApp.Common.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingProject.Business.Abstract
{
    public interface IAppartmentService
    {

        Task<IEnumerable<Appartment>> GetAll();
        Task<Appartment> Add(Appartment appartment);
        Task Delete(int appartmentId);
        Task<Appartment> Update(Appartment appartment);
        Task<Appartment> GetById(int appartmentId);


    }
}
