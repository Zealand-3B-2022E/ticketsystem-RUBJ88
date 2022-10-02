using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarLbrary;

namespace TicketClass1
{
    /// <summary>
    ///  The class Ticket is abstract, which means the class only have methods without body.
    /// In other words the abstract class is not really finished.
    /// The class Ticket inheritance to class car and class MC
    /// The class Ticked, filed, protected properties, protected constructors, abstracted methods and override ToString method.
    /// All contains in the class Ticked is inheritance to Car and MC classes. 
    /// </summary>

    public abstract class Ticket
    {
        /// <summary>
        /// The files saving the values og licensPlate, date, discount and mTicket in the system
        /// </summary>
        private string _licensplate;
        private DateTime _Date;
        private int _discount;
        private int _mTicket;

        /// <summary>
        /// The property is create discount by use get and set in the system 
        /// </summary>
        protected int Discount { get; private set; }


        /// <summary>
        /// Property is creating a test research og discount
        /// </summary>
        /// <param name="discount"> is set to 5</param>
        /// <exception cref="ArgumentException">Must be 5%</exception>
        protected Ticket(int discount)
        {
            if (discount > 5)
            {
                throw new ArgumentException("Must be 5%");
            }
            _discount = discount;
        }

        /// <summary>
        /// The constructor create objects discount and ticket in class ticket
        /// </summary>
        /// <param name="discount"></param>
        /// <param name="ticket"></param>
        protected Ticket(int discount, int ticket)
        {
            _discount = discount;
            _mTicket = MTicket();
        }

        public virtual double Price()
        {
            return 5 - Discount;
        }

        public abstract string Plate();

        public abstract string Vehicle();
        public abstract string VehicleType();

        public abstract int MTicket();

        protected Ticket()
        {

        }
        protected Ticket(string licenseplate, DateTime date)
        {

        }

        public override string ToString()
        {
            return $"Item: \t\t{this.Vehicle()} \nVehicle: \t{this.VehicleType()} \nVehicle: \t\t{this.Price()}\nPrice: \t\t,- \nMTicket: \t\t{this.MTicket()}ml";

        }

        

    }
}

