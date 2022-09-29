using System.Reflection.Metadata.Ecma335;

namespace MCLibrary
{
    public class MC
    {
        /// <summary>
        /// Create properties "Licenseplate and "Date", by get and set into class car
        /// </summary>

        public string LincensePlate { get; set; }
        public DateTime Date { get; set; }


        /// <summary>
        /// Creating static price method, by using double. We use static method, because we don´t have to imp arrange in unit test 
        /// </summary>
        /// <returns>Return 125</returns>
        public static double Price()
        {
            return 125;
        }

        /// <summary>
        /// Creating static method of vehicle, by using string.
        /// </summary>
        /// <returns>Return MC</returns>
        public static string Vehicle()
        {
            return "MC";
        }

    }
}