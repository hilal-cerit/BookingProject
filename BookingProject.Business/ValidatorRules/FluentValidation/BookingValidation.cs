using BookingProject.Entities.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingProject.Business.ValidatorRules.FluentValidation
{
    public class BookingValidation:AbstractValidator<Booking>
    {
        public BookingValidation()
        {
         RuleFor(x => x.Confirmed==0).NotNull().WithMessage("Confirmed should be 1 to delete");

        }
     


    }
}
