using Microsoft.VisualStudio.TestTools.UnitTesting;
using StoreBeltBroen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreBeltBroen.Tests
{
    /// <summary>
    /// The Unit Test for weekendDiscount contains following test: weekend 20 percent discount and weekend days "saturday and sunday 
    /// </summary>
    [TestClass()]
    public class WeekendDiscountTests
    {


            /// <summary>
            /// Test method weekend 20 percent discount 
            /// </summary>
            /// <param name="price">Equal correct value 20 percent</param>

            [DataTestMethod]
            [DataRow(20)]
            [TestMethod]
            public void Weekend_20_Percent_Discount(int price)
            {
                var car = new WeekendDiscount();

                double result = car.BrobizzDiscount();

                Assert.AreEqual(price, result);
            }
            /// <summary>
            /// Test method weekend
            /// </summary>
            /// <param name="weekend">Equal the correct days "saturday and sunday</param>
            [DataTestMethod]
            [DataRow("Only Saturday or Sunday")]
            [TestMethod]
            public void Weekend(string weekend)
            {
                // Arrange
                var car = new WeekendDiscount();
                // Act
                string result = car.BrorizzDay();
                // Assert
                Assert.AreEqual(weekend, result);
            }

        }
    }
