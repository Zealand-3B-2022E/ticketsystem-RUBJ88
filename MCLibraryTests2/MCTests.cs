using Microsoft.VisualStudio.TestTools.UnitTesting;
using MCLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TicketClass1;
using CarLbrary;

namespace MCLibrary.Tests
{
    /// <summary>
    /// The Unit Test of class MC contains test of price, Vehicle Type,Vehicle and Ticket of 5 percent smaller than 125
    /// The last test is about Licensplate should not be longer than 7 char long
    /// </summary>
    [TestClass()]
    public class MCTests
    {

        /// <summary>
        /// Testing price method with 125
        /// </summary>
        /// <param name="price">Equal the correct number of 125</param>
        [DataTestMethod]
        [DataRow(125)]
        [TestMethod]
        public void Price_125(double price)
        {
            var mc = new MC();

            double result = mc.Price();

            Assert.AreEqual(price, result);
        }

        /// <summary>
        /// Testing method vehicle type with "car"
        /// </summary>
        /// <param name="vehicle">Equal the correct vehicle type "car"</param>
        [DataTestMethod]
        [DataRow("Car")]
        [TestMethod()]
        public void Vehicle_Type(string vehicle)
        {
            var mc = new MC();
            string result = mc.VehicleType();
            Assert.AreEqual(vehicle, result);
        }
        /// <summary>
        /// Testing method vehicle with "MC" 
        /// </summary>
        /// <param name="vehicle">Equal the correct vehicle "MC"</param>
        [DataTestMethod]
        [DataRow("MC")]
        [TestMethod()]
        public void Vehicle(string vehicle)
        {
            var mc = new MC();
            string result = mc.Vehicle();
            Assert.AreEqual(vehicle, result);
        }

        /// <summary>
        /// Testing the discount property of 20, 15 and 10
        /// </summary>
        /// <param name="value">Equal values 5</param>

        [DataRow(20)]
        [DataRow(15)]
        [DataRow(10)]
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Ticket_Of_5_Percent_Smaller_Than_125(int value)
        {
            // Arrange
            var mc = new MC(value);
            // Act
            double price = mc.Price();
            // Assert

            Assert.AreEqual(5, price);
        }

        /// <summary>
        /// Testing method Plate with longer than 7 chr long
        /// </summary>
        /// <param name="plate">Equal the correct chr.</param>
        [DataTestMethod]
        [DataRow("1234567")]
        [TestMethod()]
        public void Licensplate_should_Not_Be_Longer_Than_7_char_Long(string plate)
        {
            var mc = new MC();
            string result = mc.Plate();
            Assert.AreEqual(plate, result);
        }



    }
}