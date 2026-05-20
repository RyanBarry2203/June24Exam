using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace June24Exam.Data
{
    public class RestaurantData : DbContext
    {
        public RestaurantData() : base(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=OODExam_RyanBarry;Integrated Security=True;") { }
        public DbSet<Models.Customer> Customers { get; set; }
        public DbSet<Models.Booking> Bookings { get; set; }
    }
}
