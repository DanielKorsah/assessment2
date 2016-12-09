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

namespace Coursework_2
{
    /// <summary>
    /// Interaction logic for InvoicePage.xaml
    /// </summary>
    public partial class InvoicePage : Window
    {
        private Customer currentCustomer;
        private Booking currentBooking;

        public InvoicePage(Customer currentCustomer)
        {
            InitializeComponent();
            this.currentCustomer = currentCustomer;
            bookingsLabel.Content += String.Join(", ", currentCustomer.CustBookings);
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            HubPage hub = new HubPage(currentCustomer);
            hub.Show();
            this.Close();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            bool success = false;
            
            currentBooking = new Booking();
            BookingTracker reader = BookingTracker.Instance;

            try
            {
                int searchNum = Int32.Parse(numBox.Text);
                reader.ReadBooking(currentBooking, searchNum);
                success = true;
            }
            catch
            {
                MessageBox.Show("You must enter a number... and yes I know you aren't booking number 2,147,483,647 + x.", "Missing data.", // reason for error
                MessageBoxButton.OK, MessageBoxImage.Error); //get BONKED
            }
            
            if(success == true)
            {
                
                double nightsCost;
                double breakfastCost;
                double mealCost;
                double hireCost;

                //cost due to length of stay
                int stayLength = (currentBooking.DepartureDate - currentBooking.ArrivalDate).Days;
                nightsCost = 50 * stayLength;

                //cost due to breakfast extra
                if (currentBooking.Breakfast == true)
                    breakfastCost = 5 * currentBooking.GuestList.Count * stayLength;
                else
                    breakfastCost = 0;

                //cost due to evening meals
                if (currentBooking.Meals == true)
                    mealCost = 15 * currentBooking.GuestList.Count;
                else
                    mealCost = 0;

                //cost due to car hire time
                int hireLength = (currentBooking.HireEnd - currentBooking.HireStart).Days;
                hireCost = 50 * hireLength;


            }
            else
            {
                //error already shown, another is unnecessary
            }
        }
    }
}
