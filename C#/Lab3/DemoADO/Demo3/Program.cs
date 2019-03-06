using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo3
{
    class Program
    {
        private string name;

        //The application wide DataSet
        public static DataSet dsCarInventory = new DataSet("CarsDatabase");

        //The application wide connection object
        public static SqlConnection cnObj = new SqlConnection(@"uid=sa;pwd=1234;Initial Catalog=Cars;Data Source=DESKTOP-MHPMKMP\SQLEXPRESS");

        public string Name { get => name; set => name = value; }

        static void Main(string[] args)
        {
            Console.WriteLine("********* Car Inventory Update (with DataSets) **********");
            bool userDone = false;
            string userCommand = "";

            //Create the adapter
            string str = @"uid=sa;pwd=1234;Initial Catalog=Cars;Data Source=DESKTOP-MHPMKMP\SQLEXPRESS";
            SqlDataAdapter dAdapter = new SqlDataAdapter("Select * From Inventory", str);
            SqlDataAdapter da = new SqlDataAdapter();
            //SqlCommandBuilder InvBuilder = new SqlCommandBuilder(dAdapter);

            //Fill the DataSet.
            dAdapter.Fill(dsCarInventory, "Inventory");
            Console.WriteLine("Fill successful!");

            #region Get User Command
            do
            {
                ShowInstructions();
                Console.WriteLine("Please enter your command: ");
                userCommand = Console.ReadLine();
                Console.WriteLine();
                switch (userCommand.ToUpper())
                {
                    case "I":
                        InsertNewCar();
                        break;
                    case "U":
                        UpdateCarPetName();
                        break;
                    case "D":
                        DeleteCar(da);
                        break;
                    case "L":
                        ListInventory(da);
                        break;
                    case "Q":
                        userDone = true;
                        break;
                    default:
                        userDone = false;
                        break;
                }
            } while (!userDone);
            #endregion



        }
        #region ShowInstruction method
        private static void ShowInstructions()
        {
            Console.WriteLine();
            Console.WriteLine("I: Insert a new car.");
            Console.WriteLine("U: Update an existing car.");
            Console.WriteLine("D: Deletes an existing car.");
            Console.WriteLine("L: List current inventory.");
            Console.WriteLine("Q: Quít program.");
        }
        #endregion

        private static void ListInventory(SqlDataAdapter dAdapter)
        {
            //Now get the new .NET 2.0 DataTableReader Type
            DataTableReader dtReader = dsCarInventory.Tables["Inventory"].CreateDataReader();

            //The DataTableReader works just like the DataReader.
            while (dtReader.Read())
            {
                for (int i = 0; i < dtReader.FieldCount; i++)
                {
                    Console.WriteLine("{0} = {1} ;",dtReader.GetName(i).Trim() , dtReader.GetValue(i).ToString().Trim());
                }
                Console.WriteLine();
            }
            dtReader.Close();
        }

        private static void InsertNewCar()
        {
            SqlDataAdapter dAdapter = new SqlDataAdapter();
            //Gather info about new car.*****************************************************************
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

            //Format SQL Insert and Plug into DataAdapter*****************************************************************
            string sql = string.Format("Insert Into Inventory" +
                "(CarID , Make , Color , PetName) Values" +
                "('{0}' , '{1}','{2}','{3}')", newCarID, newCarMake, newCarColor, newCarPetName);

            

            //Update Inventory Table with new row
            DataRow newCar = dsCarInventory.Tables["Inventory"].NewRow();
            newCar["CarID"] = newCarID;
            newCar["Make"] = newCarMake;
            newCar["Color"] = newCarColor;
            newCar["PetName"] = newCarPetName;
            dsCarInventory.Tables["Inventory"].Rows.Add(newCar);


            //dAdapter.InsertCommand = new SqlCommand(sql);
            //dAdapter.InsertCommand.Connection = cnObj;
            SqlCommand cmd = new SqlCommand(sql, cnObj);
            dAdapter.InsertCommand = cmd;
            try
            {
                dAdapter.Update(dsCarInventory.Tables["Inventory"]);
            }
            catch (Exception e)
            {
                Console.WriteLine("Sorry!   Error!  Canceling request " + e.Message);
            }
        }

        private static void UpdateCarPetName()
        {
            SqlDataAdapter dAdapter = new SqlDataAdapter();
            int carToUpdate = 0;
            string newPetName = "";

            Console.Write("Enter CarID of Car to Modify: ");
            try
            {
                carToUpdate = int.Parse(Console.ReadLine());
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }

            string sql = string.Format("Update Inventory Set PetName = '{0}' Where CarID = {1}", newPetName, carToUpdate);
            SqlCommand cmd = new SqlCommand(sql, cnObj);
            dAdapter.UpdateCommand = cmd;

            DataRow[] carRowToUpdate = dsCarInventory.Tables["Inventory"].Select(string.Format("CarId = {0}", carToUpdate));
            if(carRowToUpdate.Length !=0)
            {
                Console.Write("Enter New Pet Name : ");
                newPetName = Console.ReadLine();
                carRowToUpdate[0]["PetName"] = newPetName;
                try
                {
                    dAdapter.Update(dsCarInventory.Tables["Inventory"]);
                }
                catch
                {
                    Console.WriteLine("Sorry!   Error!  Canceling request");
                }
            }
            else
            {
                Console.WriteLine("Can not find CarID!");
                return;
            } 
        }

        private static void DeleteCar(SqlDataAdapter dAdapter)
        {
            //Get ID of car to delete, then do so.
            int carToDelete = 0;
            Console.Write("Enter CarID of car to delete: ");
            try
            {
                carToDelete = int.Parse(Console.ReadLine());
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
            string sql = string.Format("Delete from Inventory where CarID = '{0}'" , carToDelete);
            SqlCommand cmd = new SqlCommand(sql, cnObj);
            dAdapter.DeleteCommand = cmd;

            DataRow[] carRowToDelete = dsCarInventory.Tables["Inventory"].Select(string.Format("CarID = '{0}'", carToDelete));
            carRowToDelete[0].Delete();

            try
            {
                dAdapter.Update(dsCarInventory.Tables["Inventory"]);
            }
            catch 
            {
                Console.WriteLine("Sorry!   Error!  Canceling request");
            }
        }
    }
}