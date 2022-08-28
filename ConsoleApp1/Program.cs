using BookingProject.Business.Concrete;
using BookingProject.DataAccess.Concrete.EntityFramework;
using BookingProject.Entities.Models;

internal class Program
{
    private static void Main(string[] args)
    {
        User user = new User();
        UserManager usersss = new UserManager(new EfUserDal());

        //foreach (User s  in usersss.GetAll())
        //{
        //    Console.WriteLine(s.FirstName);
        //}
       

    }
}