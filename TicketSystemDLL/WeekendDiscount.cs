using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketClass1;

namespace StoreBaeltTicketLibrary
{
    /// <summary>
    /// The class WeekendDiscount contains a constructor, discount and weekend methods 
    /// </summary>
    public class WeekendDiscount
    {

        /// <summary>
        /// The constructor create object without any parameters
        /// </summary>
        public WeekendDiscount()
        {

        }

        /// <summary>
        /// Create discount20 method by using int
        /// </summary>
        /// <returns>20</returns>
        public int Discount20()
        {
            return 20;
        }
        /// <summary>
        /// Create weekend methods by using string 
        /// </summary>
        /// <returns>Only Saturday or Sunday</returns>
        public string Weekend()
        {
            return "Only Saturday or Sunday";
        }

    }


}
