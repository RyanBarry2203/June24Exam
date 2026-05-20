using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace June24Exam.Models
{
    public class Customer
    {
        // properties
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string ContactNumber { get; set; }

        // foreign key, one to many relationship with Booking
        public List<Booking> Bookings { get; set; }

        // constructor
        public Customer()
        {
            Bookings = new List<Booking>();
        }

        // methods
        public override string ToString()
        {
            return $"CustomerId: {CustomerId}, Name: {Name}, ContactNumber: {ContactNumber}";
        }
    }
}
