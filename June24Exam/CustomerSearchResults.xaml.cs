using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using June24Exam.Data;
using June24Exam.Models;

namespace June24Exam
{
    /// <summary>
    /// Interaction logic for CustomerSearchResults.xaml
    /// </summary>
    public partial class CustomerSearchResults : Window
    {
        private string _customerName;
        private Customer _customer;
        private Booking _booking;


        public CustomerSearchResults()
        {
            InitializeComponent();
        }
        public CustomerSearchResults(string customerName) : this()
        {
            _customerName = customerName;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //tweak so every booking for every customer with the name that contains the search term is displayed in the listbox, not just the first one
            using (var db = new RestaurantData())
            {
                var customers = db.Customers
                    .Where(c => c.Name.Contains(_customerName))
                    .ToList();

                foreach (var customer in customers) 
                {
                    //get all bookings for the customer and add them to the listbox
                    var bookings = db.Bookings
                        .Where(b => b.CustomerId == customer.CustomerId)
                        .ToList();

                    lbCustomerSearchResults.ItemsSource = bookings;
                }
            }
        }

        private void btnCreateNewCustomer_Click(object sender, RoutedEventArgs e)
        {

        }

        private void lbCustomerSearchResults_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _booking = lbCustomerSearchResults.SelectedItem as Booking;
            if (_booking != null)
            {
                //display details of booking and customer from using the data from the selected booking in the listbox
                using (var db = new RestaurantData())
                {
                    _customer = db.Customers.Find(_booking.CustomerId);
                    if (_customer != null)
                    {
                        //display the details of the booking and customer in the labels
                        tbxNewCustomerName.Text = _customer.Name;
                        tbxNewCustomerContactNumber.Text = _customer.ContactNumber;
                        tbxNewCustomerDateOfBooking.Text = $"Date of booking: {_booking.BookingsDate.ToString()}";
                        tbxNewCustomerNumOfCustomers.Text = $"Number of customers: {_booking.NumberOfParticipants.ToString()}";
                    }
                }

            }
        }
    }
}
