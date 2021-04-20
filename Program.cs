using System;
using System.Data.SqlClient;

namespace DBConnection
{
    class Program
    {
        static void Main(string[] args)
        {

            connect();
            Console.ReadKey();
            Console.WriteLine("Hello World!");

        }

        static void connect()
        {
            string constr;

            // for the connection to 
            // sql server database
            SqlConnection conn;

            // Data Source is the name of the 
            // server on which the database is stored.
            // The Initial Catalog is used to specify
            // the name of the database
            // The UserID and Password are the credentials
            // required to connect to the database.
            constr = @"Data Source=DESKTOP-SO8SNUH\SQLEXPRESS;Initial Catalog=EMPLOYEEDB;Integrated Security=True";

            conn = new SqlConnection(constr);

            // to open the connection
            conn.Open();

            Console.WriteLine("Connection Open!");

            SqlCommand cmd;

            // use to read a row in
            // table one by one
            SqlDataReader dreader;

            // to sore SQL command and
            // the output of SQL command
            string  output = "";

            SqlDataAdapter adap = new SqlDataAdapter();

            string sql1 = "";
            string sql2 = "";

//    ********************        INSERT OPERATION     *****************************************************

            // use the defined sql statement
            // against our database
            sql1 = "insert into department  values(8001, 'Embeded' , 'Belgium')";
          
            // use to execute the sql command so we 
            // are passing query and connection object
            cmd = new SqlCommand(sql1, conn);

            // associate the insert SQL 
            // command to adapter object
            adap.InsertCommand = new SqlCommand(sql1, conn);

            // use to execute the DML statement against
            // our database
            adap.InsertCommand.ExecuteNonQuery();

            Console.WriteLine("data inserted sucessfully");

            sql2 = "update department set dep_location='Italy' where articleID=6001";

            cmd = new SqlCommand(sql2, conn);

            // associate the insert SQL
            // command to adapter object
            adap.InsertCommand = new SqlCommand(sql2, conn);

            // use to execute the DML statement against 
            // our database 
            adap.InsertCommand.ExecuteNonQuery();

            Console.WriteLine("data Updated sucessfully");

            //    ********************        RETREIVE OPERATION     *****************************************************

            // use to fetch rwos from demo table
            sql1 = "Select * from department";

            // to execute the sql statement
            cmd = new SqlCommand(sql1, conn);

            // fetch all the rows 
            // from the demo table
            dreader = cmd.ExecuteReader();

            Console.WriteLine("To display table  values");

            // for one by one reading row
            while (dreader.Read())
            {
                output = output + dreader.GetValue(0) + " - " +
                                    dreader.GetValue(1)+" - "+ dreader.GetValue(2) + "\n";
            }

            // to display the output
            Console.Write(output);

            // to close all the objects
            dreader.Close();
            cmd.Dispose();


            // to close the connection
            conn.Close();
        }

    }
}
