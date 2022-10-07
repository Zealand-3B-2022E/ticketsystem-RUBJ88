using CarLbrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OresundsBroenibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OresundsBroenibrary.Tests
{
    [TestClass()]
    public class OresundBroTests
    {

        [DataTestMethod]
        [DataRow(420)]
        [TestMethod]
        public void Car_Price_Oresund_Bro_Equal_420(double value)
        {
            //Arrange
            var ob = new OresundBro();

            //Act
            double price = ob.CarPrice();

            Assert.AreEqual(value, price);
        }

        [DataTestMethod]
        [DataRow(210)]
        [TestMethod]
        public void MC_Price_Oresund_Bro_Equal_210(double value)
        {
            //Arrange
            var ob = new OresundBro();

            //Act
            double price = ob.MCPrice();

            Assert.AreEqual(value, price);

        }
        [DataTestMethod]
        [DataRow(161)]
        [TestMethod]
        public void BrobizzCar_Price_Oresund_Bro_Equal_161 (double value)
        {
            //Arrange
            var ob = new OresundBro();

            //Act
            double price = ob.BrobizzCar();

            Assert.AreEqual(value, price);

        }

        [DataTestMethod]
        [DataRow(73)]
        [TestMethod]
        public void BrobizzMC_Price_Oresund_Bro_Equal_73(double value)
        {
            //Arrange
            var ob = new OresundBro();

            //Act
            double price = ob.BrobizzMC();

            Assert.AreEqual(value, price);

        }

        [DataTestMethod]
        [DataRow("Oresund Car")]
        [TestMethod]
        public void VehicleType_Oresund_Bro_Car(string oredundBro)
        {
            //Arrange
            var ob = new OresundBro();

            //Act
            string vehicleType = ob.VehicleType();

            Assert.AreEqual(vehicleType, oredundBro);

        }

        [DataTestMethod]
        [DataRow("Oresund MC")]
        [TestMethod]
        public void VehicleType_Oresund_Bro_MC (string oredundBro)
        {
            //Arrange
            var ob = new OresundBro();

            //Act
            string vehicle = ob.Vehicle();

            Assert.AreEqual(vehicle, oredundBro);

        }


    }
}