﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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

        public void Store(Customer currentCustomer) //a method to store each customer in a text file along with their gubbins
        {
            string path = @"G:\Customers.csv"; //the location of said gubbins
            using (StreamWriter userTable = File.AppendText(path)) //have a stream writer to append the line of gubbins to a file at the location in path
            {
                userTable.WriteLine(currentCustomer.Name + " " + currentCustomer.Address); //the gubbins being printed
            }

        }
    }
}