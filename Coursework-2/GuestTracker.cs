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
    class GuestTracker
    {
        private string path;
        DirectoryManager dm = DirectoryManager.Instance;

        public void Write(Booking currentBooking)
        {
            
            path = dm.GetPath() + "Guests.txt";
            try
            {
                using (StreamWriter guestPrinter = new StreamWriter(path, false)) //streamwriter to overwrite to specified path
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

        
        public void Read(Booking currentBooking)
        {
            path = dm.GetPath() + "Guests.txt";                                         //get path to file
            string[] lines = File.ReadAllLines(path);                                   //read all lines into an array

            foreach (string line in lines)
            {
                if(line.Contains("Booking: " + currentBooking.BookingRef))              //on any line which contains the reference number for this booking do the following
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
    }
}
