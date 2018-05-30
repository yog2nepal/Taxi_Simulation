using MySql.Data.MySqlClient;
using Service_ProCp.Models;
using System;
using System.Collections.Generic;
using System.Transactions;

/* This Class is meant for connecting the database, writing on database as well as reading with datbase */
namespace Service_ProCp.BusinessLogic
{
    public class DataHelper
    {
        /*Start of Class Members */
        //Attribute
        //   private string connectionInfo;
        private string dBConnstring;
        private MySqlConnection connectionToDB;
        // private Car car;
        //private Order order;

        /// <summary>
        /// constructor of the class, connects to iris server 
        /// </summary>
        public DataHelper()
        {
            connectionToDB = new MySqlConnection();
            dBConnstring = "server = studmysql01.fhict.local; " + "Uid = dbi341965; " + "Database = dbi341965; " + "Pwd = Fontys123; ";
        }

        /// <summary>
        /// Boolen Method to check the database connection, if its false, it opens and return true
        /// </summary>
        /// <returns></returns>
        public bool DatabaseConnection()
        {
            //creating database connection
            bool result = false;
            try
            {
                connectionToDB.ConnectionString = dBConnstring;
                connectionToDB.Open();
                result = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception Message: " + ex.Message);
                result = false;
                connectionToDB.Close();
            }
            return result;
        }

        public void CloseDatabase()
        {
            connectionToDB.Close();
        }

        public void WriteToBase(List<Car> myCar)
        {
            //Create Connection
            using (TransactionScope scope = new TransactionScope())
            {
                if (DatabaseConnection())
                {
                    for (int i = 0; i < myCar.Count; i++)
                    {
                        string sqlIns = "INSERT INTO dbi341965.car (car_id, car_type, car_number)  VALUES (@name, @cartype, @number)";
                        MySqlCommand cmdIns = new MySqlCommand(sqlIns, connectionToDB);
                        cmdIns.Parameters.AddWithValue("@name", myCar[i].CarID);
                        cmdIns.Parameters.AddWithValue("@cartype", myCar[i].CarType);
                        cmdIns.Parameters.AddWithValue("@number", myCar[i].PlateNumber);
                        cmdIns.ExecuteNonQuery();
                    }
                    scope.Complete();
                }
            }
        }
    }
}

/* End of DataBase Class */
