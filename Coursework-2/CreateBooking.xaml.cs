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
        Customer workingCustomer;

        public CreateBooking(Customer hubCust)
        {
            InitializeComponent();
            workingCustomer = hubCust;
        }


        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
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
                    currentBooking.Meals = false;

                //check if extra: hire car is selected
                if (carBox.IsChecked == true)
                    currentBooking.CarHire = true;
                else
                    currentBooking.CarHire = false;

                //make sure that null values never end up being attempted to be printed for the car hire fields
                if (carBox.IsChecked == false)
                {
                    currentBooking.DriverName = "N/A";
                    currentBooking.HireStart = DateTime.MinValue;
                    currentBooking.HireEnd = DateTime.MinValue;
                }
                else
                {
                    currentBooking.DriverName = driverNameBox.Text;
                    currentBooking.HireStart = driveDay1Picker.SelectedDate.Value.Date;
                    currentBooking.HireEnd = driveDay2Picker.SelectedDate.Value.Date;
                }

                booker.IncrementCount();                                                    //increment the 
                booker.Store(currentBooking, workingCustomer);                              // call the Store method in the booking manager


                MessageBox.Show("Your Booking reference number is: " + (currentBooking.BookingRef) + "\n You will need this later.");


                UserTracker addBooking = UserTracker.Instance;
                addBooking.AddBooking(currentBooking, workingCustomer);

                HubPage hub = new HubPage(workingCustomer);
                hub.Show();
                this.Close();


            }
            catch 
            {
                MessageBox.Show("You must enter data in all compulsory (*) fields.", "Missing data.", // reason for error
                     MessageBoxButton.OK, MessageBoxImage.Error); //give 'em a BONK 
            }
        }


        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            HubPage hub = new HubPage(workingCustomer);
            hub.Show();
            this.Close();
        }

        private void carBox_Click(object sender, RoutedEventArgs e)
        {
            if(carBox.IsChecked == false) //if checkbox unchecked change to false and disable care hire inputs and vice versa
            {
                driverNameBox.IsEnabled = false;
                driveDay1Picker.IsEnabled = false;
                driveDay2Picker.IsEnabled = false;
            }
            else
            {
                driverNameBox.IsEnabled = true;
                driveDay1Picker.IsEnabled = true;
                driveDay2Picker.IsEnabled = true;
            }
        }
    }
}
