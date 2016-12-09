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
    public class Guest
    {
        //Handle each guest
        //4 guests can be listed per booking
        private string name;
        private string passport;
        private int age;
        private int booking;        //booking ref of booking that the guest was applied to
        private int guestNumber; //number indicating the position in the list of 4 guest allowed on each booking

        public Guest(string index)
        {
            try
            {
                guestNumber = Int32.Parse(index);
            }
            catch
            {
                MessageBox.Show("Error cause by not having any guests I think.");
            }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Passport
        {
            get { return passport; }
            set { passport = value; }
        }

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public int Booking
        {
            get { return booking; }
            set { booking = value; }
        }

        public int GuestNumber
        {
            get { return guestNumber; }
            set {guestNumber = value; }
        }
    }
}
