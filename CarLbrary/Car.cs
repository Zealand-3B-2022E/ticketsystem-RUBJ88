using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketClass1;

namespace CarLbrary
{
    /// <summary>
    /// The class Car is inheritance from Ticket class, and the class contains filed and constructor of licensplate, base constructor of discount.
    ///  Furthermore the class Ticket contains override methods of price plate, vehicle, vehicle type and MTicket 
    /// </summary>
    public class Car : Ticket
    {
        /// <summary>
        /// The files saving the values og liceseplate in the class Car
        /// </summary>
        private string _licensplate;

        /// <summary>
        /// The constructor is them there create an object, and base is used to access members of the base class from within a derived class. 
        /// </summary>
        public Car() : base()
        {
            _licensplate = Licenseplate;
        }

        /// <summary>
        /// This base constructor create object with parameters
        /// </summary>
        /// <param name="discount">The parameter is discount</param>
        public Car(int discount) : base(discount)
        {

        }

        /// <summary>
        /// Create price method by using override double in the class car
        /// </summary>
        /// <returns>return 240</returns>
        public override double Price()
        {
            return 240;
        }

        /// <summary>
        /// Create plate method by using override string in the class car
        /// </summary>
        /// <returns>returning 1234567</returns>
        public override string Plate()
        {
            return "1234567";
        }

        /// <summary>
        /// Create Vehicle method by using override string in the class car
        /// </summary>
        /// <returns>MC</returns>
        public override string Vehicle()
        {
            return "MC";
        }

        /// <summary>
        /// Create vehicleType method by use of string in the Car class
        /// </summary>
        /// <returns>"car"</returns>
        public override string VehicleType()
        {
            return "Car";
        }

        /// <summary>
        /// Create MTicket method by using override int in the Car class
        /// </summary>
        /// <returns>Return 5</returns>
        public override int MTicket()
        {
            return 0;
        }

        public string Licenseplate
        {
            get => _licensplate;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("License plate must not be longer than 7 characters");

                }

                if (value.Length < 7)
                {
                    throw new ArgumentException("License plate must not be longer than 7 characters");
                }

                _licensplate = value;
            }
        }

















        public int ITicket()
        {
            return 0;
        }
    }
}

