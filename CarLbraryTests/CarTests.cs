
using CarLbrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TicketClass1;
using Newtonsoft.Json.Linq;

namespace CarLbrary.Tests
{
    /// <summary>
    /// The Unit Test of class ´Car contains test of price, Vehicle Type,Vehicle and Ticket of 5 percent smaller than 125
    /// The last test is about Licensplate should not be longer than 7 char long
    /// </summary>



    [TestClass()]
    public class CarTests
    {

        /// <summary>
        /// Testing method car price with equal 240
        /// </summary>
        /// <param name="value">accepted value is 240</param>
        [DataTestMethod]
        [DataRow(240)]
        [TestMethod]
        public void Car_Price_Equal_240(double value)
        {
            //Arrange
            var car = new Car();

            //Act
            double price = car.Price();

            Assert.AreEqual(value, price);
        }

        /// <summary>
        /// Testing method Vehicle
        /// </summary>
        /// <param name="value">Equal the correct Vehicle "MC"</param>
        [DataTestMethod]
        [DataRow("MC")]
        [TestMethod]
        public void Vehicle(string value)
        {
            // Arrange
            var car = new Car();
            // Act
            string vehicle = car.Vehicle();
            // Assert
            Assert.AreEqual(value, vehicle);
        }

        /// <summary>
        /// Testing the method Vehicle Type
        /// </summary>
        /// <returns>Equal the correct Vehicle Type "Car"</returns>
        [DataTestMethod]
        [DataRow("Car")]
        [TestMethod]
        public void Vehicle_Type(string value)
        {
            // Arrange
            var car = new Car();
            // Act
            string vehicle = car.VehicleType();
            // Assert
            Assert.AreEqual(value, vehicle);
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
            var mc = new Car(value);
            // Act
            double price = mc.Price();
            // Assert

            Assert.AreEqual(5, price);
        }
        /// <summary>
        /// Testing property licensplate -> no longer than 7 chr long 
        /// </summary>
        /// <param name="plate">Accepted char is 7</param>
        [DataTestMethod]
        [DataRow("1234567")]
        [TestMethod]
        public void Licensplate_should_Be_Not_Longer_Than_7_char_Long(string plate)
        {
            // Arrange
            var car = new Car();
            // Act
            string result = car.Plate();
            // Assert
            Assert.AreEqual(plate, result);
        }

    }
}










