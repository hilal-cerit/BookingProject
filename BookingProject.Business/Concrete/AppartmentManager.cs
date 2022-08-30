using BookingProject.Business.Abstract;

using BookingProject.DataAccess.Abstract;
using BookingProject.DataAccess.Concrete.EntityFramework;
using BookingProject.Entities.Models;
using ChatApp.Common.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingProject.Business.Concrete
{
    public class AppartmentManager : IAppartmentService
    {
        IAppartmentDal _appartmentDal;

        public AppartmentManager(IAppartmentDal appartmentDal)
        {
            _appartmentDal = appartmentDal;
        }

        public async Task<Appartment> Add(Appartment appartment)
        {
           
         
            return await _appartmentDal.Add(appartment);
        }
        public async Task Delete(int appartmentId)
        {
           await _appartmentDal.Delete( await _appartmentDal.Get(p => p.Id == appartmentId));
          
        }

        public async Task<IEnumerable<Appartment>> GetAll()
        {
          
            return await _appartmentDal.GetAll();
        }

        public async Task<Appartment> GetById(int appartmentId)
        {
            return await _appartmentDal.Get(p=>p.Id==appartmentId);
        }

        public async Task<Appartment> Update(Appartment appartment)
        {
          
            return await _appartmentDal.Update(appartment);
        }
    }
}
