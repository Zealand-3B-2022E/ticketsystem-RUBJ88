using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarLbrary;

namespace TicketClass
{
    public abstract class TicketClass
    {
        private string _licensplate;
        private DateTime _Date;

        protected TicketClass()
        {

        }

        public string Licenseplate { get; set; }
        public DateTime Date { get; set; }

        protected TicketClass(string licenseplate, DateTime date)
        {
            Licenseplate = licenseplate;
            Date = date;
        }

        public virtual int Price1()
        {
            return 125;
            
        }

        public virtual double Price2()
        {
            return 240;
        }

        public abstract string Vehicle();


        public override string ToString()
        {
            return $"Item: \t\t{this.Vehicle()} \nVehicle: \t{this.Vehicle()} \nPrice: \t\t{this.Price1()},- \nPrice2: \t\t{this.Price2()}";
        }
    }
}
