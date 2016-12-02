using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework_2
{
    class BookingTracker
    {
        DirectoryManager directory = DirectoryManager.Instance; //create a singleton instance for the directory manager
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
    }
}
