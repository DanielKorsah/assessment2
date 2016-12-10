using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;
using System.Text.RegularExpressions;

namespace Coursework_2
{
    class Facade                                // facade class. to hide some of the more complexe code from the UI layer
    {
        private UserTracker _customer;
        private BookingTracker _booker;
        private GuestTracker _guests;
        private DirectoryManager _directory;

        EditBooking editor;

        public Facade(EditBooking editor)
        {
            _customer = UserTracker.Instance;
            _booker = BookingTracker.Instance;
            _guests = GuestTracker.Instance;
            _directory = DirectoryManager.Instance;

            this.editor = editor; //bring in reference to the booking editor 
        }

        public void EditBooking(Booking currentBooking, Customer currentCustomer)
        {
            bool passed = true;
            try
            {

                BookingTracker booker = BookingTracker.Instance;                            //instanciate current booking
                currentBooking.ArrivalDate = editor.inDatePick.SelectedDate.Value.Date;            //set arrival dat eto chosen datepicker vaule
                currentBooking.DepartureDate = editor.outDatePick.SelectedDate.Value.Date;         //ditto for departure date
                currentBooking.Diet = editor.dietBox.Text;                                         //diet requirements setter

                //validate for bad dates
                try
                {
                    int hireLength = (currentBooking.HireEnd - currentBooking.HireStart).Days;
                    if (Convert.ToDateTime(hireLength) <= DateTime.MinValue)
                    {
                        passed = false;
                        MessageBox.Show("Make sure you get here before you leave.", "Invalid inout.", // reason for error
                            MessageBoxButton.OK, MessageBoxImage.Error); //give 'em a BONK 
                    }
                }
                catch
                {
                    passed = false;
                }


                //check if extra: breakfast is selected                                     //please forgive lack of brakets but this part is insanely long for what it is with them
                if (editor.breakfastBox.IsChecked == true)
                    currentBooking.Breakfast = true;
                else
                    currentBooking.Breakfast = false;

                //check if extra: meals is selected
                if (editor.mealsBox.IsChecked == true)
                    currentBooking.Meals = true;
                else
                    currentBooking.Meals = false;

                //check if extra: hire car is selected
                if (editor.carHireBox.IsChecked == true)
                    currentBooking.CarHire = true;
                else
                    currentBooking.CarHire = false;

                //make sure that null values never end up being attempted to be printed for the car hire fields
                if (editor.carHireBox.IsChecked == false)
                {
                    currentBooking.DriverName = "N/A";
                    currentBooking.HireStart = DateTime.MinValue;
                    currentBooking.HireEnd = DateTime.MinValue;
                }
                else
                {
                    currentBooking.DriverName = editor.driverNameBox.Text;
                    currentBooking.HireStart = editor.driveDay1Picker.SelectedDate.Value.Date;
                    currentBooking.HireEnd = editor.driveDay2Picker.SelectedDate.Value.Date;
                }

                booker.IncrementCount();                                                    //increment the 
                booker.Store(currentBooking, currentCustomer);                              // call the Store method in the booking manager


                GuestTracker gPrint = GuestTracker.Instance;
                gPrint.Store(currentBooking);                                               //write guests from the list in booking to a file 


                MessageBox.Show("Your Booking reference number is: " + (currentBooking.BookingRef) + "\n You will need this later.");


                UserTracker addBooking = UserTracker.Instance;
                addBooking.AddBooking(currentBooking, currentCustomer);

                if (passed == true)
                {
                    HubPage hub = new HubPage(currentCustomer);
                    hub.Show();
                    editor.Close();
                }


            }
            catch
            {
                MessageBox.Show("You must enter data in all compulsory (*) fields.", "Missing data.", // reason for error
                     MessageBoxButton.OK, MessageBoxImage.Error); //give 'em a BONK 
            }
        }
    }
}
