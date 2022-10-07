using System.Runtime.CompilerServices;
using OresundsBro;

namespace OresundbroenTest
{
    [TestClass]
    public class OresundsbroenTest
    {

        
        [TestMethod]
        public void TestMethod1()
        {
        }

        

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
            var ob = new OresundsBro()

            //Act
            double price = car.();

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

    }
}