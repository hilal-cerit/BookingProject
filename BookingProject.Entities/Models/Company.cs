using BookingProject.Common.Entities;
using System;
using System.Collections.Generic;

namespace BookingProject.Entities.Models
{
    public partial class Company : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Age { get; set; }
        public string? Address { get; set; }
        public float? Salary { get; set; }
    }
}
