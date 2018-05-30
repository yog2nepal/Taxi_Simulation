using Service_ProCp.Models;
using Service_ProCp.Views.Main;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Service_ProCp.Views.ControlStation;

namespace Service_ProCp.BusinessLogic
{
    public class NetworkStation
    {
        #region Private Static Data
        /// <summary>
        /// Counts the totalNumber of Car which had picked passenger
        /// </summary>
        private static int CarCountForAVG = 0;

        /// <summary>
        /// Sum of Total Waiting Time for Passenger for Car to arrive to pick up 
        /// </summary>
        private static TimeSpan SumTotalWaitingTime = TimeSpan.Zero;
        #endregion

        #region Private Fields
        // Mainview instance
        private MainView frm1;
        // Icontrol station instance
        private IControlStation controlStation;
        #endregion

        #region Properties
        /// <summary>
        /// Cars
        /// </summary>
        public List<Car> myCars;
        /// <summary>
        /// Unavailable car list
        /// </summary>
        public List<Car> UnavailableCars;
        /// <summary>
        /// EndHospots
        /// </summary>
        public List<Hotspot> EndHotspots;
        /// <summary>
        /// Hospots
        /// </summary>
        public List<Hotspot> Hotspots;
        /// <summary>
        /// Orders
        /// </summary>
        public List<Order> Orders;
        // Generates random number
        Random rand = new Random();
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor of Network Station
        /// </summary>
        public NetworkStation(MainView Frm1)
        {
            frm1 = Frm1;

            controlStation = frm1.form2;

            this.myCars = new List<Car>();
            this.UnavailableCars = new List<Car>();
            this.Hotspots = new List<Hotspot>();
            this.EndHotspots = new List<Hotspot>();
            this.Orders = new List<Order>();

            //Car Initialisation
            myCars.Add(new Car("BMW", "1234", Properties.Resources.blueCar));
            myCars.Add(new Car("SKODA", "2234", Properties.Resources.greenCar));
            myCars.Add(new Car("TWA", "0012", Properties.Resources.orangeCar));
            myCars.Add(new Car("Toyota", "0312", Properties.Resources.redCar));
            myCars.Add(new Car("AUDI", "4412", Properties.Resources.taxi));
            myCars.Add(new Car("KIA", "1856", Properties.Resources.yellowCar));

            //Starting Hotspots addresses
            Hotspots.Add(new Hotspot("Station", 0, 2));
            Hotspots.Add(new Hotspot("Fontys", 0, 2));
            Hotspots.Add(new Hotspot("Airport", 0, 2));
            Hotspots.Add(new Hotspot("Eindhoven", 0, 2));
            Hotspots.Add(new Hotspot("Rachelsmolen", 0, 0));
            Hotspots.Add(new Hotspot("Breukelaan", 0, 0));
            Hotspots.Add(new Hotspot("Hoofdweg", 0, 0));
            Hotspots.Add(new Hotspot("Boshdijk", 0, 0));
            Hotspots.Add(new Hotspot("Eddiusweg", 0, 0));
            Hotspots.Add(new Hotspot("Prinsengracht", 0, 0));
            Hotspots.Add(new Hotspot("Keizergracht", 0, 0));
            Hotspots.Add(new Hotspot("Johnathstreet", 0, 0));

            //EndHotspots addresses
            EndHotspots.Add(new Hotspot(EndAddressess.Boshdijk.ToString(), 0, 0));
            EndHotspots.Add(new Hotspot(EndAddressess.Breukelaan.ToString(), 0, 0));
            EndHotspots.Add(new Hotspot(EndAddressess.Eddiusweg.ToString(), 0, 0));
            EndHotspots.Add(new Hotspot(EndAddressess.Hoofdweg.ToString(), 0, 0));
            EndHotspots.Add(new Hotspot(EndAddressess.Johnathstreet.ToString(), 0, 0));
            EndHotspots.Add(new Hotspot(EndAddressess.Keizergracht.ToString(), 0, 0));
            EndHotspots.Add(new Hotspot(EndAddressess.Prinsengracht.ToString(), 0, 0));
            EndHotspots.Add(new Hotspot(EndAddressess.Rachelsmolen.ToString(), 0, 0));
        }
        #endregion

        #region Hotspots Public Methods
        /// <summary>
        /// Add a hotspot in the map
        /// </summary>
        /// <param name="hotspot"></param>
        public void AddHotspot(Hotspot hotspot)
        {
            Hotspots.Add(hotspot);
        }

        /// <summary>
        /// Drawing Hotspots
        /// </summary>
        /// <param name="g"></param>
        //public void drawAllHotspots(Graphics g)
        //{
        //    foreach (Hotspot h in Hotspots)
        //    {
        //        h.drawYourSelf(g);
        //        //g.DrawString(h.HotspotName + ", C:" + h.CurrentCapacity.ToString() + "M: " + h.MaxCapacity.ToString(), new Font("Calibri", 9, FontStyle.Regular), Brushes.Black, h.PX + 0, h.PY - 10);
        //    }
        //}

        // Calculating the total max capacity of the hotspot allowed 
        public int calculateTotalMaxCapacity(Hotspot hotspot, int cap)
        {
            int total = 0;
            foreach (Hotspot h in Hotspots)
            {
                if (h == hotspot)
                {
                    total += cap;
                    continue;
                }
                total += h.MaxCapacity;
            }
            return total;
        }

        /// <summary>
        /// Modifies the current capacity of the specific Hotspot(Number of myCars), a Network_Station Class Method
        /// </summary>
        /// <param name="carId"></param>
        public void changeHotspotCapacity(Hotspot hotspot, int capactiy)
        {

            if (hotspot.CurrentCapacity <= capactiy)
            {
                if (calculateTotalMaxCapacity(hotspot, capactiy) >= myCars.Count + UnavailableCars.Count)
                {
                    hotspot.MaxCapacity = capactiy;
                }
                else
                {
                    MessageBox.Show("Total Max Capacity of all hotspots cannot be less than total number of cars");
                }

            }
            else
            {
                MessageBox.Show("Cannot be lower than the Current capacity!");
            }




        }
        #endregion

        #region Finding Hotspot and Removing HotSpot
        /// <summary>
        /// Removes a specific selected hotspot in the map
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool RemoveHotspot(int id)
        {
            foreach (Car c in myCars)
            {
                if (c.CarID == id)
                {
                    //return c;
                }
            }
            //return null;
            Hotspot hotspotToRemove = this.FindHotspot(id);
            if (hotspotToRemove == null)
            { return false; }
            Hotspots.Remove(hotspotToRemove);
            return true;
        }

        /// <summary>
        /// Finds a specific hotspot with id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Hotspot FindHotspot(int id)
        {
            foreach (Hotspot h in Hotspots)
            {
                if (h.hotSpotsID == id)
                {
                    return h;
                }
            }
            return null;
        }


        #endregion

        #region Method for finding cars
        /// <summary>
        /// Finds a specific car with id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Car FindCar(int id)
        {
            foreach (Car c in myCars)
            {
                if (c.CarID == id)
                {
                    return c;
                }
            }
            return null;
        }

        /// <summary>
        /// Gets all cars 
        /// </summary>
        /// <returns></returns>
        public List<Car> getAllCars()
        {
            return this.myCars;
        }

        /// <summary>
        /// Obtains the available free cars not booked
        /// </summary>
        /// <returns></returns>
        public List<Car> GetAvailableCars()
        {
            List<Car> cars = new List<Car>();
            foreach (Car c in myCars)
            {
                if (c.isCarAvailable == true)
                {
                    cars.Add(c);
                }
            }
            return cars;
        }

        /// <summary>
        /// Obtains the Unavailable free cars
        /// </summary>
        /// <returns></returns>
        public List<Car> GetUnAvailableCars()
        {
            return UnavailableCars;
        }

        #endregion

        #region Method Assigning Point to car and Hotspot

        /// <summary>
        /// Assigns a random point to the car on the map
        /// uses the <rect> 
        /// </summary>
        public void assignPointToCars()
        {
            foreach (Hotspot h in Hotspots)
            {
                if (h.HotspotName == "Station")
                {
                    h.PX = 0;
                    h.PY = 0;
                    h.Rect = new Rectangle(h.PX, h.PY, 20, 20);
                }
                else if (h.HotspotName == "Airport")
                {
                    h.PX = 0;
                    h.PY = 364;
                    h.Rect = new Rectangle(h.PX, h.PY, 20, 20);
                }
                else if (h.HotspotName == "Fontys")
                {
                    h.PX = 783;
                    h.PY = 0;
                    h.Rect = new Rectangle(h.PX, h.PY, 20, 20);
                }
                else if (h.HotspotName == "Eindhoven")
                {
                    h.PX = 783;
                    h.PY = 364;
                    h.Rect = new Rectangle(h.PX, h.PY, 20, 20);
                }
                else if (h.HotspotName == "Rachelsmolen")
                {
                    h.PX = 261;
                    h.PY = 182;
                    h.Rect = new Rectangle(h.PX, h.PY, 20, 20);
                }
                else if (h.HotspotName == "Breukelaan")
                {
                    h.PX = 522;
                    h.PY = 273;
                    h.Rect = new Rectangle(h.PX, h.PY, 20, 20);
                }
                else if (h.HotspotName == "Hoofdweg")
                {
                    h.PX = 522;
                    h.PY = 91;
                    h.Rect = new Rectangle(h.PX, h.PY, 20, 20);
                }
                else if (h.HotspotName == "Boshdijk")
                {
                    h.PX = 522;
                    h.PY = 364;
                    h.Rect = new Rectangle(h.PX, h.PY, 20, 20);
                }
                else if (h.HotspotName == "Eddiusweg")
                {
                    h.PX = 522;
                    h.PY = 182;
                    h.Rect = new Rectangle(h.PX, h.PY, 20, 20);
                }
                else if (h.HotspotName == "Prinsengracht")
                {
                    h.PX = 783;
                    h.PY = 91;
                    h.Rect = new Rectangle(h.PX, h.PY, 20, 20);
                }
                else if (h.HotspotName == "Keizergracht")
                {
                    h.PX = 783;
                    h.PY = 182;
                    h.Rect = new Rectangle(h.PX, h.PY, 20, 20);
                }
                else if (h.HotspotName == "Johnathstreet")
                {
                    h.PX = 783;
                    h.PY = 273;
                    h.Rect = new Rectangle(h.PX, h.PY, 20, 20);
                }
            }

            foreach (Hotspot h in EndHotspots)
            {
                if (h.HotspotName == EndAddressess.Boshdijk.ToString())
                {
                    h.PX = 421;
                    h.PY = 364;
                }
                else if (h.HotspotName == EndAddressess.Breukelaan.ToString())
                {
                    h.PX = 421;
                    h.PY = 273;
                }
                else if (h.HotspotName == EndAddressess.Eddiusweg.ToString())
                {
                    h.PX = 421;
                    h.PY = 182;
                }
                else if (h.HotspotName == EndAddressess.Hoofdweg.ToString())
                {
                    h.PX = 421;
                    h.PY = 91;
                }
                else if (h.HotspotName == EndAddressess.Johnathstreet.ToString())
                {
                    h.PX = 682;
                    h.PY = 273;
                }
                else if (h.HotspotName == EndAddressess.Keizergracht.ToString())
                {
                    h.PX = 682;
                    h.PY = 182;
                }
                else if (h.HotspotName == EndAddressess.Prinsengracht.ToString())
                {
                    h.PX = 682;
                    h.PY = 91;
                }
                else if (h.HotspotName == EndAddressess.Rachelsmolen.ToString())
                {
                    h.PX = 160;
                    h.PY = 182;
                }
            }

            for (int i = 0; i < myCars.Count; i++)
            {
                Car c = myCars[i];
                //c.DepartureHotspot = Hotspots[i];
                //c.DestinationHotspot = EndHotspots[i];
                //Point[] cRoadPoints = null;

                //get a random hotspot from the list, make the car position the same as this hotspot
                Hotspot htspot = Hotspots[rand.Next(0, Hotspots.Count)];
                c.DepartureHotspot = htspot;
                c.PX = htspot.PX;
                c.PY = htspot.PY;
                c.DepartureHotspot.CurrentCapacity++;
                while(c.DepartureHotspot.CurrentCapacity > c.DepartureHotspot.MaxCapacity)
                {
                    c.DepartureHotspot.CurrentCapacity--;
                    c.DepartureHotspot = Hotspots[rand.Next(0, Hotspots.Count)];
                    c.PX = c.DepartureHotspot.PX;
                    c.PY = c.DepartureHotspot.PY;
                    c.DepartureHotspot.CurrentCapacity++;
                }
                Hotspot htspotEnd = EndHotspots[rand.Next(0, EndHotspots.Count)];
                while (htspotEnd == htspot)
                {
                    htspotEnd = EndHotspots[rand.Next(0, EndHotspots.Count)];
                }
                c.DestinationHotspot = htspotEnd;
                c.AlgorithmToDestination();
            }
        }

        #endregion

        #region Method for Car Movement
        /// <summary>
        /// Moving a car around
        /// </summary>
        public void MoveCars()
        {
            int count = 0;

            List<Car> tempCar = new List<Car>();
            foreach (Car car in UnavailableCars)
            {

                /// code for realtime update
                if (car.picked == true && car.isPassengerPicked == Status.IdleAtHotSpot)
                {
                    car.DepartTimetoPickPassenger = DateTime.Now;
                    String[] info = new String[5] { car.CarType.ToString(), car.DepartTimetoPickPassenger.ToLongTimeString().ToString(), string.Empty, string.Empty, string.Empty };
                    controlStation.UpdateListBoxViewRealTimeMinutes(info);
                    car.isPassengerPicked = Status.GoingToPickPassenger;
                }
                car.Move(EndHotspots, Hotspots);
                /* Code to update Real Time Listbox */

                if (car.isPassengerPicked == Status.PickedPassenger && car.infoUpdated == false )
                {

                    /* code to find out the ListViewSelected Items and Update it with the pickUp Time **/
                    int index = controlStation.FindListViewItemToEdit(car.CarType);
                    DateTime tempTimeforPickUp = DateTime.Now;
                    controlStation.EditListViewItem(index, tempTimeforPickUp.ToLongTimeString().ToString().ToString());
                    /* code to calulate average Waiting Time */
                    TimeSpan TempSumTotalWaitingTime = (tempTimeforPickUp - car.DepartTimetoPickPassenger);

                    CarCountForAVG++;
                    SumTotalWaitingTime += TempSumTotalWaitingTime;
                    double avgTime = Convert.ToDouble(Convert.ToDouble(SumTotalWaitingTime.TotalSeconds) / CarCountForAVG);
                    controlStation.AverageWaitingTime(avgTime);

                    Orders[Orders.Count - (UnavailableCars.Count - count)].DestinationAddress = car.DestinationHotspot.HotspotName;
                    frm1.UpdateStatistics();
                    car.infoUpdated = true;
                }
                if (car.isPassengerPicked == Status.DroppedPassenger && car.IsGoingBack == true && car.infoUpdated == true)
                {

                    int index = controlStation.FindListViewItemToEdit(car.CarType);
                    controlStation.EditListViewItem(index, DateTime.Now.ToLongTimeString().ToString().ToString());
                    car.isCarAvailable = false;
                }
                if (car.isCarAvailable == true)
                {
                    tempCar.Add(car);
                }

                count++;
            }
            if (tempCar.Count > 0)
            {
                foreach (Car c in tempCar)
                {

                    c.DestinationHotspot = EndHotspots[rand.Next(0, EndHotspots.Count)];

                    while (c.DestinationHotspot == c.DepartureHotspot)
                    {
                        c.DestinationHotspot = EndHotspots[rand.Next(0, EndHotspots.Count)];
                    }
                    c.AlgorithmToDestination();

                    UnavailableCars.Remove(c);
                    c.infoUpdated = false;
                    myCars.Add(c);
                }
                frm1.UpdateCar();
            }
        }
    
        #endregion

        #region Methiod Cancel Order Taxi
        /// <summary>
        /// Cancels the taxi order for a specific car with id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool CancelTaxiOrder(int id)
        {
            Car carToRemove = this.FindCar(id);
            if (carToRemove == null)
            { return false; }
            myCars.Remove(carToRemove);
            return true;
        }
        #endregion

        #region Method Making an Order and Assigning Order
        /// <summary>
        /// Makes an order
        /// </summary>
        public void MakeOrder(Car driver)
        {
            if (driver != null)
            {
                this.Orders.Add(new Order(driver));
            }
            else
            {
                MessageBox.Show("No available cars at the moment.");
            }
        }

        /// <summary>
        /// Assigns a random car to an order
        /// </summary> TODO
        /// <returns></returns>
        public Car AssignCarToOrder()
        //public Car AssignCarToOrder(Car Cid, Order orID)
        {
            Car car = null;
            if (myCars.Count != 0)
            {
                int index = rand.Next(0, myCars.Count);
                car = myCars[index];
                car.DepartureHotspot.CurrentCapacity--;
                car.isCarAvailable = false;
                car.isPassengerPicked = Status.IdleAtHotSpot;
                UnavailableCars.Add(car);
                myCars.Remove(car);

            }
            return car;
        }
        #endregion
    }
}
