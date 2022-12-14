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
    public class UserManager:IUserService
    {
        IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public async Task<User>Add(User user)
        {
           
            return await _userDal.Add(user);
        }
   
        public async Task Delete(int userId)
        {
            if (await _userDal.Get(p => p.Id == userId) != null)
            {
                await _userDal.Delete(await _userDal.Get(p => p.Id == userId));
            }
            else
            {
                throw new Exception("There isn't any data with this Id!");
            }

        

        
            
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _userDal.GetAll();
        }

        public async Task<User> GetById(int userId)
        {
            return await _userDal.Get(p => p.Id == userId);
        }

        public async Task<User> Update(User user)
        {
            if (await _userDal.Get(p => p.Id == user.Id) != null)
            {
                return await _userDal.Update(user);
            }
            else
            {
                throw new Exception("There isn't any data with this Id!");
            }

        }
    }
}
