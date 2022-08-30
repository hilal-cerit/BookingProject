using BookingProject.Entities.Models;
using ChatApp.Common.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingProject.Business.Abstract
{
    public interface ICompanyService
    {

        Task<Company> GetById(int companyId);
        Task<IEnumerable<Company>> GetAll();
        Task<Company> Add(Company company);
        Task Delete(int companyId);
        Task<Company> Update(Company company);
    }
}
