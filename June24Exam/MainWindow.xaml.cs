using June24Exam.Data;
using June24Exam.Models;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Data.Entity.Infrastructure.Design.Executor;
using System.Data.Entity;

namespace June24Exam
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        RestaurantData db;   
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        { 

        }
        private void dpBookingDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            db = new RestaurantData();
            using (db)
            {
                //query database and display all bookings for selected date in datepicker
                DateTime? selectedDate = dpBookingDate.SelectedDate;

                //use a link query to get all bookings for the selected date
                var bookings = db.Bookings.
                    Where(b => b.BookingsDate == selectedDate).
                    ToList();
                lbBookings.ItemsSource = bookings;

                //query the database for the total amount of people booked in for that day, number of bookings and whats available based on the restaurants capacity of 40 people
                int totalParticipants = bookings.Sum(b => b.NumberOfParticipants);
                int totalBookings = bookings.Count();
                int availableSpots = 40 - totalParticipants;

                //display the results in the labels
                Bookings.Content = $"Bookings: {totalBookings}";
                Available.Content = $"Available : {availableSpots}";
            }
        }

        private void lbBookings_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnAddBooking_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCustomerSearch_Click(object sender, RoutedEventArgs e)
        {
            string CustomerName = tbxCustomerName.Text;
            CustomerSearchResults customerSearchWindow = new CustomerSearchResults(CustomerName);
            customerSearchWindow.ShowDialog();
        }
    }
}
