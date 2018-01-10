using System;
using System.Collections.Generic;
using System.Text;

namespace MessageServer
{
    class Database
    {
        public Database()
        {

        }

        public void WriteToFile(string content)
        {
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(@"E:\test.txt"))
            {

                file.WriteLine(content);
            }
        }

        public void WriteToDatabase()
        {
            MySql.Data.MySqlClient.MySqlConnection conn;
            string connectionString = "server=127.0.0.1;uid=Yannick;pwd=test;database=loketdb";
            
            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection(connectionString);
                conn.Open();
                System.Console.WriteLine("Connection open");
                conn.Close();
                System.Console.WriteLine("Connection closed");
            }
            catch(MySql.Data.MySqlClient.MySqlException ex)
            {
                System.Console.Write(ex.ToString());
            }
        }
    }
}
