using BookingProject.Entities.Models;
using ChatApp.Common.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingProject.Business.Abstract
{
    public interface IUserService
    {

        Task<User> GetById(int userId);
        Task<IEnumerable<User>> GetAll();
        Task<User> Add(User user);
        Task Delete(int userId);
        Task<User> Update(User user);
    }
}
