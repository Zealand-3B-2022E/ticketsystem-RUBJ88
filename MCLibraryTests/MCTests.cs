using Microsoft.VisualStudio.TestTools.UnitTesting;
using MCLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCLibrary.Tests
{
    [TestClass()]
    public class MCTests
    {
        
        /// <summary>
        /// Testing method car price with equal 240
        /// </summary>
        /// <param name="value">accepted value is 240</param>

        [DataTestMethod]
        [DataRow(125)]
        [TestMethod]
        public void MC_Price_Equal_125(int value)
        {
            // Arrange
            var mc = new MC();
            // Act
            int price = MC.Price();
            
            // Assert
            Assert.AreEqual(value, price);
        }

        /// <summary>
        /// Testing method VeicleType
        /// </summary>
        /// <param name="value">accepted value is car</param>

        [DataTestMethod]
        [DataRow("MC")]
        [TestMethod]
        public void Vehicle(string value)
        {
            // Arrange
            var mc = new MC();
            // Act
            string vehicle = MC.Vehicle();
            // Assert
            Assert.AreEqual(value, vehicle);
        }


    }
}