using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework_2
{
    class UserTracker //class to store and retrieve details from any user based on userId - Singleton pattern
    {
        private static UserTracker instance; //only reference to UserTracker object

        private UserTracker() { } //set to private so it can't be called

        public static UserTracker Instance
        {
            get
            {
                if(instance == null) //if this is the first call (i.e. instance is not null)
                {
                    instance = new UserTracker(); //instanciate the object
                }
                return instance; //else return instance (null)
            }
        }

        public void Store(Customer currentCustomer)
        {

        }
    }
}
