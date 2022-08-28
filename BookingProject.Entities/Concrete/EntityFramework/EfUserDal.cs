using BookingProject.Common.DataAccess.EntityFramework;
using BookingProject.DataAccess.Abstract;
using BookingProject.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingProject.DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, booking1661538931410oilduxjtefmbtrtwContext>, IUserDal
    {
    }
}
