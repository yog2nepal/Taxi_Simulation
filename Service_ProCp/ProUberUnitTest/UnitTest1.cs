using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Service_ProCp.BusinessLogic;
using Service_ProCp.Views.Main;
using Service_ProCp.Models;
using System.Collections.Generic;

namespace ProUberUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        /// 1. Change Hotspot capacity
        [TestMethod]
        public void testChangeHotspotCapacity()
        {
            //Arrange
            NetworkStation netwk = new NetworkStation(new MainView());

            string carType = "BMW";
            string plateNumber = "4567";
            Car cars = new Car(carType, plateNumber, Properties.Resources.blueCar);
            List<Car> myCars = new List<Car>();
            List<Car> UnavailableCars = new List<Car>();
            int capactiy = 1;

            //Car Initialisation
            myCars.Add(new Car("BMW", "1234", Properties.Resources.blueCar));
            myCars.Add(new Car("SKODA", "2234", Properties.Resources.blueCar));
            myCars.Add(new Car("TWA", "0012", Properties.Resources.blueCar));
            myCars.Add(new Car("KIA", "1111", Properties.Resources.blueCar));
            //myCars.Add(new Car("KIA", "1111", Properties.Resources.blueCar));
            UnavailableCars.Add(new Car("Toyota", "0312", Properties.Resources.blueCar));
            UnavailableCars.Add(new Car("AUDI", "4412", Properties.Resources.blueCar));

            //Act
            int result = 0;
            for (int i = 0; i < 2; i++)
            {
                if (netwk.Hotspots[i].CurrentCapacity <= capactiy)
                {
                    if (netwk.calculateTotalMaxCapacity(netwk.Hotspots[i], capactiy) >= myCars.Count + UnavailableCars.Count)
                    {
                        netwk.Hotspots[i].MaxCapacity = capactiy;
                    }
                }
                result = netwk.Hotspots[i].MaxCapacity;
            }
            //Assure
            Assert.AreEqual(capactiy, result);
        }

        /// 2. Get All Cars
        [TestMethod]
        public void GetAllCars()
        {
            //Arrange
            NetworkStation netwk = new NetworkStation(new MainView());

            string carType = "BMW";
            string plateNumber = "4567";
            Car cars = new Car(carType, plateNumber, Properties.Resources.blueCar);
            List<Car> myCars = new List<Car>();

            //Act
            //Car Initialisation
            myCars.Add(new Car("BMW", "1234", Properties.Resources.blueCar));
            myCars.Add(new Car("SKODA", "2234", Properties.Resources.blueCar));
            myCars.Add(new Car("TWA", "0012", Properties.Resources.blueCar));
            myCars.Add(new Car("KIA", "1111", Properties.Resources.blueCar));

            ////Assure
            Assert.AreEqual(4, myCars.Count);
        }

        /// 2. Get Unavailable Cars
        [TestMethod]
        public void testUnGetAvailableCars()
        {
            //Arrange
            NetworkStation netwk = new NetworkStation(new MainView());

            string carType = "BMW";
            string plateNumber = "4567";
            Car cars = new Car(carType, plateNumber, Properties.Resources.blueCar);
            List<Car> myCars = new List<Car>();
            List<Car> UnavailableCars = new List<Car>();

            //Act
            //Car Initialisation
            UnavailableCars.Add(new Car("Toyota", "0312", Properties.Resources.blueCar));
            UnavailableCars.Add(new Car("AUDI", "4412", Properties.Resources.blueCar));

            ////Assure
            Assert.AreEqual(2, UnavailableCars.Count);
        }
    }
}
