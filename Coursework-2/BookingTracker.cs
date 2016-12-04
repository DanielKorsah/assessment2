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
    class BookingTracker
    {
        DirectoryManager directory = DirectoryManager.Instance; //create a singleton instance for the booking tracker
        private string _path; //the location where bookings will be stored and read from


        //<singletonify it>
        private static BookingTracker instance; //only reference to BookingTracker object

        private BookingTracker() { } //set to private so it can't be called

        public static BookingTracker Instance
        {
            get
            {
                if (instance == null) //if this is the first call (i.e. instance is not null)
                {
                    instance = new BookingTracker(); //instanciate the object
                }
                return instance; //else return instance (null)
            }
        }
        //</singletonify it>

        public string _Path //accessor to allow user to specify path to the table of gubbins
        {
            get { return _path; }
            set { _path = value; }
        }

        void Store(Booking currentBooking, Customer currentCustomer)
        {
            //<autoincrement booking ref>
            if (!File.Exists(directory.GetPath() + "BookingCount.txt")) //initialise the incrementation file for customer ref if it doesnt already exist
            {
                _path = directory.GetPath() + "BookingCount.txt"; //new path for file containing customer ref persidtence
                try //check that there is a valid file path
                {
                    using (StreamWriter refIncrementer = new StreamWriter(_path, false)) //streamwriter to overwrite to specified path
                    {
                        refIncrementer.WriteLine(1); //print customer ref for next customer to be stored
                        currentBooking.BookingRef = 1;
                    }
                }
                catch (Exception e) //if no valid path (i.e. path = null) give a bonk error
                {
                    MessageBox.Show("There is no valid drive to write to!", "No valid drive.", //show reason for error
                    MessageBoxButton.OK, MessageBoxImage.Error); //give it the BONK noise and big fuck-off red X
                }
            }
            else //otherwise there is already a persistence file and this should determine the booking ref
            {
                _path = directory.GetPath() + "CustCount.txt";
                string[] nextRef = File.ReadAllLines(_path);                                //read in file
                foreach (string line in nextRef)                                            //for each line in the file do the following
                {
                    string incrementRef = line;
                    currentCustomer.CustomerRef = Int32.Parse(incrementRef);                //set customer ref to whatever number was in the file
                }
                 
            }
            //</autoincrement booking ref>

            _path = directory.GetPath() + "Bookings.txt"; //set path for full customer persistence file
            try //check that there is a valid file path
            {
                using (StreamWriter userTable = File.AppendText(_path)) //have a stream writer to append the line of gubbins to a file at the location in path
                {
                    //print in format [booking_id, customer_id, arrival_date, departure_date, diet_requirements, breakfast, meals, car_hire]
                    userTable.WriteLine("Booking Ref: " + currentBooking.BookingRef + ", Customer: " + currentCustomer.CustomerRef + ", aDate: " + currentBooking.ArrivalDate + ", dDate: " + currentBooking.DepartureDate + ", " + 
                        currentBooking.Diet + ", " + currentBooking.Breakfast + ", " + currentBooking.Meals + ", " + currentBooking.CarHire); 
                }
            }
            catch (Exception e) //if no valid path (i.e. path = null) give a bonk error
            {
                MessageBox.Show("There is no valid drive to write to!", "No valid drive.", //show reason for error
                MessageBoxButton.OK, MessageBoxImage.Error); //give it the BONK noise and big fuck-off red X
            }

            currentCustomer.CustomerRef += 1; //thisis the customer ref for the next user to sign on

            _path = directory.GetPath() + "CustCount.txt"; //set path for file containing customer ref persidtence
            try //check that there is a valid file path
            {
                using (StreamWriter refIncrementer = new StreamWriter(_path, false)) //streamwriter to overwrite to specified path
                {
                    int incrementer = currentBooking.BookingRef += 1;
                    refIncrementer.WriteLine(incrementer); //print customer ref for next customer to be stored
                }

            }
            catch (Exception e) //if no valid path (i.e. path = null) give a bonk error
            {
                MessageBox.Show("There is no valid drive to write to!", "No valid drive.", //show reason for error
                MessageBoxButton.OK, MessageBoxImage.Error); //give it the BONK noise and big fuck-off red X
            }
        }

    }
}
