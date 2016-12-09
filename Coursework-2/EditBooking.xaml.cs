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
        private Customer currentCustomer;
        private Booking currentBooking = new Booking();

        public EditBooking(Customer customer)//pass in consistent customer
        {
            InitializeComponent();
            this.currentCustomer = customer;
            bookingListLable.Content = bookingListLable.Content + " " + String.Join(", ", customer.CustBookings);
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            HubPage hub = new HubPage(currentCustomer);
            hub.Show();
            this.Close();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            BookingTracker editor = BookingTracker.Instance;
            editor.Edit(currentBooking, currentCustomer);
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

            GuestTracker guestLoader = GuestTracker.Instance;
            guestLoader.Read(currentBooking, id);

            foreach(Guest printG in currentBooking.GuestList)
            {
                guestsBox.Text +="Passport: " + printG.Passport + ", Name: " + printG.Name + ", Age: " + printG.Age + "\n";
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

        private void delButton_Click(object sender, RoutedEventArgs e)
        {
            int bookingId = Int32.Parse(lookupBox.Text);
            BookingTracker del = BookingTracker.Instance;
            del.Delete(currentCustomer, bookingId);
        }

        private void addGuestButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentBooking.GuestList.Count < 4)
            {
                Guest nextGuest = new Guest();
                AddGuest addGuest = new AddGuest(ref nextGuest, ref currentBooking); //pass by ref because we need it to change the values without having to pass it back
                addGuest.ShowDialog();

                //print the last added guest to the guestsbox in correct format - note user does not need to see booking ref
                guestsBox.Text += "Passport: " + nextGuest.Passport + ", Name: " + nextGuest.Name + ", Age: " + nextGuest.Age + "\n";
            }
            else
            {
                MessageBox.Show("You may only have 4 guests on a booking.", "Too many Guests.", // reason for error
                     MessageBoxButton.OK, MessageBoxImage.Error); //give 'em a BONK 
            }
        }

        private void delGuestButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
