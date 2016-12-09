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
    /// Interaction logic for EditBooking.xaml
    /// </summary>
    public partial class EditBooking : Window
    {
        private Customer customer;
        private Booking currentBooking = new Booking();

        public EditBooking(Customer customer)
        {
            InitializeComponent();
            this.customer = customer;
            bookingListLable.Content = bookingListLable.Content + " " + String.Join(", ", customer.CustBookings);
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            HubPage hub = new HubPage(customer);
            hub.Show();
            this.Close();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

        }



        private void loadButton_Click(object sender, RoutedEventArgs e)
        {

            BookingTracker loader = BookingTracker.Instance;
            int id = Int32.Parse(lookupBox.Text);
            loader.ReadBooking(currentBooking, id);

            inDatePick.SelectedDate = currentBooking.ArrivalDate;
            outDatePick.SelectedDate = currentBooking.DepartureDate;
            dietBox.Text = currentBooking.Diet;

            if (currentBooking.Breakfast == true)
                breakfastBox.IsChecked = true;
            else
                breakfastBox.IsChecked = false;

            if (currentBooking.Meals == true)
                mealsBox.IsChecked = true;
            else
                breakfastBox.IsChecked = false;

            if (currentBooking.CarHire == true)
                carHireBox.IsChecked = true;
            else
                carHireBox.IsChecked = false;

            if (carHireBox.IsChecked == false) //if checkbox unchecked change to false and disable care hire inputs and vice versa
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

                driverNameBox.Text = currentBooking.DriverName;
                driveDay1Picker.SelectedDate = currentBooking.HireStart;
                driveDay2Picker.SelectedDate = currentBooking.HireEnd;
            }

            

        }

        private void carHireBox_Click(object sender, RoutedEventArgs e)
        {
            if (carHireBox.IsChecked == false) //if checkbox unchecked change to false and disable care hire inputs and vice versa
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
