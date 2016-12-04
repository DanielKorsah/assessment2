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
    /// Interaction logic for CreateBooking.xaml
    /// </summary>
    public partial class CreateBooking : Window
    {
        Customer workingCustomer = null;
        public CreateBooking(Customer hubCust)
        {
            InitializeComponent();
            workingCustomer = hubCust;
        }
        

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (inDatePick.SelectedDate.Value.Date != null && outDatePick.SelectedDate.Value.Date != null)
            {
                Booking currentBooking = new Booking();                                     //instanciate current booking
                BookingTracker booker = BookingTracker.Instance;
                currentBooking.ArrivalDate = inDatePick.SelectedDate.Value.Date;            //set arrival dat eto chosen datepicker vaule
                currentBooking.DepartureDate = outDatePick.SelectedDate.Value.Date;         //ditto for departure date
                currentBooking.Diet = dietBox.Text;                                         //diet requirements get set

                //check if extra: breakfast is selected                                     //please forgive lack of brakets but this part is insanely long for what it is with them
                if (breakfastBox.IsChecked == true)
                    currentBooking.Breakfast = true;
                else
                    currentBooking.Breakfast = false;

                //check if extra: meals is selected
                if (mealsBox.IsChecked == true)
                    currentBooking.Meals = true;
                else
                    currentBooking.Meals = true;

                //check if extra: hire car is selected
                if (carBox.IsChecked == true)
                    currentBooking.CarHire = true;
                else
                    currentBooking.CarHire = true;

                booker.Store(currentBooking, workingCustomer);

            }
            else
            {
                MessageBox.Show("You must enter fill out all compulsory(*) fields!", "Missing data.", // reason for error
                MessageBoxButton.OK, MessageBoxImage.Error); //give 'em a BONK 
            }
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            HubPage hub = new HubPage(workingCustomer);
            hub.Show();
            this.Close();
        }
    }
}
