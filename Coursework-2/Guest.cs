//using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework_2
{
    public class Guest
    {
        //Handle each guest
        //4 guests can be listed per booking
        private string name;
        private string passport;
        private int age;
        private int booking;


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
    }
}
