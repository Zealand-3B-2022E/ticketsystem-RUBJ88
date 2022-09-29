using System.Reflection.Metadata.Ecma335;

namespace CarLbrary
{
    public class Car
    {
        /// <summary>
        /// Create properties "Licenseplate and "Date", by get and set into class car
        /// </summary>
        public string Licenseplate { get; set; }
        public DateTime Date { get; set; }


        
        /// <summary>
        /// Create price method by us of int in the class car
        /// </summary>
        /// <returns>return 240</returns>

        public int Price()
        {
            return 240;
        }

        /// <summary>
        /// Create vehicleType method by use of string in the class Car
        /// </summary>
        /// <returns>"car"</returns>
        public string VehicleType()
        {
            return "Car";
        }
    }


}