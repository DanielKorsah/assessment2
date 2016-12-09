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
    class GuestTracker //singleton class to manage IO operations for Guests
    {
        private string path;
        DirectoryManager dm = DirectoryManager.Instance;

        //<singletonify it>
        private static GuestTracker instance; //only reference to GuestTracker object

        private GuestTracker() { } //set to private so it can't be called

        public static GuestTracker Instance
        {
            get
            {
                if (instance == null) //if this is the first call (i.e. instance is not null)
                {
                    instance = new GuestTracker(); //instanciate the object
                }
                return instance; //else return instance (null)
            }
        }
        //</singletonify it>



        public void Store(Booking currentBooking)
        {
            
            path = dm.GetPath() + "Guests.txt";
            try
            {
                using (StreamWriter guestPrinter = new StreamWriter(path, true)) //streamwriter to append to specified path
                {
                    foreach (Guest printG in currentBooking.GuestList)
                    {
                        guestPrinter.WriteLine("Booking: " + currentBooking.BookingRef + ", " + printG.Passport + ", " + printG.Name + ", " + printG.Age); //print in format [booking, passport, name, age]
                    }
                }
            }
            catch
            {
                MessageBox.Show("You must enter data in all compulsory (*) fields.", "No valid drive/directory.", // reason for error
                     MessageBoxButton.OK, MessageBoxImage.Error); //give 'em a BONK 
            }
        }

        
        public void Read(Booking currentBooking, int searchId)
        {
            path = dm.GetPath() + "Guests.txt";                                         //get path to file
            string[] lines = File.ReadAllLines(path);                                   //read all lines into an array

            foreach (string line in lines)
            {
                if(line.Contains("Booking: " + searchId))              //on any line which contains the reference number for this booking do the following
                {
                    Guest liftGuest = new Guest();
                    string[] properties = Regex.Split(line, ", ");      //split the line into distinct parts to be assigned to properties of a guest
                                                                        //ignore properties[0], that's the booking ref preceded by it's text marker
                    liftGuest.Passport = properties[1];                 //passport number is at index 1
                    liftGuest.Name = properties[2];                     //name at index 2
                    liftGuest.Age = Int32.Parse(properties[3]);         //age at index 3

                    currentBooking.AddToList(liftGuest);                //add the guest we just constructed to a list of all guests on this booking up to 4
                }
            }

        }

        public void Delete(Booking currentBooking, string passNum)
        {

            bool match = false;                                                         //flag to allow checking if a match was found for associated customer ref
            string updateLine = "";
            path = dm.GetPath() + "Guests.txt";                              //select correct file location to read

            string[] lines = File.ReadAllLines(path);

            foreach (string line in lines)                                               //for each line in the file do the following
            {
                if (line.Contains("Booking: " + currentBooking.BookingRef) && line.Contains(passNum))
                {
                    updateLine = line;                                              //take line to be maipulated
                    match = true;
                    break;
                }
            }
            if (match == false)
            {
                MessageBox.Show("Trying to delete a Guest which does not exist. " + passNum, "The fuck are you trying?", //show reason for error
                MessageBoxButton.OK, MessageBoxImage.Error); //have a BONK for your troubles
            }
            else
            {
                using (StreamWriter lineDelete = new StreamWriter(path))
                {
                    foreach (string line in lines)                                               //for each line in the file do the following
                    {
                        if (!line.Contains(passNum))
                        {
                            lineDelete.WriteLine(line);                                     //overwrite the line being replaced
                        }
                    }

                }
            }
        }
    }
}
