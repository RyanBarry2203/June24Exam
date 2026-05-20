using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using June24Exam.Data;
using June24Exam.Models;
    
namespace DataManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RestaurantData db = new RestaurantData();

            using (db)
            {
                // create a new customer
                Customer customer1 = new Customer
                {
                    Name = "John Doe",
                    ContactNumber = "123-456-7890"
                };

                // add the customer to the database
                db.Customers.Add(customer1);

                // create a new booking for the customer
                Booking booking1 = new Booking
                {
                    BookingsDate = DateTime.Now,
                    NumberOfParticipants = 4,
                    CustomerId = customer1.CustomerId
                };

                // add the booking to the database
                db.Bookings.Add(booking1);


                db.SaveChanges();
            }

        }
    }
}
