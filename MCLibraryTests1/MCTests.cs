using Microsoft.VisualStudio.TestTools.UnitTesting;
using MCLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace MCLibrary.Tests
{
    [TestClass()]
    public class MCTests
    {

        /// <summary>
        /// Testing static method Price equal 125 -> in this case we don´t need to imp arrange, because we used static method in MC class,
        /// In other words we don´t need to create new object in arrange
        /// </summary>
        /// <param name="value">accepted value is 125</param>
        [DataTestMethod]
        [DataRow(125)]
        [TestMethod]
        public void PriceTest(double value)
        {
            // Arrange -> empty
            

            // Act
             double price = MC.Price();

             // Assert
             Assert.AreEqual(value, price);
        }

        /// <summary>
        /// Testing static method vehicle -> In the same way we don´t need to imp arrange, because we used static method in MC class,
        /// In other words we don´t need to create new object
        /// </summary>
        /// <param name="value">accepted value is MC</param>
        [DataTestMethod]
        [DataRow("MC")]
        [TestMethod]
        public void VehicleTest(string value)
        {
            //Arrange -> empty 

            //Act
            string mc = MC.Price();

            // Assert
            Assert.AreEqual(value, mc);
        }
    }
}