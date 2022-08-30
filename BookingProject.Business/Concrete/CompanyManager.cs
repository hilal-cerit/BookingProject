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

        public async Task<Company> Add(Company company)
        {
           
            return await _companyDal.Add(company) ;
        }

        public async Task Delete(int companyId)
        {     
           
           await _companyDal.Delete(await _companyDal.Get(p => p.Id == companyId));
        }

        public async Task<IEnumerable<Company>> GetAll()
        {
            return await _companyDal.GetAll();
        }

        public async Task<Company> GetById(int companyId)
        {

            return await _companyDal.Get(p => p.Id == companyId);
        }

        public async Task<Company> Update(Company company)
        {
            ;
            return await _companyDal.Update(company) ;
        }
    }
}
