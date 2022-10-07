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
        private double _Date;
        private int _discount;
        

        /// <summary>
        /// The property is create discount by use get and set in the system 
        /// </summary>
        public int Discount { get; set; }


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
            
        }

        /// <summary>
        /// Property is creating protected licensplate by get and set. 
        /// </summary>

        public string Licensplate { get; private set; }


        /// <summary>
        /// Property is creating protected Date by get and set. 
        /// </summary>
        protected DateTime Date { get; private set; }


        /// <summary>
        /// Creating price method by using virtual double
        /// </summary>
        /// <returns>Return 5 - Discount</returns>
        public virtual double Price()
        {
            return 5 - Discount;
        }


        /// <summary>
        /// Creating Plate method by using abstract string
        /// </summary>
        /// <returns>Empty</returns>
        public abstract string Plate();

        /// <summary>
        /// Creating vehicle method by using abstract string 
        /// </summary>
        /// <returns>Empty</returns>
        public abstract string Vehicle();

        /// <summary>
        /// Creating VehicleType by using abstract string
        /// </summary>
        /// <returns>Empty</returns>
        public abstract string VehicleType();


        /// <summary>
        /// Creating Brobizz method by using abstract int
        /// </summary>
        /// <returns>Empty</returns>
        public abstract int Brobizz();


        /// <summary>
        /// The constructor create objects - this constructor is protected and have no parameters 
        /// </summary>
        protected Ticket()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="licenseplate"></param>
        /// <param name="date"></param>
        protected Ticket(string licenseplate, DateTime date)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Item: \t\t{this.Vehicle()} \nVehicle: \t{this.VehicleType()} \nVehicle: \t\t{this.Price()}\nPrice: \t\t,- \nBrobizz: \t\t{this.Brobizz()}ml";

        }

        

    }
}

