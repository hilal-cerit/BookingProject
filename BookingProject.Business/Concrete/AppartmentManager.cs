using BookingProject.Business.Abstract;
using BookingProject.Business.ValidatorRules.FluentValidation;
using BookingProject.Common.Aspects.Autofac.Validation;
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

        public IResult Add(Appartment appartment)
        {
            _appartmentDal.Add(appartment);
         
            return new SuccessResult();
        }
        public IResult Delete(int appartmentId)
        {
           _appartmentDal.Delete(_appartmentDal.Get(p => p.Id == appartmentId));
            return new SuccessResult();
        }

        public IDataResult<List<Appartment>> GetAll()
        {
          
            return new SuccessDataResult<List<Appartment>>(_appartmentDal.GetAll());
        }

        public IDataResult<Appartment> GetById(int appartmentId)
        {
            return new SuccessDataResult<Appartment>(_appartmentDal.Get(p=>p.Id==appartmentId));
        }

        public IResult Update(Appartment appartment)
        {
            _appartmentDal.Update(appartment);
            return new SuccessResult();
        }
    }
}
