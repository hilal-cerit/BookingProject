using BookingProject.Business.Abstract;
using BookingProject.DataAccess.Abstract;
using BookingProject.DataAccess.Concrete.EntityFramework;
using BookingProject.Entities.Models;
using ChatApp.Common.Result;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

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
            if (await _companyDal.Get(p => p.Id == companyId) != null)
            {
                await _companyDal.Delete(await _companyDal.Get(p => p.Id == companyId));
            }
            else
            {
                throw new Exception("There isn't any data with this Id!");
            }
         
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
            if (await _companyDal.Get(p => p.Id == company.Id) != null )
            {
                return await _companyDal.Update(company);
            }
            else
            {
                throw new Exception("There isn't any data with this Id!");
            }
            
        }
    }
}
