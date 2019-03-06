using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo2_Menu
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("******* Car Inventory Updater *******");
            bool userDone = false;
            string userCommand = "";

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = "uid=sa;pwd=1234;Initial Catalog=Cars; Data Source=DESKTOP-MHPMKMP\\SQLEXPRESS;Connect Timeout=30";
            cn.Open();

            ShowInstructions();

            #region Get User Command
            do
            {
                Console.WriteLine("Please enter your command: ");
                userCommand = Console.ReadLine();
                Console.WriteLine();
                switch (userCommand.ToUpper())
                {
                    case "I":

                        break;
                    case "U":

                        break;
                    case "D":

                        break;
                    case "L":

                        break;
                    case "S":

                        break;
                    case "P":

                        break;
                    default:
                        break;
                }
            } while (true);
        }

        #region ShowInstruction method
        private static void ShowInstructions()
        {
            Console.WriteLine();
            Console.WriteLine("I: Insert a new car.");
            Console.WriteLine("U: Update an existing car.");
            Console.WriteLine("D: Deletes an existing car.");
            Console.WriteLine("L: List current inventory.");
            Console.WriteLine("S: Show these instructions.");
            Console.WriteLine("P: Look up pet name for existing car.");
            Console.WriteLine("Q: Quít program.");
        }
        #endregion

        private static void ListInventory(SqlConnection cn)
        {
            string strSQL = "Select * From Inventory";
            SqlCommand myCommand = new SqlCommand(strSQL, cn);

            SqlDataReader myDataReader;
            myDataReader = myCommand.ExecuteReader();

            while (myDataReader.Read())
            {
                for (int i = 0; i < myDataReader.FieldCount; i++)
                {
                    Console.WriteLine("{0} = {1} ;" ,
                        myDataReader.GetName(i).Trim(),
                        myDataReader.GetValue(i).ToString().Trim());
                }
                Console.WriteLine();
            }
            myDataReader.Close();
        }
        private static void InsertNewCar(SqlConnection cn)
        {
            //Gather info about new car
            Console.Write("Enter CarID: ");
            int newCarID = 0;
            try
            {
                newCarID = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Bad input!   Canceling request");
                return;
            }
            Console.Write("Enter Make: ");
            string newCarMake = Console.ReadLine();
            Console.Write("Enter Color: ");
            string newCarColor = Console.ReadLine();
            Console.Write("Enter PetName: ");
            string newCarPetName = Console.ReadLine();
            //Format and execute SQL statement.
            string sql = string.Format("Insert Into inventory" +
                "(CarID, Make, Color, PetName) Values" +
                "'{0}', '{1}', '{2}', '{3}')", newCarID, newCarMake, newCarColor, newCarPetName);
            SqlCommand cmd = new SqlCommand(sql, cn);

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch 
            {
                Console.WriteLine("Bad input!   Canceling Request");
                return;
            }
        }
        private static void InsertNewCar_Parameteried(SqlConnection cn)
        {
            //Gather info about new car
            Console.Write("Enter CarID: ");
            int newCarID = 0;
            try
            {
                newCarID = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Bad input!   Canceling request");
                return;
            }
            Console.Write("Enter Make: ");
            string newCarMake = Console.ReadLine();
            Console.Write("Enter Color: ");
            string newCarColor = Console.ReadLine();
            Console.Write("Enter PetName: ");
            string newCarPetName = Console.ReadLine();
            //Format and execute SQL statement.
            string sql = string.Format("Insert Into inventory" +
                "(CarID, Make, Color, PetName) Values" +
                "'@CarID', '@Make', '@Color', '@PetName')");
            SqlCommand cmd = new SqlCommand(sql, cn);

            //Fill params collection
            SqlParameter param = new SqlParameter();
            param.ParameterName = "@CarID";
            param.Value = newCarID;
            param.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@Make";
            param.Value = newCarMake;
            param.SqlDbType = SqlDbType.Char;
            param.Size = 20;
            cmd.Parameters.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@Color";
            param.Value = newCarColor;
            param.SqlDbType = SqlDbType.Char;
            param.Size = 20;
            cmd.Parameters.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@PetName";
            param.Value = newCarPetName;
            param.SqlDbType = SqlDbType.Char;
            param.Size = 20;
            cmd.Parameters.Add(param);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Bad input!   Canceling Request");
                return;
            }
        }

        private static void UpdateCarPetName(SqlConnection cn)
        {
            int carToUpdate = 0;
            string newPetName = "";

            Console.Write("Enter CarID of car to modify: ");
            try
            {
                carToUpdate = int.Parse(Console.ReadLine());
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
            string sql = string.Format("Update Inventory Set PetName = '{0}' Where CarID = '{1}'",
                newPetName, carToUpdate);
            SqlCommand cmd = new SqlCommand(sql, cn);
            cmd.ExecuteNonQuery();
        }

        private static void DeleteCar(SqlConnection cn)
        {
            //get ID of car to delete
            int carToDelete = 0;
            Console.Write("Enter CarID of car to Delete: ");
            try
            {
                carToDelete = int.Parse(Console.ReadLine());
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
            string sql = string.Format("Delete from Inventory where CarID = '{0}'",
                carToDelete);
            SqlCommand cmd = new SqlCommand(sql, cn);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch 
            {
                Console.WriteLine("Sorry!   That car is on order!   Terminating Request..."); ;
            }
        }

        private static void LookUpPetName(SqlConnection cn)
        {
            //Get the CarID
            Console.Write("Enter CarID: ");
            int carID = int.Parse(Console.ReadLine());

            //Establish name of stored proc.
            SqlCommand cmd = new SqlCommand("GetPetName", cn);
            cmd.CommandType = CommandType.StoredProcedure;

            //Input params
            SqlParameter param = new SqlParameter();
            param.ParameterName = "@carID";
            param.SqlDbType = SqlDbType.Int;
            param.Value = carID;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            //Output param.
            param = new SqlParameter();
            param.ParameterName = "@petName";
            param.SqlDbType = SqlDbType.Char;
            param.Size = 20;
            param.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(param);

            //Execute the stored proc.
            cmd.ExecuteNonQuery();

            //Print output param
            Console.WriteLine("Pet name for car {0} is {1}",
                carID, cmd.Parameters["@petName"].Value);
        }
    }
}
