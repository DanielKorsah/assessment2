using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;

namespace Coursework_2
{
    class UserTracker //class to store and retrieve details from any user based on userId - Singleton pattern
    {

        private string _path; //the location where users' gubbins will be stored and read from

        //<singletonify it>
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
        //</singletonify it>

        public string _Path //accessor to allow user to specify path to the table of gubbins
        {
            get { return _path; }
            set { _path = value; }
        }

        public void Store(Customer currentCustomer) //a method to store each customer in a text file along with their gubbins
        {
            DirectoryManager directory = new DirectoryManager();
            _path = directory.GetPath() + "Customers.txt";

            try //check that there is a valid file path
            {
                using (StreamWriter userTable = File.AppendText(_path)) //have a stream writer to append the line of gubbins to a file at the location in path
                {
                    userTable.WriteLine(currentCustomer.CustomerRef + ", " + currentCustomer.Name + " " + currentCustomer.Address); //the gubbins being printed in format [id, name, address]
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
