using System;
using System.Drawing;

namespace Service_ProCp.Models
{
    public class Hotspot
    {
        #region Fields
        /// <summary>
        /// Static field to assign unique ID
        /// </summary>
        private static int noOfHotSpotCreated = 0;
        /// <summary>
        /// Hotspots ID
        /// </summary>
        private int hotspotsid;
        #endregion

        #region Property
        /// <summary>
        /// Current capacity of hotspot
        /// </summary>
        public int CurrentCapacity { get; set; }

        /// <summary>
        /// Max capacity of hotspot
        /// </summary>
        public int MaxCapacity { get; set; }
        
        /// <summary>
        /// Hotspot name
        /// </summary>
        public string HotspotName { get; set; }

        /// <summary>
        /// rectangle size of hotspot
        /// </summary>
        public Rectangle Rect { get; set; }

        /// <summary>
        /// Image of hotspot
        /// </summary>
        public Image Image { get; set; }

        /// <summary>
        /// Point X hotspot
        /// </summary>
        public int PX { get; set; }

        /// <summary>
        /// Getters and Setters of Point Y hotspot
        /// </summary>
        public int PY { get; set; }

        /// <summary>
        /// Getters and Setters of points
        /// </summary>
        public Point Point { get; set; }

        /// <summary>
        /// Getters and Setters of hosSpotID
        /// </summary>
        public int hotSpotsID { get { return this.hotspotsid; } set { this.hotspotsid = value; } }
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor of HotSpot Class
        /// </summary>
        /// <param name="hotSpot_name"></param>
        /// <param name="cap"></param>
        /// <param name="maxCap"></param>
        public Hotspot(string hotSpot_name, int cap, int maxCap)
        {
            this.hotSpotsID = ++noOfHotSpotCreated;
            //HotSpotID = hotspot_id;
            HotspotName = hotSpot_name;
            this.CurrentCapacity = cap;
            this.MaxCapacity = maxCap;
            this.Rect = new Rectangle();
            this.Image = Properties.Resources.hotspotPic;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Draws the hotspot 
        /// </summary>
        /// <param name="g"></param>
        public void drawYourSelf(Graphics g)
        {
            g.DrawImage(Properties.Resources.hotspotPic, Rect);
        }

        /// <summary>
        /// gets information of the selected hotspot
        /// </summary>
        public override string ToString()
        {
            return hotSpotsID + ", " + HotspotName + ", Cap: " + CurrentCapacity + ", Max Cap " + MaxCapacity;
        }
        #endregion
    }
}
