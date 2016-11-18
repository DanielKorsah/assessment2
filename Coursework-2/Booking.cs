using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework_2
{
    class Booking
    {
        //handles each booking
        //every booking must have a customer, every booking can have between 0 and 4 guests

        //<basic package variables>
        private DateTime arrivalDate; //delcare the variable used to store the date the booking starts
        private DateTime departureDate; //the date the booking ends
        private int bookingRef; //uniquie number associated with only this booking
        private List<Guest> guests = new List<Guest> { }; //empty list to which guests will be added if added
        //</basic package variables>

        //<optional extras>

        //</optional extras>
    
    }
}
