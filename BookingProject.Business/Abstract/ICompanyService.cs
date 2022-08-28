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

        IDataResult<Company> GetById(int companyId);
        IDataResult<List<Company>> GetAll();
        IResult Add(Company company);
        IResult Delete(int companyId);
        IResult Update(Company company);
    }
}
