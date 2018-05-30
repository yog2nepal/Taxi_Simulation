namespace Service_ProCp.Views.ControlStation
{
    partial class ControlStation
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.avgWaitingTime = new System.Windows.Forms.Label();
            this.lb = new System.Windows.Forms.Label();
            this.btBuyHotSpot = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.btn_Load = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btOrder = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lbUpdate = new System.Windows.Forms.ListView();
            this.colCar = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDeparture = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPickUpTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDropOffTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label6 = new System.Windows.Forms.Label();
            this.btChange = new System.Windows.Forms.Button();
            this.btCancelTaxi = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.avgWaitingTime);
            this.panel1.Controls.Add(this.lb);
            this.panel1.Controls.Add(this.btBuyHotSpot);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.btn_Save);
            this.panel1.Controls.Add(this.btn_Load);
            this.panel1.Controls.Add(this.btnLoad);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btOrder);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.btChange);
            this.panel1.Controls.Add(this.btCancelTaxi);
            this.panel1.Location = new System.Drawing.Point(16, 14);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 413);
            this.panel1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.MediumAquamarine;
            this.button1.Location = new System.Drawing.Point(660, 366);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 32);
            this.button1.TabIndex = 45;
            this.button1.Text = "ExportTo Excel";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // avgWaitingTime
            // 
            this.avgWaitingTime.AutoSize = true;
            this.avgWaitingTime.Location = new System.Drawing.Point(421, 377);
            this.avgWaitingTime.Name = "avgWaitingTime";
            this.avgWaitingTime.Size = new System.Drawing.Size(0, 17);
            this.avgWaitingTime.TabIndex = 44;
            // 
            // lb
            // 
            this.lb.AutoSize = true;
            this.lb.Location = new System.Drawing.Point(304, 377);
            this.lb.Name = "lb";
            this.lb.Size = new System.Drawing.Size(100, 17);
            this.lb.TabIndex = 43;
            this.lb.Text = "Average Time:";
            // 
            // btBuyHotSpot
            // 
            this.btBuyHotSpot.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btBuyHotSpot.Location = new System.Drawing.Point(165, 127);
            this.btBuyHotSpot.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btBuyHotSpot.Name = "btBuyHotSpot";
            this.btBuyHotSpot.Size = new System.Drawing.Size(116, 52);
            this.btBuyHotSpot.TabIndex = 42;
            this.btBuyHotSpot.Text = "Buy HotSpot";
            this.btBuyHotSpot.UseVisualStyleBackColor = false;
            this.btBuyHotSpot.Click += new System.EventHandler(this.button1_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Green;
            this.button3.Location = new System.Drawing.Point(19, 276);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(153, 34);
            this.button3.TabIndex = 41;
            this.button3.Text = "Close";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.BackColor = System.Drawing.Color.MediumAquamarine;
            this.btn_Save.Location = new System.Drawing.Point(19, 203);
            this.btn_Save.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(116, 44);
            this.btn_Save.TabIndex = 39;
            this.btn_Save.Text = "Save";
            this.btn_Save.UseVisualStyleBackColor = false;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // btn_Load
            // 
            this.btn_Load.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btn_Load.Location = new System.Drawing.Point(165, 203);
            this.btn_Load.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_Load.Name = "btn_Load";
            this.btn_Load.Size = new System.Drawing.Size(116, 44);
            this.btn_Load.TabIndex = 38;
            this.btn_Load.Text = "Load";
            this.btn_Load.UseVisualStyleBackColor = false;
            this.btn_Load.Click += new System.EventHandler(this.btn_Load_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnLoad.Location = new System.Drawing.Point(407, 443);
            this.btnLoad.Margin = new System.Windows.Forms.Padding(4);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(157, 69);
            this.btnLoad.TabIndex = 37;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = false;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.LightGreen;
            this.btnSave.Location = new System.Drawing.Point(228, 446);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(152, 68);
            this.btnSave.TabIndex = 36;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            // 
            // btOrder
            // 
            this.btOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btOrder.Location = new System.Drawing.Point(165, 34);
            this.btOrder.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btOrder.Name = "btOrder";
            this.btOrder.Size = new System.Drawing.Size(116, 50);
            this.btOrder.TabIndex = 33;
            this.btOrder.Text = "Order Taxi";
            this.btOrder.UseVisualStyleBackColor = false;
            this.btOrder.Click += new System.EventHandler(this.btOrder_Click);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Peru;
            this.panel5.Controls.Add(this.lbUpdate);
            this.panel5.Controls.Add(this.label6);
            this.panel5.Location = new System.Drawing.Point(307, 17);
            this.panel5.Margin = new System.Windows.Forms.Padding(1);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(483, 345);
            this.panel5.TabIndex = 32;
            // 
            // lbUpdate
            // 
            this.lbUpdate.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colCar,
            this.colDeparture,
            this.colPickUpTime,
            this.colDropOffTime});
            this.lbUpdate.Location = new System.Drawing.Point(23, 34);
            this.lbUpdate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lbUpdate.Name = "lbUpdate";
            this.lbUpdate.Size = new System.Drawing.Size(445, 297);
            this.lbUpdate.TabIndex = 43;
            this.lbUpdate.UseCompatibleStateImageBehavior = false;
            // 
            // colCar
            // 
            this.colCar.Text = "Car";
            // 
            // colDeparture
            // 
            this.colDeparture.Text = "Departure";
            // 
            // colPickUpTime
            // 
            this.colPickUpTime.Text = "Pick Up Time";
            this.colPickUpTime.Width = 100;
            // 
            // colDropOffTime
            // 
            this.colDropOffTime.Text = "Drop Off Time";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(144, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(126, 18);
            this.label6.TabIndex = 16;
            this.label6.Text = "Real Time Update";
            // 
            // btChange
            // 
            this.btChange.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btChange.Location = new System.Drawing.Point(19, 133);
            this.btChange.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btChange.Name = "btChange";
            this.btChange.Size = new System.Drawing.Size(116, 46);
            this.btChange.TabIndex = 31;
            this.btChange.Text = "Change Destination";
            this.btChange.UseVisualStyleBackColor = false;
            this.btChange.Click += new System.EventHandler(this.btChange_Click);
            // 
            // btCancelTaxi
            // 
            this.btCancelTaxi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btCancelTaxi.Location = new System.Drawing.Point(19, 34);
            this.btCancelTaxi.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btCancelTaxi.Name = "btCancelTaxi";
            this.btCancelTaxi.Size = new System.Drawing.Size(116, 50);
            this.btCancelTaxi.TabIndex = 30;
            this.btCancelTaxi.Text = "Cancel Taxi";
            this.btCancelTaxi.UseVisualStyleBackColor = false;
            this.btCancelTaxi.Click += new System.EventHandler(this.btCancelTaxi_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 17);
            this.label1.TabIndex = 49;
            this.label1.Text = "Which Hotspot to buy:";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(160, 93);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 24);
            this.comboBox1.TabIndex = 48;
            // 
            // ControlStation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(840, 438);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Location = new System.Drawing.Point(900, 200);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ControlStation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Control Station";
            this.Load += new System.EventHandler(this.ControlStation_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button button3;
        public System.Windows.Forms.Button btOrder;
        private System.Windows.Forms.ListView lbUpdate;
        private System.Windows.Forms.ColumnHeader colCar;
        private System.Windows.Forms.ColumnHeader colDeparture;
        private System.Windows.Forms.ColumnHeader colPickUpTime;
        private System.Windows.Forms.ColumnHeader colDropOffTime;
        private System.Windows.Forms.Label avgWaitingTime;
        private System.Windows.Forms.Label lb;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        public System.Windows.Forms.Button btChange;
        public System.Windows.Forms.Button btCancelTaxi;
        public System.Windows.Forms.Button btn_Save;
        public System.Windows.Forms.Button btn_Load;
        public System.Windows.Forms.Button btBuyHotSpot;
        public System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}