using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace June24Exam.Models
{
    public class Booking
    {
        // properties
        public int BookingId { get; set; }
        public DateTime BookingsDate { get; set; }
        public int NumberOfParticipants { get; set; }

        // foreign key, many to one relationship with Customer
        public int CustomerId { get; set; }

        // constructor
        public Booking()
        {

            
        }

        // methods
         public override string ToString()
        {
            return $"BookingId: {BookingId}, BookingsDate: {BookingsDate}, NumberOfParticipants: {NumberOfParticipants}";
        }
    }
}
