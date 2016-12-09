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
    public class BookingTracker
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


        public void IncrementCount()
        {
            int bookingCount = 0;

            if (!File.Exists(directory.GetPath() + "BookingCount.txt")) //initialise the incrementation file for customer ref if it doesnt already exist
            {
                _path = directory.GetPath() + "BookingCount.txt"; //new path for file containing customer ref persidtence
                try //check that there is a valid file path
                {
                    using (StreamWriter refIncrementer = new StreamWriter(_path, false)) //streamwriter to overwrite to specified path
                    {
                        refIncrementer.WriteLine(1); //print customer ref for next customer to be stored
                    }
                }
                catch (Exception e) //if no valid path (i.e. path = null) give a bonk error
                {
                    MessageBox.Show("There is no valid drive to write to!", "No valid drive.", //show reason for error
                    MessageBoxButton.OK, MessageBoxImage.Error); //give it the BONK noise and big fuck-off red X
                }
            }
            else //otherwise there is already a persistence file and this should determine the customer ref
            {
                _path = directory.GetPath() + "BookingCount.txt";
                string[] nextRef = File.ReadAllLines(_path);                               //read in file
                foreach (string line in nextRef)                                        //for each line in the file do the following
                {
                    string incrementRef = line;
                    bookingCount = Int32.Parse(incrementRef);                         //set customer ref to whatever number was in the file
                }

                using (StreamWriter refIncrementer = new StreamWriter(_path, false)) //streamwriter to overwrite to specified path
                {
                    refIncrementer.WriteLine(bookingCount + 1); //print customer ref for next customer to be stored
                }
            }
        }


        public void Store(Booking currentBooking, Customer currentCustomer)
        {
            int bookingCount = 0;

            _path = directory.GetPath() + "BookingCount.txt";
            try
            {

                string[] nextRef = File.ReadAllLines(_path);                               //read in file
                foreach (string line in nextRef)                                        //for each line in the file do the following
                {
                    string reference = line;
                    bookingCount = Int32.Parse(reference);                         //set customer ref to whatever number was in the file
                }

                currentBooking.BookingRef = bookingCount;
            }
            catch
            {
                MessageBox.Show("Number from the file could not be parsed. You've beenmessing around in the file to break it. That's cheating.", "Missing Ref Number Incrementer.", //show reason for error
                MessageBoxButton.OK, MessageBoxImage.Error); //BONK
            }

            _path = directory.GetPath() + "Bookings.txt"; //set path for full customer persistence file
            try //check that there is a valid file path
            {
                using (StreamWriter userTable = File.AppendText(_path)) //have a stream writer to append the line of gubbins to a file at the location in path
                {
                    //print in format [booking_id, customer_id, arrival_date, departure_date, diet_requirements, breakfast, meals, car_hire]
                    userTable.WriteLine("Booking Ref: " + bookingCount + ", Customer: " + currentCustomer.CustomerRef + ", aDate: " + currentBooking.ArrivalDate + ", dDate: " + currentBooking.DepartureDate + ", " +
                        currentBooking.Diet + ", " + currentBooking.Breakfast + ", " + currentBooking.Meals + ", " + currentBooking.CarHire + ", " + currentBooking.DriverName + ", " + currentBooking.HireStart + ", " + currentBooking.HireEnd + ", " + String.Join(", ", currentBooking.GuestList));
                }
            }
            catch (Exception e) //if no valid path (i.e. path = null) give a bonk error
            {
                MessageBox.Show("There is no valid drive to write to!", "No valid drive.", //show reason for error
                MessageBoxButton.OK, MessageBoxImage.Error); //give it the BONK noise and big fuck-off red X
            }
            
        }

        public void ReadBooking(Booking currentBooking, int id)
        {
            string searchId = id.ToString();

            bool match = false;                                                         //flag to allow checking if a match was found for the entered booking ref
            _path = directory.GetPath() + "Bookings.txt";                              //select correct file location to read
            string[] lines = File.ReadAllLines(_path);                                  //read in file
            foreach (string line in lines)                                               //for each line in the file do the following
            {
                if (line.Contains("Booking Ref: " + searchId))                         //execute if line contains customer reference number, marked different from booking refs by preceding text
                {
                    string[] words = Regex.Split(line, ", ");                           //split line into individual parts

                    //<get booking ref number>
                    string[] bookRefComponents = Regex.Split(words[0], ": ");               //split split booking ref num from it's marker text
                    string bookingRefString;                                           //intermediate string to represent customer ref num
                    bookingRefString = bookRefComponents[1];                               //first word is ALWAYS booking reference number
                    currentBooking.BookingRef = Int32.Parse(bookRefComponents[1]);      //turn string into int and apply to current booking reference number
                    //</get booking ref number>
                    match = true;

                    //IGNORE SECOND INDEX second word (words[1]) is ALWAYS reference number of the customer who made it

                    //<get stay times>
                    string[] dateComponents = Regex.Split(words[2], ": "); //third index holds a string and the datetime for arrival
                    currentBooking.ArrivalDate = Convert.ToDateTime(dateComponents[1]);

                    dateComponents = Regex.Split(words[3], ": "); //4th index holds a string and the datetime for departure
                    currentBooking.DepartureDate = Convert.ToDateTime(dateComponents[1]);
                    //</get stay times>

                    currentBooking.Diet = words[4]; //5th index is diet requirements

                    currentBooking.Breakfast = Convert.ToBoolean(words[5]);
                    MessageBox.Show(currentBooking.Breakfast.ToString());

                    currentBooking.Meals = Convert.ToBoolean(words[6]);

                    currentBooking.CarHire = Convert.ToBoolean(words[7]);

                    currentBooking.DriverName = words[8];

                    currentBooking.HireStart = Convert.ToDateTime(words[9]);

                    currentBooking.HireEnd = Convert.ToDateTime(words[10]);
                    
                    //<identify bookings linked to customer>
                    for (int i = 11; i < words.Length; i++)
                    {
                        MessageBox.Show(words[i]);
                        Guest nextGuest = new Guest();          //pass in a guestNumber starting at 1
                        currentBooking.AddToList(nextGuest);
                    }
                    //<identify bookings linked to this customer

                    break; //stop loop for efficiency after we've found what we need
                }
            }

            if (match == false)
            {
                MessageBox.Show("The booking reference number you entered was not recognised.", "Booking not found.", //show reason for error
                MessageBoxButton.OK, MessageBoxImage.Error); //whip out a BONK and an X
            }
        }



        public void Edit(Booking currentBooking, Customer currentCustomer)
        {
            bool match = false;                                                         //flag to allow checking if a match was found for associated booking ref
            string updateLine = "";
            _path = directory.GetPath() + "Bookings.txt";                              //select correct file location to read
            string bookString = currentBooking.BookingRef.ToString();

            string[] lines = File.ReadAllLines(_path);

            foreach (string line in lines)                                               //for each line in the file do the following
            {
                if (line.Contains("Booking Ref: " + bookString))
                {
                    updateLine = line;                                              //take line to be manipulated
                    match = true;
                    break;
                }
            }

            if (match == false)
            {
                MessageBox.Show("I don't know how you did it but you've somehow managed to edit a booking that doesn't exist." + String.Join(", ", currentBooking.BookingRef), "The fuck are you trying?", //reason for error
                MessageBoxButton.OK, MessageBoxImage.Error); //have a BONK for BEING a maverick
            }
            else
            {
                using (StreamWriter lineEdit = new StreamWriter(_path))
                {
                    foreach (string line in lines)                                               //for each line in the file do the following
                    {
                        if (!line.Contains("Booking Ref: " + bookString))                           //if line not a match overwrite it with itself, otherwise overwrite with new data
                        {
                            lineEdit.WriteLine(line);                                    
                        }
                        else
                        {
                            lineEdit.WriteLine("Booking Ref: " + currentBooking.BookingRef + ", Customer: " + currentCustomer.CustomerRef + ", aDate: " + currentBooking.ArrivalDate + ", dDate: " + currentBooking.DepartureDate + ", " +
                        currentBooking.Diet + ", " + currentBooking.Breakfast + ", " + currentBooking.Meals + ", " + currentBooking.CarHire + ", " + currentBooking.DriverName + ", " + currentBooking.HireStart + ", " + currentBooking.HireEnd + ", " + String.Join(", ", currentBooking.GuestList));
                        }
                    }

                }
            }
        }

        public void Delete(Customer currentCustomer, int booking)
        {

            bool match = false;                                                         //flag to allow checking if a match was found for associated customer ref
            string updateLine = "";
            _path = directory.GetPath() + "Bookings.txt";                              //select correct file location to read

            string[] lines = File.ReadAllLines(_path);

            foreach (string line in lines)                                               //for each line in the file do the following
            {
                if (line.Contains("Booking Ref: " + booking))
                {
                    updateLine = line;                                              //del line
                    match = true;
                    break;
                }
            }
            if (match == false)
            {
                MessageBox.Show("Trying to delete a booking which does not exist. " + booking, "The fuck are you trying?", //show reason for error
                MessageBoxButton.OK, MessageBoxImage.Error); //have a BONK for your troubles
            }
            else
            {
                using (StreamWriter lineDelete = new StreamWriter(_path))
                {
                    foreach (string line in lines)                                               //for each line in the file do the following
                    {
                        MessageBox.Show(booking.ToString());
                        if (!line.Contains("Booking Ref: " + booking))
                        {
                            lineDelete.WriteLine(line);                                     //overwrite each line with itself
                        }
                    }

                }
            }

        }

    }
}
