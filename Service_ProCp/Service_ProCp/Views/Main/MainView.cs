using Service_ProCp.BusinessLogic;
using Service_ProCp.Models;
using System;
using System.Windows.Forms;
using System.Threading;
//using System.Diagnostics;

namespace Service_ProCp.Views.Main
{
    public partial class MainView : Form
    {
        public NetworkStation ns;
        public DataHelper dh;

        private bool checkTimer;

        public ControlStation.ControlStation form2;

        /// <summary>
        ///  Constructor of the form
        /// </summary>
        public MainView()
        {
          //  Stopwatch Mytimer = new Stopwatch();
            InitializeComponent();
            form2 = new ControlStation.ControlStation(this);
            form2.Visible = false;
            btStopSimulation.Enabled = false;
            checkTimer = true;
            ns = new NetworkStation(this);
            dh = new DataHelper();
            this.timer1.Interval = 1000;
            this.timer2.Interval = 10;
            timer1.Tick += OnTimeEvent;
            //btn_Menu.Enabled = false;
            form2.btOrder.Enabled = false;
            form2.btn_Save.Enabled = false;
            form2.btn_Load.Enabled = false;
            form2.btChange.Enabled = false;
            form2.btCancelTaxi.Enabled = false;
          //  Mytimer.Start();
           // MessageBox.Show("time taken to start" + Mytimer.Elapsed);
        }

        // Updating car infos
        public void UpdateCar()
        {
            int index = lbUnAvailableCars.SelectedIndex;
            string check = "";
            if (index > -1)
            {
                check = ((string)lbUnAvailableCars.Items[index]).Split(',')[1];
            }
            lbAvailableCars.Items.Clear();
            foreach (Car c in ns.GetAvailableCars())
            {
                lbAvailableCars.Items.Add(c.AsAString());
            }
            lbUnAvailableCars.Items.Clear();
            foreach (Car c in ns.GetUnAvailableCars())
            {
                lbUnAvailableCars.Items.Add(c.AsAString());

                if (check == c.CarType && check != "")
                {
                    index = ns.GetUnAvailableCars().IndexOf(c);
                }

            }
            if (lbUnAvailableCars.Items.Count < index + 1 && index > -1)
            {
                index = lbUnAvailableCars.Items.Count - 1;
            }

            lbUnAvailableCars.SelectedIndex = index;
        }

        // Updating statistics
        public void UpdateStatistics()
        {
            form2.Order();
        }

        private void btn_Menu_Click(object sender, EventArgs e)
        {
            form2.Visible = !form2.Visible;
        }

        //Starts simulating the car movements
        private void StartSimulation()
        {
            ns.assignPointToCars(); // assigning points to cars
            foreach (Car c in ns.myCars)
            {
                this.pictureBox1.Controls.Add(c.CarPb);
                this.pictureBox1.Controls.Add(c.label);
                //this.Controls[this.Controls.Count - 1].BringToFront();
            }
            // pictureBox1.Invalidate();
        }

        // Button starting the simulation
        private void btStartSimulation_Click_1(object sender, EventArgs e)
        {
            if (checkTimer == true)
            {
                lbAvailableCars.Items.Clear();
                StartSimulation();
                ShowAllCars();
            }
            else
            {
                StartCarMovements();
            }
            btStartSimulation.Enabled = false;
            btStopSimulation.Enabled = true;

            form2.btOrder.Enabled = true;
            form2.btn_Save.Enabled = true;
            form2.btn_Load.Enabled = true;
            form2.btChange.Enabled = true;
            form2.btCancelTaxi.Enabled = true;
        }

        #region Method Showing All myCars
        public void ShowAllCars()
        {
            lbAvailableCars.Items.Clear();
            lbUnAvailableCars.Items.Clear();
            foreach (Car c in ns.getAllCars())
            {
                if (c.isCarAvailable == true)
                {
                    lbAvailableCars.Items.Add(c.AsAString());
                }
                else
                    lbUnAvailableCars.Items.Add(c.AsAString());
            }
        }
        #endregion

        //Used for timer movement of the cars
        public void StartCarMovements()
        {
            timer1.Start();
            timer2.Start();
        }

        //used for points on the map
        //private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        //{
        //    label6.Text = " X: " + e.X + " Y: " + e.Y;
        //}

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        public void StopSimulation()
        {
            timer1.Stop();
            timer2.Stop();
            checkTimer = false;

            btStartSimulation.Enabled = true;
            btStopSimulation.Enabled = false;
            form2.btOrder.Enabled = false;
        }
        private void btStopSimulation_Click(object sender, EventArgs e)
        {
            StopSimulation();
        }

        private void lbNumberOfRequests_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        //for timer 
        int h, m, s;

        #region show hotspot info

        private void showCapacityInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Hotspot h in ns.Hotspots)
            {
                if (h.hotSpotsID == 1)
                {
                    MessageBox.Show("Current Capacity: " + h.CurrentCapacity + "," + " MaxCapacity: " + h.MaxCapacity, h.HotspotName);
                }
            }
        }

        private void showCapacityInfoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            foreach (Hotspot h in ns.Hotspots)
            {
                if (h.hotSpotsID == 2)
                {
                    MessageBox.Show("Current Capacity: " + h.CurrentCapacity + "," + " MaxCapacity: " + h.MaxCapacity, h.HotspotName);
                }
            }
        }

        private void showCapacityInfoToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            foreach (Hotspot h in ns.Hotspots)
            {
                if (h.hotSpotsID == 3)
                {
                    MessageBox.Show("Current Capacity: " + h.CurrentCapacity + "," + " MaxCapacity: " + h.MaxCapacity, h.HotspotName);
                }
            }
        }

        private void showCapacityInfoToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            foreach (Hotspot h in ns.Hotspots)
            {
                if (h.hotSpotsID == 4)
                {
                    MessageBox.Show("Current Capacity: " + h.CurrentCapacity + "," + " MaxCapacity: " + h.MaxCapacity, h.HotspotName);
                }
            }
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            foreach (Hotspot h in ns.Hotspots)
            {
                if (h.hotSpotsID == 7)
                {
                    MessageBox.Show("Current Capacity: " + h.CurrentCapacity + "," + " MaxCapacity: " + h.MaxCapacity, h.HotspotName);
                }
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            foreach (Hotspot h in ns.Hotspots)
            {
                if (h.hotSpotsID == 5)
                {
                    MessageBox.Show("Current Capacity: " + h.CurrentCapacity + "," + " MaxCapacity: " + h.MaxCapacity, h.HotspotName);
                }
            }
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            foreach (Hotspot h in ns.Hotspots)
            {
                if (h.hotSpotsID == 6)
                {
                    MessageBox.Show("Current Capacity: " + h.CurrentCapacity + "," + " MaxCapacity: " + h.MaxCapacity, h.HotspotName);
                }
            }
        }

        private void showEddiusweg_Click(object sender, EventArgs e)
        {
            foreach (Hotspot h in ns.Hotspots)
            {
                if (h.hotSpotsID == 9)
                {
                    MessageBox.Show("Current Capacity: " + h.CurrentCapacity + "," + " MaxCapacity: " + h.MaxCapacity, h.HotspotName);
                }
            }
        }

        private void showBoshdijk_Click(object sender, EventArgs e)
        {
            foreach (Hotspot h in ns.Hotspots)
            {
                if (h.hotSpotsID == 8)
                {
                    MessageBox.Show("Current Capacity: " + h.CurrentCapacity + "," + " MaxCapacity: " + h.MaxCapacity, h.HotspotName);
                }
            }
        }

        private void showPrinsengracht_Click(object sender, EventArgs e)
        {
            foreach (Hotspot h in ns.Hotspots)
            {
                if (h.hotSpotsID == 10)
                {
                    MessageBox.Show("Current Capacity: " + h.CurrentCapacity + "," + " MaxCapacity: " + h.MaxCapacity, h.HotspotName);
                }
            }
        }

        private void showKeizergracht_Click(object sender, EventArgs e)
        {
            foreach (Hotspot h in ns.Hotspots)
            {
                if (h.hotSpotsID == 11)
                {
                    MessageBox.Show("Current Capacity: " + h.CurrentCapacity + "," + " MaxCapacity: " + h.MaxCapacity, h.HotspotName);
                }
            }
        }

        private void showJohnathstreet_Click(object sender, EventArgs e)
        {
            foreach (Hotspot h in ns.Hotspots)
            {
                if (h.hotSpotsID == 12)
                {
                    MessageBox.Show("Current Capacity: " + h.CurrentCapacity + "," + " MaxCapacity: " + h.MaxCapacity, h.HotspotName);
                }
            }
        }


        #endregion

        #region Change hotspot capacity

        private void confirmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Hotspot h in ns.Hotspots)
            {
                if (h.hotSpotsID == 1)
                {
                    ns.changeHotspotCapacity(h, Convert.ToInt32(tbChange1.Text));
                }
            }
        }

        private void confirmToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            foreach (Hotspot h in ns.Hotspots)
            {
                if (h.hotSpotsID == 2)
                {
                    ns.changeHotspotCapacity(h, Convert.ToInt32(tbChange2.Text));
                }
            }
        }

        private void confirmToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            foreach (Hotspot h in ns.Hotspots)
            {
                if (h.hotSpotsID == 3)
                {
                    ns.changeHotspotCapacity(h, Convert.ToInt32(tbChange3.Text));
                }
            }
        }

        private void confirmToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            foreach (Hotspot h in ns.Hotspots)
            {
                if (h.hotSpotsID == 4)
                {
                    ns.changeHotspotCapacity(h, Convert.ToInt32(tbChange4.Text));
                }
            }
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            foreach (Hotspot h in ns.Hotspots)
            {
                if (h.hotSpotsID == 5)
                {
                    ns.changeHotspotCapacity(h, Convert.ToInt32(tbChange5.Text));
                }
            }
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            foreach (Hotspot h in ns.Hotspots)
            {
                if (h.hotSpotsID == 7)
                {
                    ns.changeHotspotCapacity(h, Convert.ToInt32(tbChange6.Text));
                }
            }
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            foreach (Hotspot h in ns.Hotspots)
            {
                if (h.hotSpotsID == 6)
                {
                    ns.changeHotspotCapacity(h, Convert.ToInt32(tbChange7.Text));
                }
            }
        }

        private void cfEddiusweg_Click(object sender, EventArgs e)
        {
            foreach (Hotspot h in ns.Hotspots)
            {
                if (h.hotSpotsID == 9)
                {
                    ns.changeHotspotCapacity(h, Convert.ToInt32(tbEddiusweg.Text));
                }
            }
        }

        private void cfBoshdijk_Click(object sender, EventArgs e)
        {
            foreach (Hotspot h in ns.Hotspots)
            {
                if (h.hotSpotsID == 8)
                {
                    ns.changeHotspotCapacity(h, Convert.ToInt32(tbBoshdijk.Text));
                }
            }
        }

        private void cfPrinsengracht_Click(object sender, EventArgs e)
        {
            foreach (Hotspot h in ns.Hotspots)
            {
                if (h.hotSpotsID == 10)
                {
                    ns.changeHotspotCapacity(h, Convert.ToInt32(tbPrinsengracht.Text));
                }
            }
        }

        private void cfKeizergracht_Click(object sender, EventArgs e)
        {
            foreach (Hotspot h in ns.Hotspots)
            {
                if (h.hotSpotsID == 11)
                {
                    ns.changeHotspotCapacity(h, Convert.ToInt32(tbKeizergracht.Text));
                }
            }
        }

        private void cfJohnathstreet_Click(object sender, EventArgs e)
        {
            foreach (Hotspot h in ns.Hotspots)
            {
                if (h.hotSpotsID == 12)
                {
                    ns.changeHotspotCapacity(h, Convert.ToInt32(tbJohnathstreet.Text));
                }
            }
        }


        #endregion

        private void chkBoxRushHour_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBoxRushHour.Checked == true)
            {
                timer2.Interval = 50;
            }
            else
            {
                timer2.Interval = 10;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            this.ns.MoveCars();
        }

        private void OnTimeEvent(object sender, EventArgs e)
        {
            //int h=0, m=0, s=0;

            Invoke(new Action(() =>
            {
                s += 1;
                if (s == 60)
                {
                    s = 0;
                    m += 1;
                }
                if (m == 60)
                {
                    m = 0;
                    h += 1;
                }
                lbTimer.Text = String.Format("{0}:{1}:{2}", h.ToString().PadLeft(2, '0'), m.ToString().PadLeft(2, '0'), s.ToString().PadLeft(2, '0'));
            }
                ));
        }


        
    }
}
