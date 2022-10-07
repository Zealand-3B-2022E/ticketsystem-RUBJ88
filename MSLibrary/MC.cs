using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using TicketClass1;

namespace MCLibrary
{
    /// <summary>
    /// The class MC is inheritance from Ticket class, and the class contains base constructors og licensplate,date and discount.
    /// The class MC contains also override methods of price, plate, vehicle, vehicle type and MTicket
    ///  Furthermore the class Ticket contains override methods of price plate, vehicle, vehicle type and MTicket 
    /// </summary>

    public class MC : Ticket
    {

        private string _licensplate;

        private DateTime _date;


        /// <summary>
        /// The constructor is them there create an object, and base is used to access members of the base class from within a derived class. 
        /// </summary>
        public MC() : base()
        {
            _licensplate = Licensplate;
            _date = Date;

        }
        /// <summary>
        /// This base constructor create object with parameters of licensplate and date
        /// </summary>
        /// <param name="licensesplate">The parameter of licenseplate is a string</param>
        /// <param name="date">The parameter of date is a DateTime</param>
        public MC(string licensesplate, DateTime date) : base(licensesplate, date)
        {

        }

        /// <summary>
        /// This base constructor create object with parameter of discount 
        /// </summary>
        /// <param name="discount">parameters of discount is int</param>
        public MC(int discount) : base(discount)
        {

        }

        public string Licensplate
        {
            get => _licensplate;
            set => _licensplate = value;
        }

        public DateTime Date
        {
            get => _date;
            set => _date = value;
        }

        /// <summary>
        /// Creating override method of price, by using double. 
        /// </summary>
        /// <returns>Return 125</returns>
        public override double Price()
        {
            return 125;
        }

        /// <summary>
        /// Creating override method by using string of
        /// </summary>
        /// <returns>return 7 char</returns>
        public override string Plate()
        {
            return "1234567";
        }

        /// <summary>
        /// Creating override method of vehicle, by using string.
        /// </summary>
        /// <returns>Return MC</returns>
        public override string Vehicle()
        {
            return "MC";
        }

        /// <summary>
        /// Creating override method of vehicleType, by using string.
        /// </summary>
        /// <returns>Return Car</returns>
        public override string VehicleType()
        {
            return "Car";
        }
        /// <summary>
        /// Creating override method of Brobizz, by using int.
        /// </summary>
        /// <returns>Return Return 0</returns>
        public override int Brobizz()
        {
            return 0;
        }




    }


}