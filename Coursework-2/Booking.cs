using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Coursework_2
{
    public class Booking
    {
        //handles each booking
        //every booking must have a customer, every booking can have between 0 and 4 guests

        //<basic package variables>
        private DateTime arrivalDate;                           //delcare the variable used to store the date the booking starts
        private DateTime departureDate;                         //the date the booking ends
        private int bookingRef;                                 //uniquie number associated with only this booking
        private List<Guest> guestList = new List<Guest> { };    //empty list to which guests will be added if added
                                                                //</basic package variables>

        //<optional extras>
        private string diet;
        private bool breakfast;
        private bool meals;                                     //the dietary requirements associated with breakfast and/or evening meals - must be present if meals or breakfast are requested
        private bool carHire;
        private string driverName;
        private DateTime hireStart;
        private DateTime hireEnd;
        //</optional extras>

        public DateTime ArrivalDate     //accessor to get/set start date of the booking
        {
            get { return arrivalDate; }
            set { arrivalDate = value; }
        }

        public DateTime DepartureDate   //accessor for end date of the booking
        {
            get { return departureDate; }
            set { departureDate = value; }
        }

        public int BookingRef //accessor to assing or retrieve unique id number for the booking
        {
            get { return bookingRef; }
            set { bookingRef = value; }
        }

        public List<Guest> GuestList //accessor to retrieve list of guests
        {
            get { return guestList; }
        }

        public bool Breakfast //accessor to assing or retrieve unique id number for the booking
        {
            get { return breakfast; }
            set { breakfast = value; }
        }

        public bool Meals //accessor for meals boolean
        {
            get { return meals; }
            set { meals = value; }
        }
        
        public string Diet //accessor for string holding dietary requirements
        {
            get { return diet; }
            set { diet = value; }
        }
        public string DriverName
        {
            get { return driverName; }
            set { driverName = value; }
        }

        public bool CarHire //accessor for carHire boolean
        {
            get { return carHire; }
            set { carHire = value; }
        }

        public DateTime HireStart
        {
            get { return hireStart; }
            set { hireStart = value; }
        }

        public DateTime HireEnd
        {
            get { return hireEnd; }
            set { hireEnd = value; }
        }


        //add guest objects to a list up to a maximum of 4
        public void AddToList(Guest guest)
        {
            if (guestList.Count < 4) //execute if there are less than 4 guests on this booking
            {
                guestList.Add(guest);
            }
            else //error, only 4 or less allowed
            {
                MessageBox.Show("Max number of guests reached.", "No more guests.", //show reason for error
                    MessageBoxButton.OK, MessageBoxImage.Error); //give it the bonk noise and big fuck-off red X
            }
        }
    }
}
