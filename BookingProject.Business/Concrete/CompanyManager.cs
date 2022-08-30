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
    public class CompanyManager : ICompanyService
    {
        ICompanyDal _companyDal;
        public CompanyManager(ICompanyDal companyDal)
        {
            _companyDal = companyDal;
    }

        public IResult Add(Company company)
        {
            _companyDal.Add(company);
            return new SuccessResult();
        }

        public IResult Delete(int companyId)
        {     
            _companyDal.Delete(_companyDal.Get(p => p.Id == companyId));
            return new SuccessResult();
        }

        public IDataResult<List<Company>> GetAll()
        {
            return new SuccessDataResult<List<Company>>(_companyDal.GetAll());
        }

        public IDataResult<Company> GetById(int companyId)
        {

            return new SuccessDataResult<Company>(_companyDal.Get(p => p.Id == companyId));
        }

        public IResult Update(Company company)
        {
            _companyDal.Update(company);
            return new SuccessResult();
        }
    }
}
