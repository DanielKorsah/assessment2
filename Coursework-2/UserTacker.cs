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
    public class UserTracker //class to store and retrieve details from any user based on userId - Singleton pattern
    {
        DirectoryManager directory = DirectoryManager.Instance; //create a singleton object for the directory manager
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

        public void Store(Customer currentCustomer) //a method to store each customer in a text file along with their gubbins and auto-increment their customer ref
        {

            if (!File.Exists(directory.GetPath() + "CustCount.txt")) //initialise the incrementation file for customer ref if it doesnt already exist
            {
                _path = directory.GetPath() + "CustCount.txt"; //new path for file containing customer ref persidtence
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
               
                string nextRef = File.ReadAllText(_path);                                  //read in file
                foreach (string line in nextRef)                                               //for each line in the file do the following
                {
                    int incrementRef = line[0];
                    currentCustomer.CustomerRef = incrementRef; //set customer ref to whatever number was in the file
                }
                 
            }


            _path = directory.GetPath() + "Customers.txt"; //set path for full customer persistence file
            try //check that there is a valid file path
            {
                using (StreamWriter userTable = File.AppendText(_path)) //have a stream writer to append the line of gubbins to a file at the location in path
                {
                    userTable.WriteLine("Customer Ref: " + currentCustomer.CustomerRef + ", " + currentCustomer.Name + " " + currentCustomer.Address); //the gubbins being printed in format [id, name, address]
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
                    refIncrementer.WriteLine(currentCustomer.CustomerRef); //print customer ref for next customer to be stored
                }

            }
            catch (Exception e) //if no valid path (i.e. path = null) give a bonk error
            {
                MessageBox.Show("There is no valid drive to write to!", "No valid drive.", //show reason for error
                MessageBoxButton.OK, MessageBoxImage.Error); //give it the BONK noise and big fuck-off red X
            }
        }


        //<lookup user and get properties based on user reference number>
        public void ReadCustomer(string checkNum, Customer currentCustomer)
        {
            bool match = false;                                                         //flag to allow checking if a match was found for the entered customer ref
            _path = directory.GetPath() + "Customers.txt";                              //select correct file location to read
            string[] lines = File.ReadAllLines(_path);                                  //read in file
            foreach (string line in lines)                                               //for each line in the file do the following
            {
                if (line.Contains("Customer Ref: " + checkNum))                         //execute if line contains customer reference number, marked different from booking refs by preceding text
                {
                    string[] words = Regex.Split(line, ", ");                            //split line into individual parts

                    //<get customer ref number>
                    string[] refComponents = Regex.Split(words[0], ": ");               //split split customer ref num from it's marker text
                    string customerRefString;                                           //intermediate string to represent customer ref num
                    customerRefString = refComponents[1];                               //first word is ALWAYS customer reference number
                    currentCustomer.CustomerRef = Int32.Parse(refComponents[1]);        //turn string into int and apply to current customer reference number
                    //</get customer ref number>

                    match = true;                                                       
                    currentCustomer.Name = words[1];                                    //second word is ALWAYS name

                    //<compose address>
                    if (words[3] == "")//if no line 2 of address address is always words 2, 4 and 5
                    {
                        currentCustomer.Address = words[2] + ", " + words[4] + ", " + words[5];
                    }
                    else //otherwise words 2 to 5 are always the whole address
                    {
                        currentCustomer.Address = words[2] + ", " + words[3] + ", " + words[4] + ", " + words[5];
                    }
                    //</compose address>

                    //<identify bookings linked to customer>
                    for (int i = 6; i < words.Length; i++) //any words after this are booking reference numbers for bookings made by this customer, load them nto memory
                    {
                        string bookingString = words[i];
                        int _bookingRef = Int32.Parse(bookingString); //convert string to int
                        currentCustomer.AddCustBookings(_bookingRef); //load list of booking reference numbers associated with this customer into memory one at a time
                    }
                    //<identify bookings linked to this customer
                }
            }
            if (match == false)
            {
                MessageBox.Show("The customer reference number you entered was not recognised. Go back and sign in.", "User not found.", //show reason for error
                MessageBoxButton.OK, MessageBoxImage.Error); //give it the BONK noise and big fuck-off red X
            }
        }
        //</lookup user and get properties based on user reference number>
    }
}
