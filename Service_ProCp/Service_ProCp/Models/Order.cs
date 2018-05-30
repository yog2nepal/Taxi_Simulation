using Service_ProCp.Views.Main;
using System;
using System.Collections.Generic;

namespace Service_ProCp.Models
{
    public class Order
    {
        #region Private Fields
        /// <summary>
        /// the order id
        /// </summary>
        private int orderId;
        /// <summary>
        /// the order DateTime
        /// </summary>
        private DateTime orderDateTime;
        /// <summary>
        /// unique static increase id
        /// </summary>
        private static int noOfOrdersCreated = 0;
        /// <summary>
        /// the start Address
        /// </summary>
        private string startAddress;
        /// <summary>
        /// the destination Address
        /// </summary>
        private string destinationAddress;
        /// <summary>
        /// the destination picked Address
        /// </summary>
        private string pickedAddress;

        #endregion

        #region Properties
        /// <summary>
        /// Getters and Setters of Order ID
        /// </summary>
        public int OrderId { get { return this.orderId; } set { this.orderId = value; } }
        /// <summary>
        /// The date time of the order
        /// </summary>
        public DateTime OrderDateTime { get { return orderDateTime; } set { orderDateTime = value; } }
        /// <summary>
        /// orders
        /// </summary>
        public List<Order> orders;
        /// <summary>
        /// Random Address 
        /// </summary>
        Random SAddressRND = new Random();
        /// <summary>
        /// Getters and Setters of Start Address
        /// </summary>
        public string StartAddress { get { return this.startAddress; } set { startAddress = value; } }
        /// <summary>
        /// Getters and Setters of Destination Address 
        /// </summary>
        public string DestinationAddress { get { return destinationAddress; } set { destinationAddress = value; } }
        /// <summary>
        /// Getters and Setters of PickAddress 
        /// </summary>
        public string PickedAddress { get { return pickedAddress; } set { pickedAddress = value; } }
        /// <summary>
        /// Getters and Setters of Driver 
        /// </summary>
        public Car Driver { get; set; }
        #endregion

        #region Delegate&Events
        /// <summary>
        /// Delegate for event handling
        /// </summary>
        /// <param name="sender"></param>
        public delegate void requestStatsHandler(Order sender);

        /// <summary>
        /// Event handling
        /// </summary>
        public event requestStatsHandler reQuestEvent;

        /// <summary>
        /// Request status information
        /// </summary>
        public void RequestStatsInfos()
        {
            if (this.reQuestEvent != null) { this.reQuestEvent(this); }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor of Order Class
        /// </summary>
        public Order(Car driver)
        {
            if (driver != null)
            {
                this.OrderId = ++noOfOrdersCreated;
                this.OrderDateTime = DateTime.Now;
                Driver = driver;
                this.StartAddress = driver.DepartureHotspot.HotspotName;
                this.PickedAddress = driver.DestinationHotspot.HotspotName;
            }
        }
        #endregion      

        #region Public Methods

        /// <summary>
        /// Returns Address associated with specific OrderId
        /// </summary>
        /// <param name="carId"></param>
        /// <returns></returns>
        public void PrintOrder(MainView frm1)
        {
            frm1.lbNumberOfRequests.Items.Add("OrderId: " + OrderId.ToString());
            frm1.lbNumberOfRequests.Items.Add("Pick: " + PickedAddress);
            if (DestinationAddress != null)
            {
                frm1.lbNumberOfRequests.Items.Add("Drop: " + DestinationAddress);
            }
            frm1.lbNumberOfRequests.Items.Add("************* ");

            if (DestinationAddress == null)
            {
                frm1.lbStatistics.Items.Add("" + OrderId.ToString() + ", "
              + StartAddress + " ==> " + PickedAddress);
            }
            else
            {
                frm1.lbStatistics.Items.Add("" + OrderId.ToString() + ", "
              + StartAddress + " ==> " + PickedAddress + " ==>" + DestinationAddress);
            }
            frm1.lbStatistics.Items.Add("" + OrderDateTime);
            frm1.lbStatistics.Items.Add(Driver.CarID + " " + Driver.CarType + ",   " + Driver.PlateNumber);
            frm1.lbStatistics.Items.Add("************* ");

            frm1.lbStatistics.SelectedIndex = frm1.lbStatistics.Items.Count - 1;
            frm1.lbNumberOfRequests.SelectedIndex = frm1.lbNumberOfRequests.Items.Count - 1;
        }

        /*End of Class */
        #endregion
    }
}
