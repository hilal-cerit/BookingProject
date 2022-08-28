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
        
        IDataResult<List<Appartment>> GetAll();
        IResult Add(Appartment appartment);
        IResult Delete(int appartmentId);
        IResult Update(Appartment appartment);
        IDataResult<Appartment> GetById(int appartmentId);


    }
}
