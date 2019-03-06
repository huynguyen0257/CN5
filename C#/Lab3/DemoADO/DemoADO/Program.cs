using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoADO
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("********** Fun with ***********");

            //Create a connection string via the builder object.
            SqlConnectionStringBuilder cnStrBuilder = new SqlConnectionStringBuilder();
            cnStrBuilder.UserID = "sa";
            cnStrBuilder.Password = "1234";
            cnStrBuilder.InitialCatalog = "Cars";
            cnStrBuilder.DataSource = @"DESKTOP-MHPMKMP\SQLEXPRESS";
            cnStrBuilder.ConnectTimeout = 5;

            //Create and open a connection.
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = cnStrBuilder.ConnectionString;    
            cn.Open();
            //ShowConnectionStatus(cn);
            Console.WriteLine("**** Exected Connection Successful! *****");


            

            //Create a SQL command object
            string strSQL = "SELECT * FROM Inventory";
            SqlCommand myCommand = new SqlCommand(strSQL, cn);

            //Obtain a data reader ala ExecuteReader().
            SqlDataReader myDataReader;
            myDataReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection);

            //Loop over the results
            while (myDataReader.Read())
            {
                for (int i = 0; i < myDataReader.FieldCount; i++)
                {
                    Console.Write("{0} = {1} ;", myDataReader.GetName(i), myDataReader.GetValue(i).ToString().Trim());
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            Console.WriteLine();
            //Because we specified CommandBehavior.CloseConnection, We
            //Don't need to explicitly call Close() on the connection
            myDataReader.Close();
        }
    }
}
