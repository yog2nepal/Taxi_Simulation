using Microsoft.Office.Interop.Excel;
using Service_ProCp.BusinessLogic;
using Service_ProCp.Models;
using Service_ProCp.Views.Main;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Service_ProCp.Views.ControlStation
{
    public partial class ControlStation : Form, IControlStation
    {
        private MainView frm1;
        int v = 0;

        public ControlStation(MainView frm1)
        {
            InitializeComponent();
            this.frm1 = frm1;
            btOrder.Enabled = false;

            comboBox1.Items.Add("Rachelsmolen");
            comboBox1.Items.Add("Hoofdweg");
            comboBox1.Items.Add("Breukelaan");
            comboBox1.Items.Add("Boshdijk");
            comboBox1.Items.Add("Eddiusweg");
            comboBox1.Items.Add("Prinsengracht");
            comboBox1.Items.Add("Keizergracht");
            comboBox1.Items.Add("Johnathstreet");
        }

        //Used for ordering a random taxi
        private void btOrder_Click(object sender, EventArgs e)
        {
            this.frm1.ns.MakeOrder(frm1.ns.AssignCarToOrder()); // Making an order
            frm1.StartCarMovements(); // Car movemnts
            // Method to display on Requests listbox
            Order();
        }

        //Used for ordering a car
        public void Order()
        {
            frm1.lbNumberOfRequests.Items.Clear();
            frm1.lbStatistics.Items.Clear();
            if (frm1 != null)
            {
                foreach (Order o in frm1.ns.Orders)
                {
                    o.PrintOrder(frm1);
                }
            }
            frm1.UpdateCar();
        }

        private void btChange_Click(object sender, EventArgs e)
        {
            // Changing car destination 
            if (frm1.lbUnAvailableCars.SelectedIndex > -1)
            {
                if (frm1.ns.UnavailableCars[frm1.lbUnAvailableCars.SelectedIndex].isPassengerPicked == Status.PickedPassenger)
                {
                    frm1.ns.UnavailableCars[frm1.lbUnAvailableCars.SelectedIndex].Orderstatus = OrderStatus.Change;
                }
            }
        }

        // Shows all hotspots


        //Cancelling a specific order taxi
        private void btCancelTaxi_Click(object sender, EventArgs e)
        {
            if (frm1.lbUnAvailableCars.SelectedIndex > -1)
            {
                if (frm1.ns.UnavailableCars[frm1.lbUnAvailableCars.SelectedIndex].isPassengerPicked <= Status.PickedPassenger)
                {
                    frm1.ns.UnavailableCars[frm1.lbUnAvailableCars.SelectedIndex].Orderstatus = OrderStatus.Cancel;
                    if (frm1.ns.UnavailableCars[frm1.lbUnAvailableCars.SelectedIndex].isPassengerPicked == Status.GoingToPickPassenger)
                    {
                        frm1.ns.UnavailableCars[frm1.lbUnAvailableCars.SelectedIndex].Orderstatus = OrderStatus.CancelBeforePicking;
                    }
                }
            }
        }

        // For testing to be removed after


        //Used to make the form2 Control station back to visible on closing
        private void button3_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Rachelsmolen")
            {
                foreach (Hotspot h in frm1.ns.Hotspots)
                {
                    if (h.HotspotName == "Rachelsmolen")
                    {
                        h.MaxCapacity = 2;
                        frm1.btRachelsmolen.Visible = true;
                        comboBox1.Items.Remove("Rachelsmolen");
                        comboBox1.ResetText();
                        if (comboBox1.Items.Count == 0)
                        {
                            btBuyHotSpot.Enabled = false;
                        }
                    }
                }
            }
            if (comboBox1.Text == "Breukelaan")
            {
                foreach (Hotspot h in frm1.ns.Hotspots)
                {
                    if (h.HotspotName == "Breukelaan")
                    {
                        h.MaxCapacity = 2;
                        frm1.btBreukelaan.Visible = true;
                        comboBox1.Items.Remove("Breukelaan");
                        comboBox1.ResetText();
                        if (comboBox1.Items.Count == 0)
                        {
                            btBuyHotSpot.Enabled = false;
                        }
                    }
                }
            }
            if (comboBox1.Text == "Hoofdweg")
            {
                foreach (Hotspot h in frm1.ns.Hotspots)
                {
                    if (h.HotspotName == "Hoofdweg")
                    {
                        h.MaxCapacity = 2;
                        frm1.btHoofdweg.Visible = true;
                        comboBox1.Items.Remove("Hoofdweg");
                        comboBox1.ResetText();
                        if (comboBox1.Items.Count == 0)
                        {
                            btBuyHotSpot.Enabled = false;
                        }
                    }
                }
            }
            if (comboBox1.Text == "Boshdijk")
            {
                foreach (Hotspot h in frm1.ns.Hotspots)
                {
                    if (h.HotspotName == "Boshdijk")
                    {
                        h.MaxCapacity = 2;
                        frm1.btBoshdijk.Visible = true;
                        comboBox1.Items.Remove("Boshdijk");
                        comboBox1.ResetText();
                        if (comboBox1.Items.Count == 0)
                        {
                            btBuyHotSpot.Enabled = false;
                        }
                    }
                }
            }
            if (comboBox1.Text == "Eddiusweg")
            {
                foreach (Hotspot h in frm1.ns.Hotspots)
                {
                    if (h.HotspotName == "Eddiusweg")
                    {
                        h.MaxCapacity = 2;
                        frm1.btEddiusweg.Visible = true;
                        comboBox1.Items.Remove("Eddiusweg");
                        comboBox1.ResetText();
                        if (comboBox1.Items.Count == 0)
                        {
                            btBuyHotSpot.Enabled = false;
                        }
                    }
                }
            }
            if (comboBox1.Text == "Prinsengracht")
            {
                foreach (Hotspot h in frm1.ns.Hotspots)
                {
                    if (h.HotspotName == "Prinsengracht")
                    {
                        h.MaxCapacity = 2;
                        frm1.btPrinsengracht.Visible = true;
                        comboBox1.Items.Remove("Prinsengracht");
                        comboBox1.ResetText();
                        if (comboBox1.Items.Count == 0)
                        {
                            btBuyHotSpot.Enabled = false;
                        }
                    }
                }
            }
            if (comboBox1.Text == "Keizergracht")
            {
                foreach (Hotspot h in frm1.ns.Hotspots)
                {
                    if (h.HotspotName == "Keizergracht")
                    {
                        h.MaxCapacity = 2;
                        frm1.btKeizergracht.Visible = true;
                        comboBox1.Items.Remove("Keizergracht");
                        comboBox1.ResetText();
                        if (comboBox1.Items.Count == 0)
                        {
                            btBuyHotSpot.Enabled = false;
                        }
                    }
                }
            }
            if (comboBox1.Text == "Johnathstreet")
            {
                foreach (Hotspot h in frm1.ns.Hotspots)
                {
                    if (h.HotspotName == "Johnathstreet")
                    {
                        h.MaxCapacity = 2;
                        frm1.btJohnathstreet.Visible = true;
                        comboBox1.Items.Remove("Johnathstreet");
                        comboBox1.ResetText();
                        if (comboBox1.Items.Count == 0)
                        {
                            btBuyHotSpot.Enabled = false;
                        }
                    }
                }
            }

        }

        public void UpdateListBoxViewRealTimeMinutes(string[] info)
        {
            ListViewItem lvi = new ListViewItem(info[0]);
            lvi.SubItems.Add(info[1]);
            lvi.SubItems.Add(info[2]);
            lvi.SubItems.Add(info[3]);
            lvi.SubItems.Add(info[4]);
            this.lbUpdate.Items.Add(lvi);
        }

        private void ControlStation_Load(object sender, EventArgs e)
        {
            lbUpdate.GridLines = true;
            lbUpdate.View = View.Details;
            lbUpdate.MultiSelect = false;

            lbUpdate.Columns[0].Width = 70;
            lbUpdate.Columns[1].Width = 87;
            lbUpdate.Columns[2].Width = 87;
            lbUpdate.Columns[3].Width = 87;
        }

        public int FindListViewItemToEdit(string carName)
        {
            //string[] temp = new string[5];
            string carNameonList = string.Empty;
            int index = 0;
            for (int i = 0; i < lbUpdate.Items.Count; i++)
            {
                carNameonList = lbUpdate.Items[i].SubItems[0].Text;
                if (carName == carNameonList)
                {
                    index = i;

                }

            }
            return index;

        }
        #region
        /// <summary>
        /// Method to edit the listbox data for Real Time
        /// </summary>
        /// <param name="index"></param>
        /// <param name="info"></param>
        public void EditListViewItem(int index, string info)
        {
            lbUpdate.Items[index].Selected = true;
            if (lbUpdate.Items[index].SubItems[2].Text == "")
            {
                lbUpdate.Items[index].SubItems[2].Text = info;
            }
            else if (lbUpdate.Items[index].SubItems[3].Text == "")
            {
                lbUpdate.Items[index].SubItems[3].Text = info;
            }

        }
        #endregion

        public void AverageWaitingTime(double avgTime)
        {
            this.avgWaitingTime.Text = Convert.ToInt32(avgTime).ToString() + " Seconds";
        }
        /// <summary>
        /// loading file 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Load_Click(object sender, EventArgs e)
        {
            frm1.StopSimulation();
            try
            {
                OpenFileDialog f = new OpenFileDialog();
                if (f.ShowDialog() == DialogResult.OK)
                {
                    frm1.lbNumberOfRequests.Items.Clear();
                    frm1.lbStatistics.Items.Clear();
                    frm1.lbAvailableCars.Items.Clear();
                    frm1.lbUnAvailableCars.Items.Clear();

                    List<string> lines = new List<string>();
                    using (StreamReader r = new StreamReader(f.OpenFile()))
                    {
                        string line;

                        while ((line = r.ReadLine()) != null)
                        {
                            if (line.StartsWith("%"))
                            {
                                line = r.ReadLine();
                                while (!line.StartsWith("@"))
                                {
                                    frm1.lbAvailableCars.Items.Add(line);
                                    line = r.ReadLine();
                                }
                            }

                            if (line.StartsWith("@"))
                            {
                                line = r.ReadLine();
                                while (!line.StartsWith("#"))
                                {
                                    frm1.lbUnAvailableCars.Items.Add(line);
                                    line = r.ReadLine();
                                }
                            }

                            if (line.StartsWith("#"))
                            {
                                line = r.ReadLine();
                                while (!line.StartsWith("&"))
                                {
                                    frm1.lbStatistics.Items.Add(line);
                                    line = r.ReadLine();
                                }
                            }

                            if (line.StartsWith("&"))
                            {
                                line = r.ReadLine();
                                while (!line.StartsWith("!"))
                                {
                                    frm1.lbNumberOfRequests.Items.Add(line);
                                    line = r.ReadLine();
                                }
                            }
                            line = r.ReadLine();
                        }
                    }
                }
            }

            catch (Exception)
            {
                MessageBox.Show("Something wrong while loading ");
            }
        }
        /// <summary>
        /// for saving file 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Save_Click(object sender, EventArgs e)
        {
            frm1.StopSimulation();
            // Save everything in a dialog box
            saveFileDialog1.Filter = "txt files (.txt)|.txt";
            saveFileDialog1.ShowDialog();

            // Open the file and save the information
            try
            {

                Stream textOut = saveFileDialog1.OpenFile();
                StreamWriter SaveFile = new StreamWriter(textOut);

                SaveFile.WriteLine("%%%%");
                foreach (var item in frm1.lbAvailableCars.Items)
                {

                    SaveFile.WriteLine(item);
                }
                SaveFile.WriteLine("@@@@@");

                foreach (var item in frm1.lbUnAvailableCars.Items)
                {
                    SaveFile.WriteLine(item);
                }

                SaveFile.WriteLine("####");

                foreach (var item in frm1.lbStatistics.Items)
                {
                    SaveFile.WriteLine(item);
                }

                SaveFile.WriteLine("&&&&&");

                foreach (var item in frm1.lbNumberOfRequests.Items)
                {
                    SaveFile.WriteLine(item);
                }
              
                SaveFile.WriteLine("!!!!!");

                foreach (Hotspot item in frm1.ns.Hotspots)
                {

                    SaveFile.WriteLine(item);
                }
                SaveFile.Close();

                MessageBox.Show("Saved Successfull");
                frm1.lbNumberOfRequests.Items.Clear();
                frm1.lbStatistics.Items.Clear();
                frm1.lbAvailableCars.Items.Clear();
                frm1.lbUnAvailableCars.Items.Clear();


            }
            catch (Exception)
            {
                MessageBox.Show("Please specify the filename and click save button to save");
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {

           

            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel WorkBook|*xls", ValidateNames = true })
            {

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
                    Workbook wb = app.Workbooks.Add(XlSheetType.xlWorksheet);
                    Worksheet ws = (Worksheet)app.ActiveSheet;
                    app.Visible = false;
                    for (int j = 1; j <= lbUpdate.Columns.Count; j++)
                    {
                        var newWidth = Math.Min(255, lbUpdate.Columns[j - 1].Width / 2);
                        ws.Columns[j].ColumnWidth = newWidth;
                        ws.Cells[1, j] = lbUpdate.Columns[j - 1].Text;
                    }
                    int i = 2;
                    foreach (ListViewItem item in lbUpdate.Items)
                    {
                        for (int k = 1; k <= item.SubItems.Count; k++)
                        {
                            ws.Cells[i, k] = item.SubItems[k - 1].Text;
                        }
                        i++;
                    }
                    wb.SaveAs(sfd.FileName, XlFileFormat.xlWorkbookDefault, Type.Missing, Type.Missing, false, false, XlSaveAsAccessMode.xlNoChange, XlSaveConflictResolution.xlLocalSessionChanges, Type.Missing, Type.Missing);
                    app.Quit();
                    MessageBox.Show("Exported Successfully.");
                }
            }
            }
            catch (Exception)
            {

                MessageBox.Show("Something wrong while saving ");
            }

        }
    }
}

