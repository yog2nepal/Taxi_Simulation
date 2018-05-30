using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Service_ProCp.Models
{
    public class Car
    {
        #region Private Fields
        /// <summary>
        /// Unique id for cars
        /// </summary>
        private static int noOfOrdersCreated = 0;
        /// <summary>
        /// The Id of the car
        /// </summary>
        private int carId;
        /// <summary>
        /// The car type
        /// </summary>
        private string cartype;
        /// <summary>
        /// The platenumber of the car
        /// </summary>
        private string platenumber;

        //axis X & Y arrays
        private int[] y_axis = { 0, 91, 182, 273, 364 };
        private int[] x_axis = { 0, 261, 522, 783 };

        //Direction storage
        private List<int[]> DirectionStor;
        private int[] DirectionTaken;

        public bool IsDestinHotspot;//true if the destination is to go pick and drop passenger
        public bool IsGoingBack;//true if car has already dropped passenger and is heading back to hotspot
        public Label label;
        private int waitCounter;
        private Random rand;
        public bool infoUpdated = false;
        /// <summary>
        /// field to store the departure time of Car from Hotspot to pick passenger
        /// </summary>
        public DateTime DepartTimetoPickPassenger;
        #endregion

        #region Constants Variables
        /// <summary>
        /// Horizontal values
        /// </summary>
        private const int HORIZONTAL = 261;
        /// <summary>
        /// Vertical values
        /// </summary>
        private const int VERTICAL = 91;
        /// <summary>
        /// Temporary departure address for Y axis
        /// </summary>
        private int tempDepartY;
        /// <summary>
        /// Temporary departure address for X axis
        /// </summary>
        private int tempDepartX;
        /// <summary>
        /// Point to point for the map
        /// </summary>
        private string pointToPoint;
        #endregion

        #region Properties

        public Status isPassengerPicked;//status of the driver wether he picked, dropped passenger
        public OrderStatus Orderstatus; //status of the driver wether he picked, dropped passenger
        public bool picked; // property for pciked or not picked
        /// <summary>
        /// Getters and Setters of Car ID
        /// </summary>
        public int CarID { get { return this.carId; } set { this.carId = value; } }
        /// <summary>
        /// Getters and Setters of the type of the car
        /// </summary>
        public string CarType { get { return this.cartype; } set { this.cartype = value; } }
        /// <summary>
        /// Getters and Setters of PlateNumber
        /// </summary>
        public string PlateNumber { get { return this.platenumber; } set { this.platenumber = value; } }
        /// <summary>
        /// boolean is a car available or not
        /// </summary>
        public bool isCarAvailable { get; set; }
        /// <summary>
        /// Orders
        /// </summary>
        public List<Order> orders;
        /// <summary>
        /// Getters and Setters for departure hotspot
        /// </summary>
        public Hotspot DepartureHotspot { get; set; }
        /// <summary>
        /// Getters and Setters for destination hotspot
        /// </summary>
        public Hotspot DestinationHotspot { get; set; }
        /// <summary>
        /// Getters and Setters for TEMP arrival point for the movement of taxis
        /// </summary>
        public Point ArrivalPoint { get; set; }

        /// <summary>
        /// Getters and Settersfor the image
        /// </summary>
        public Image Image { get; set; }
        /// <summary>
        /// Getters and Setters for the points
        /// </summary>
        public Point Point { get; set; }

        private int px, py;
        /// <summary>
        /// Getters and Setters for the point X
        /// </summary>
        public int PX { get { return px; } set { px = value; UpdatePbLocation(); } }
        /// <summary>
        /// Getters and Setters for the point Y
        /// </summary>
        public int PY { get { return py; } set { py = value; UpdatePbLocation(); } }
        /// <summary>
        /// Picture box for the car object
        /// </summary>
        public PictureBox CarPb;
        /// <summary>
        /// Getters and Setters for the Enum movement
        /// </summary>
        public MovementType Type { get; set; }
        #endregion

        #region Constructor

        /// <summary>
        /// Constructor of Car 
        /// </summary>
        /// <param name="carType"></param>
        /// <param name="plateNumber"></param>
        public Car(string carType, string plateNumber, Image picture)
        {
            // TODO remove default value, use set property.
            CarPb = new PictureBox();
            this.Type = MovementType.Right;
            this.CarID = ++noOfOrdersCreated;
            this.CarType = carType;
            this.PlateNumber = plateNumber;
            isCarAvailable = true;
            //CarPb.BackColor = Color.Red;
            CarPb.Image = picture;
            CarPb.Height = 20;
            CarPb.Width = 20;
            CarPb.Location = new Point(this.PX, this.PY);
            CarPb.Visible = true;
            this.isPassengerPicked = Status.GoingToPickPassenger;
            Orderstatus = OrderStatus.Proceed;
            picked = true;
            IsDestinHotspot = true;
            IsGoingBack = false;
            label = new Label();
            label.Width = 70;
            label.Height = 20;
            label.BackColor = Color.White;
            label.Visible = true;
            label.Text = CarType;
            rand = new Random();
        }
        #endregion

        #region Public Methods

        /// <summary>
        /// Updating pictureBox location
        /// </summary>
        private void UpdatePbLocation()
        {
            this.CarPb.Location = new Point(this.PX, this.PY);
            label.Location = new Point(CarPb.Location.X - 5, CarPb.Location.Y - 15);
        }

        /// <summary>
        /// Algorithm for solving the movement of cars from different map points
        /// </summary>
        public void AlgorithmToDestination()
        {
            DirectionStor = new List<int[]>();

            tempDepartY = this.PY;
            tempDepartX = this.PX;
            //if(tempDepartY == 0)
            //{
            //    tempDepartY += 91;
            //}
            //if (tempDepartX == 0)
            //{
            //    tempDepartX += 261;
            //}
            //-------------------------------------------------------------------------
            int Ypoints = 0;

            if (DestinationHotspot.PY >= tempDepartY)
            {
                Ypoints = (DestinationHotspot.PY - tempDepartY) / VERTICAL;
                //Ypoints--;
            }
            else if (DestinationHotspot.PY <= tempDepartY)
            {
                Ypoints = (tempDepartY - DestinationHotspot.PY) / VERTICAL;
                //  Ypoints--;
            }
            //-------------------------------------------------------------------------------

            int Xpoints = 0;
            if (IsDestinHotspot == true)
            {
                if ((DestinationHotspot.PX + ((201 / 2) + 1)) >= tempDepartX)
                {
                    Xpoints = ((DestinationHotspot.PX + ((201 / 2) + 1)) - tempDepartX) / HORIZONTAL;
                    //  Xpoints--;
                }
                else if ((DestinationHotspot.PX + ((201 / 2) + 1)) <= tempDepartX)
                {
                    Xpoints = (tempDepartX - (DestinationHotspot.PX + ((201 / 2) + 1))) / HORIZONTAL;
                    // Xpoints--;
                }
            }
            else
            {
                if (DestinationHotspot.PX >= tempDepartX)
                {
                    Xpoints = (DestinationHotspot.PX - tempDepartX) / HORIZONTAL;
                    //  Xpoints--;
                }
                else if (DestinationHotspot.PX <= tempDepartX)
                {
                    Xpoints = (tempDepartX - DestinationHotspot.PX) / HORIZONTAL;
                    // Xpoints--;
                }
            }
            //Ypoints = 3;
            //Xpoints = 2;////remove these because its for testing
            int[] direction = new int[Ypoints + Xpoints];
            //-----------------------------------------------------------------------------
            #region Combination Algorithm

            //int combination=1;
            //for (int i = 0;i<(Ypoints+Xpoints);i++)
            //{
            //    combination *= (Ypoints + Xpoints) - i;

            //}
            //int divide = 1;
            //for (int i = 0; i < Xpoints; i++)
            //{
            //    divide *= (Xpoints - i);
            //}
            //int n_rPermutatie = 1;
            //for (int i = 0; i < ((Ypoints + Xpoints) - Xpoints); i++)
            //{
            //    n_rPermutatie *= ((Ypoints + Xpoints) - Xpoints) - i;
            //}
            //divide *= n_rPermutatie;
            //combination = combination / divide;
            #endregion
            //---------------------------------------------------------------------------
            //this is the beginning of the algorithm
            if (tempDepartY <= DestinationHotspot.PY && tempDepartX <= DestinationHotspot.PX)
            {
                pointToPoint = "UL-LR";
            }
            else if (tempDepartY <= DestinationHotspot.PY && tempDepartX >= DestinationHotspot.PX)
            {
                pointToPoint = "UR-LL";
            }
            else if (tempDepartY >= DestinationHotspot.PY && tempDepartX <= DestinationHotspot.PX)
            {
                pointToPoint = "LL-UR";
            }
            else if (tempDepartY >= DestinationHotspot.PY && tempDepartX >= DestinationHotspot.PX)
            {
                pointToPoint = "LR-UL";
            }

            //if (tempDepartY <= DestinationHotspot.PY && tempDepartX<=DestinationHotspot.PX)
            //{

            int count = 0;
            //if (Ypoints > 0 )
            //{
            for (int i = 0; i < Ypoints; i++)
            {
                //tempDepartY += VERTICAL;
                direction[i] = VERTICAL;
                count = i;
            }
            if (Ypoints > 0)
                count++;

            for (int i = 0; i < Xpoints; i++)
            {
                direction[count + i] = HORIZONTAL;
            }
            DirectionStor.Add(direction);
            
            bool CanCombine = false;
            int v = 0, h = 0;
            for (int i = 0; i < DirectionStor[0].Length; i++)
            {
                if (DirectionStor[0][i] == VERTICAL)
                {
                    v++;
                }
                else if (DirectionStor[0][i] == HORIZONTAL)
                {
                    h++;
                }
                if (v > 0 && h > 0)
                {
                    CanCombine = true;
                    break;
                }
            }
            if (CanCombine == true)
            {
                for (int y = 1; y < DirectionStor[0].Length; y++)
                {
                    if (DirectionStor[DirectionStor.Count - 1][DirectionStor[0].Length - (1 + y)] == HORIZONTAL)
                    {
                        continue;
                    }
                    else if (DirectionStor[DirectionStor.Count - 1][DirectionStor[0].Length - (1 + y)] == VERTICAL)
                    {
                        int[] tempArr = new int[Ypoints + Xpoints];
                        for (int b = 0; b < DirectionStor[0].Length; b++)
                        {
                            tempArr[b] = DirectionStor[DirectionStor.Count - 1][b];
                        }

                        tempArr[DirectionStor[DirectionStor.Count - 1].Length - (1 + y)] = HORIZONTAL;
                        tempArr[DirectionStor[DirectionStor.Count - 1].Length - y] = VERTICAL;
                        DirectionStor.Add(tempArr);
                    }
                }
            }

            //This one is the same as above but for the Xpoint
            count = 0;
            direction = new int[Ypoints + Xpoints];
            for (int i = 0; i < Xpoints; i++)
            {
                direction[i] = HORIZONTAL;
                count = i;
            }
            if (Xpoints > 0)
                count++;

            for (int i = 0; i < Ypoints; i++)
            {
                direction[count + i] = VERTICAL;
            }
            DirectionStor.Add(direction);

            if (DirectionStor.Count > 0)
            {
                Random rnd = new Random();
                DirectionTaken = DirectionStor[rnd.Next(0, DirectionStor.Count)];
            }
            if (IsDestinHotspot == false)
            {
                IsDestinHotspot = true;
            }
        }

        // Movement of the car
        public void Move(List<Hotspot> EndHotspots, List<Hotspot> Hotspots)
        {
            if (DirectionTaken != null)
            {
                #region upper left - lower right
                if (pointToPoint == "UL-LR")
                {
                    //Write here to add the extra points when taking a left turn
                    for (int i = 0; i < DirectionTaken.Length; i++)
                    {
                        if (DirectionTaken[i] == VERTICAL)
                        {
                            this.PY += 1;//7
                           // CarPb.Location = new Point(this.PX, this.PY);
                            if (this.PY % VERTICAL == 0)//DirectionTaken[i] can be also replaced by VERTICAL (that is because we confirmed with the checking that DirectionTaken[i] == VERTICAL, so its the same)
                            {
                                DirectionTaken[i] = 0;
                                if (Orderstatus == OrderStatus.Cancel || Orderstatus == OrderStatus.Change ||Orderstatus == OrderStatus.CancelBeforePicking)
                                {
                                    DirectionTaken = null;
                                    DepartureHotspot = DestinationHotspot;
                                    if (IsGoingBack == true)
                                    {
                                        isCarAvailable = true;
                                        IsGoingBack = false;
                                        isPassengerPicked = 0;
                                    }
                                    label.Text = "GET OUT!";
                                    if (Orderstatus == OrderStatus.Change)
                                    {
                                        label.Text = "Change!?";
                                        isPassengerPicked--;
                                    }
                                    else if(Orderstatus== OrderStatus.CancelBeforePicking)
                                    {
                                        label.Text = "#!@-$#!";
                                        isPassengerPicked = Status.PickedPassenger;
                                    }
                                    //label.Location = new Point(CarPb.Location.X - 5, CarPb.Location.Y - 15);
                                    //label.Visible = true;
                                    return;
                                }
                                
                            }
                            return;
                        }
                        else if (DirectionTaken[i] == HORIZONTAL)
                        {
                            this.PX += 1; //87
                            //CarPb.Location = new Point(this.PX, this.PY);
                            if (this.PX % HORIZONTAL == 0)//Check comment above for vertical. Same counts for Horizontal that DirectionTaken[i] can be replaced by HORIZONTAL
                            {
                                DirectionTaken[i] = 0;
                                if (Orderstatus == OrderStatus.Cancel || Orderstatus == OrderStatus.Change || Orderstatus == OrderStatus.CancelBeforePicking)
                                {
                                    DirectionTaken = null;
                                    DepartureHotspot = DestinationHotspot;
                                    if (IsGoingBack == true)
                                    {
                                        isCarAvailable = true;
                                        IsGoingBack = false;
                                        isPassengerPicked = 0;
                                    }
                                    label.Text = "GET OUT!";
                                    if (Orderstatus == OrderStatus.Change)
                                    {
                                        label.Text = "Change!?";
                                        isPassengerPicked--;
                                    }
                                    else if (Orderstatus == OrderStatus.CancelBeforePicking)
                                    {
                                        label.Text = "#!@-$#!";
                                        isPassengerPicked = Status.PickedPassenger;
                                    }
                                    //label.Location = new Point(CarPb.Location.X - 5, CarPb.Location.Y - 15);
                                    //label.Visible = true;
                                    return;
                                }
                            }
                            return;
                        }
                        else
                        {
                            if (i == DirectionTaken.Length - 1 )
                            {
                                
                                //isPassengerPicked++;
                                DirectionTaken = null;
                                DepartureHotspot = DestinationHotspot;
                                if (IsGoingBack == true)
                                {
                                    isCarAvailable = true;
                                    IsGoingBack = false;
                                    isPassengerPicked = 0;
                                }
                                //if (Orderstatus == OrderStatus.Cancel)
                                //{
                                //    label.Text = "GET OUT!";
                                //    label.Location = new Point(CarPb.Location.X - 5, CarPb.Location.Y - 15);
                                //    label.Visible = true;
                                //}
                                //WaitForPassenger();

                                //if (isPassengerPicked == Status.PickedPassenger)
                                //    {
                                //        DestinationHotspot = EndHotspots[rand.Next(0, EndHotspots.Count)];
                                //        while (DestinationHotspot == DepartureHotspot)
                                //        {
                                //            DestinationHotspot = EndHotspots[rand.Next(0, EndHotspots.Count)];
                                //        }
                                //        AlgorithmToDestination();
                                //    }
                                //    else if (isPassengerPicked == Status.DroppedPassenger)
                                //    {
                                //        DestinationHotspot = Hotspots[rand.Next(0, Hotspots.Count)];
                                //        IsDestinHotspot = false;
                                //        AlgorithmToDestination();
                                //    }
                                //else if (isPassengerPicked == Status.ResetToHotspot)
                                //{

                                //}

                                return;
                            }

                            continue;
                        }

                    }
                }
                #endregion
                #region upper right - lower left
                //this is if depart location is upper right and destination is lower left
                else if (pointToPoint == "UR-LL")
                {
                    //Write here to add the extra points when taking a left turn
                    for (int i = 0; i < DirectionTaken.Length; i++)
                    {
                        if (DirectionTaken[i] == VERTICAL)
                        {
                            //this.PY += 7;
                            this.PY += 1;
                           // CarPb.Location = new Point(this.PX, this.PY);
                            if (this.PY % VERTICAL == 0)
                            {
                                DirectionTaken[i] = 0;
                                if (Orderstatus == OrderStatus.Cancel || Orderstatus == OrderStatus.Change || Orderstatus == OrderStatus.CancelBeforePicking)
                                {
                                    DirectionTaken = null;
                                    DepartureHotspot = DestinationHotspot;
                                    if (IsGoingBack == true)
                                    {
                                        isCarAvailable = true;
                                        IsGoingBack = false;
                                        isPassengerPicked = 0;
                                    }
                                    label.Text = "GET OUT!";
                                    if (Orderstatus == OrderStatus.Change)
                                    {
                                        label.Text = "Change!?";
                                        isPassengerPicked--;
                                    }
                                    else if (Orderstatus == OrderStatus.CancelBeforePicking)
                                    {
                                        label.Text = "#!@-$#!";
                                        isPassengerPicked = Status.PickedPassenger;
                                    }
                                    //label.Location = new Point(CarPb.Location.X - 5, CarPb.Location.Y - 15);
                                    //label.Visible = true;
                                    return;
                                }
                            }
                            return;
                        }
                        else if (DirectionTaken[i] == HORIZONTAL)
                        {
                            //this.PX -= 87;
                            this.PX -= 1;
                           // CarPb.Location = new Point(this.PX, this.PY);
                            if (this.PX % HORIZONTAL == 0)
                            {
                                DirectionTaken[i] = 0;
                                if (Orderstatus == OrderStatus.Cancel || Orderstatus == OrderStatus.Change || Orderstatus == OrderStatus.CancelBeforePicking)
                                {
                                    DirectionTaken = null;
                                    DepartureHotspot = DestinationHotspot;
                                    if (IsGoingBack == true)
                                    {
                                        isCarAvailable = true;
                                        IsGoingBack = false;
                                        isPassengerPicked = 0;
                                    }
                                    label.Text = "GET OUT!";
                                    if (Orderstatus == OrderStatus.Change)
                                    {
                                        label.Text = "Change!?";
                                        isPassengerPicked--;
                                    }
                                    else if (Orderstatus == OrderStatus.CancelBeforePicking)
                                    {
                                        label.Text = "#!@-$#!";
                                        isPassengerPicked = Status.PickedPassenger;
                                    }
                                    //label.Location = new Point(CarPb.Location.X - 5, CarPb.Location.Y - 15);
                                    //label.Visible = true;
                                    return;
                                }
                            }
                            return;
                        }
                        else
                        {
                            if (i == DirectionTaken.Length - 1)
                            {
                                // isPassengerPicked++;
                                DirectionTaken = null;
                                DepartureHotspot = DestinationHotspot;
                                if (IsGoingBack == true)
                                {
                                    isCarAvailable = true;
                                    IsGoingBack = false;
                                    isPassengerPicked = 0;
                                }
                                //if (Orderstatus == OrderStatus.Cancel)
                                //{
                                //    label.Text = "GET OUT!";
                                //    label.Location = new Point(CarPb.Location.X - 5, CarPb.Location.Y - 15);
                                //    label.Visible = true;
                                //}
                                //WaitForPassenger();

                                //if (isPassengerPicked == Status.PickedPassenger)
                                //{
                                //    DestinationHotspot = EndHotspots[rand.Next(0, EndHotspots.Count)];
                                //    while (DestinationHotspot == DepartureHotspot)
                                //    {
                                //        DestinationHotspot = EndHotspots[rand.Next(0, EndHotspots.Count)];
                                //    }
                                //    AlgorithmToDestination();
                                //}
                                //else if (isPassengerPicked == Status.DroppedPassenger)
                                //{
                                //    DestinationHotspot = Hotspots[rand.Next(0, Hotspots.Count)];
                                //    IsDestinHotspot = false;
                                //    AlgorithmToDestination();
                                //}
                                //else if (isPassengerPicked == Status.ResetToHotspot)
                                //{

                                //}

                                return;
                            }
                            continue;
                        }

                    }
                }
                #endregion
                #region lower left - upper right
                //this is if depart location is lower left and destination is upper right
                else if (pointToPoint == "LL-UR")
                {
                    //Write here to add the extra points when taking a left turn
                    for (int i = 0; i < DirectionTaken.Length; i++)
                    {
                        if (DirectionTaken[i] == VERTICAL)
                        {
                            //this.PY -= 7;
                            this.PY -= 1;
                           // CarPb.Location = new Point(this.PX, this.PY);
                            if (this.PY % VERTICAL == 0)
                            {
                                DirectionTaken[i] = 0;
                                if (Orderstatus == OrderStatus.Cancel || Orderstatus == OrderStatus.Change || Orderstatus == OrderStatus.CancelBeforePicking)
                                {
                                    DirectionTaken = null;
                                    DepartureHotspot = DestinationHotspot;
                                    if (IsGoingBack == true)
                                    {
                                        isCarAvailable = true;
                                        IsGoingBack = false;
                                        isPassengerPicked = 0;
                                    }
                                    label.Text = "GET OUT!";
                                    if (Orderstatus == OrderStatus.Change)
                                    {
                                        label.Text = "Change!?";
                                        isPassengerPicked--;
                                    }
                                    else if (Orderstatus == OrderStatus.CancelBeforePicking)
                                    {
                                        label.Text = "#!@-$#!";
                                        isPassengerPicked = Status.PickedPassenger;
                                    }
                                    //label.Location = new Point(CarPb.Location.X - 5, CarPb.Location.Y - 15);
                                    //label.Visible = true;
                                    return;
                                }
                            }
                            return;
                        }
                        else if (DirectionTaken[i] == HORIZONTAL)
                        {
                            //this.PX += 87;
                            this.PX += 1;
                        //    CarPb.Location = new Point(this.PX, this.PY);
                            if (this.PX % HORIZONTAL == 0)
                            {
                                DirectionTaken[i] = 0;
                                if (Orderstatus == OrderStatus.Cancel|| Orderstatus == OrderStatus.Change || Orderstatus == OrderStatus.CancelBeforePicking)
                                {
                                    DirectionTaken = null;
                                    DepartureHotspot = DestinationHotspot;
                                    if (IsGoingBack == true)
                                    {
                                        isCarAvailable = true;
                                        IsGoingBack = false;
                                        isPassengerPicked = 0;
                                    }
                                    label.Text = "GET OUT!";
                                    if (Orderstatus == OrderStatus.Change)
                                    {
                                        label.Text = "Change!?";
                                        isPassengerPicked--;
                                    }
                                    else if (Orderstatus == OrderStatus.CancelBeforePicking)
                                    {
                                        label.Text = "#!@-$#!";
                                        isPassengerPicked = Status.PickedPassenger;
                                    }
                                    //label.Location = new Point(CarPb.Location.X - 5, CarPb.Location.Y - 15);
                                    //label.Visible = true;
                                    return;
                                }
                            }
                            return;
                        }
                        else
                        {
                            if (i == DirectionTaken.Length - 1)
                            {
                                // isPassengerPicked++;
                                DirectionTaken = null;
                                DepartureHotspot = DestinationHotspot;
                                if (IsGoingBack == true)
                                {
                                    isCarAvailable = true;
                                    IsGoingBack = false;
                                    isPassengerPicked = 0;
                                }
                                //if (Orderstatus == OrderStatus.Cancel)
                                //{
                                //    label.Text = "GET OUT!";
                                //    label.Location = new Point(CarPb.Location.X - 5, CarPb.Location.Y - 15);
                                //    label.Visible = true;
                                //}
                                //WaitForPassenger();

                                //if (isPassengerPicked == Status.PickedPassenger)
                                //{
                                //    DestinationHotspot = EndHotspots[rand.Next(0, EndHotspots.Count)];
                                //    while (DestinationHotspot == DepartureHotspot)
                                //    {
                                //        DestinationHotspot = EndHotspots[rand.Next(0, EndHotspots.Count)];
                                //    }
                                //    AlgorithmToDestination();
                                //}
                                //else if (isPassengerPicked == Status.DroppedPassenger)
                                //{
                                //    DestinationHotspot = Hotspots[rand.Next(0, Hotspots.Count)];
                                //    IsDestinHotspot = false;
                                //    AlgorithmToDestination();
                                //}
                                //else if (isPassengerPicked == Status.ResetToHotspot)
                                //{

                                //}

                                return;
                            }
                            continue;
                        }

                    }
                }
                #endregion
                #region lower right - upper left
                //this is if depart location is lower right and destination is upper left
                else if (pointToPoint == "LR-UL")
                {
                    //Write here to add the extra points when taking a left turn
                    for (int i = 0; i < DirectionTaken.Length; i++)
                    {
                        if (DirectionTaken[i] == VERTICAL)
                        {
                            //this.PY -= 7;
                            this.PY -= 1;
                         //   CarPb.Location = new Point(this.PX, this.PY);
                            if (this.PY % VERTICAL == 0)
                            {
                                DirectionTaken[i] = 0;
                                if (Orderstatus == OrderStatus.Cancel || Orderstatus == OrderStatus.Change || Orderstatus == OrderStatus.CancelBeforePicking)
                                {
                                    DirectionTaken = null;
                                    DepartureHotspot = DestinationHotspot;
                                    if (IsGoingBack == true)
                                    {
                                        isCarAvailable = true;
                                        IsGoingBack = false;
                                        isPassengerPicked = 0;
                                    }
                                    label.Text = "GET OUT!";
                                    if (Orderstatus == OrderStatus.Change)
                                    {
                                        label.Text = "Change!?";
                                        isPassengerPicked--;
                                    }
                                    else if (Orderstatus == OrderStatus.CancelBeforePicking)
                                    {
                                        label.Text = "#!@-$#!";
                                        isPassengerPicked = Status.PickedPassenger;
                                    }
                                    //label.Location = new Point(CarPb.Location.X - 5, CarPb.Location.Y - 15);
                                    //label.Visible = true;
                                    return;
                                }
                            }
                            return;
                        }
                        else if (DirectionTaken[i] == HORIZONTAL)
                        {
                            //this.PX -= 87;
                            this.PX -= 1;
                          //  CarPb.Location = new Point(this.PX, this.PY);
                            if (this.PX % HORIZONTAL == 0)
                            {
                                DirectionTaken[i] = 0;
                                if (Orderstatus == OrderStatus.Cancel || Orderstatus == OrderStatus.Change || Orderstatus == OrderStatus.CancelBeforePicking)
                                {
                                    DirectionTaken = null;
                                    DepartureHotspot = DestinationHotspot;
                                    if (IsGoingBack == true)
                                    {
                                        isCarAvailable = true;
                                        IsGoingBack = false;
                                        isPassengerPicked = 0;
                                    }
                                    label.Text = "GET OUT!";
                                    if (Orderstatus == OrderStatus.Change)
                                    {
                                        label.Text = "Change!?";
                                        isPassengerPicked--;
                                    }
                                    else if (Orderstatus == OrderStatus.CancelBeforePicking)
                                    {
                                        label.Text = "#!@-$#!";
                                        isPassengerPicked = Status.PickedPassenger;
                                    }
                                    //label.Location = new Point(CarPb.Location.X - 5, CarPb.Location.Y - 15);
                                    //label.Visible = true;
                                    return;
                                }
                            }
                            return;
                        }
                        else
                        {
                            if (i == DirectionTaken.Length - 1)
                            {
                                // isPassengerPicked++;
                                DirectionTaken = null;
                                DepartureHotspot = DestinationHotspot;
                                if (IsGoingBack == true)
                                {
                                    isCarAvailable = true;
                                    IsGoingBack = false;
                                    isPassengerPicked = 0;
                                }
                                //if (Orderstatus == OrderStatus.Cancel)
                                //{
                                //    label.Text = "GET OUT!";
                                //    label.Location = new Point(CarPb.Location.X - 5, CarPb.Location.Y - 15);
                                //    label.Visible = true;
                                //}
                                //WaitForPassenger();
                                //if (isPassengerPicked == Status.PickedPassenger)
                                //{
                                //    DestinationHotspot = EndHotspots[rand.Next(0, EndHotspots.Count)];
                                //    while (DestinationHotspot == DepartureHotspot)
                                //    {
                                //        DestinationHotspot = EndHotspots[rand.Next(0, EndHotspots.Count)];
                                //    }
                                //    AlgorithmToDestination();
                                //}
                                //else if (isPassengerPicked == Status.DroppedPassenger)
                                //{
                                //    DestinationHotspot = Hotspots[rand.Next(0, Hotspots.Count)];
                                //    IsDestinHotspot = false;
                                //    AlgorithmToDestination();
                                //}
                                //else if (isPassengerPicked == Status.ResetToHotspot)
                                //{

                                //}

                                return;
                            }
                            continue;
                        }

                    }
                }
                #endregion
            }
            else
            {
                waitCounter++;
                if (waitCounter < 200)
                {
                    return;
                }
                waitCounter = 0;
                label.Text = CarType;

            }
            isPassengerPicked++;
            if (isPassengerPicked == Status.PickedPassenger)
            {
                picked = true;
                DestinationHotspot = EndHotspots[rand.Next(0, EndHotspots.Count)];
                while (DestinationHotspot == DepartureHotspot)
                {
                    DestinationHotspot = EndHotspots[rand.Next(0, EndHotspots.Count)];

                }

                Orderstatus = OrderStatus.Proceed;
                AlgorithmToDestination();
            }
            else if (isPassengerPicked == Status.DroppedPassenger)
            {
                DestinationHotspot = Hotspots[rand.Next(0, Hotspots.Count)];
                /* Code for checking whether the current capacity of Hotspot is equal to MaxCapacity  */
               DestinationHotspot.CurrentCapacity++;

                while (DestinationHotspot.CurrentCapacity > DestinationHotspot.MaxCapacity)
                {
                    DestinationHotspot.CurrentCapacity--;
                    DestinationHotspot = Hotspots[rand.Next(0, Hotspots.Count)];
                    DestinationHotspot.CurrentCapacity++;
                    DestinationHotspot.ToString();
                }

                IsDestinHotspot = false;
                IsGoingBack = true;
                Orderstatus = OrderStatus.Proceed;
                AlgorithmToDestination();
            }
        }

        /// <summary>
        /// Method for waiting for passanger board in
        /// </summary>
        private void WaitForPassenger()
        {
            Thread.Sleep(5000);

        }

        /// <summary>
        /// Displays car infos
        /// </summary>
        /// <returns></returns>
        public String AsAString()
        {
            string carInfo = "";
            carInfo = CarID + ", " + CarType + ", " + PlateNumber;
            return carInfo;
        }
        #endregion
    }
}
