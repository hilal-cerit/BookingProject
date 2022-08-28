using BookingProject.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingProject.Entities.DTOs
{
    public class BookingDetailsDTO:IDto
    {
        
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
     
        public string? AppartmentName { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
        public string? ZipCode { get; set; }
        public string? AppartmentAddress { get; set; }
        // normal format of startsat:"yyyy-mm-ddThh:mm:ss.fffZ"
        public string? StartsAt { 
            get {
                return DateTime.Parse(StartsAt).ToString("yyyy/mm/dd-hh:mm");
            }
            set { }
        }
        public int? BookedFor { get; set; }
        public int? Confirmed { get; set; }

        

        public string? FinishesAt
        {

            get {
             
                return DateTime.Parse( StartsAt).AddDays(Convert.ToInt64(BookedFor)).ToString("yyyy/mm/dd-hh:mm");
            }

            set
            {
               

            }
        }







    }
}
