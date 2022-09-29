using Microsoft.VisualStudio.TestTools.UnitTesting;
using CarLbrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarLbrary.Tests
{
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
        public void Car_Price_Equal_240(int value)
        {
            // Arrange
            var car = new Car();
            // Act
            int price = car.Price();
            // Assert
            Assert.AreEqual(value, price);
        }

        /// <summary>
        /// Testing method VeicleType
        /// </summary>
        /// <param name="value">accepted value is car</param>

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


    }
}