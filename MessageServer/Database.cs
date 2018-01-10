using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

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

        public void WriteToDatabase(Message m)
        {
            MySqlConnection conn;
            MySqlCommand comm;
            MySqlDataReader reader;
            string Query = "insert into loketdb.message(Applicatie,Tijdstip,Loglevel,Locatie,Data) values('" + m.Applicatie + "','" + m.Tijdstip + "','" + m.Loglevel + "','" + m.Locatie + "','" + m.Data + "');";
            string connectionString = "server=127.0.0.1;uid=Yannick;pwd=test;database=loketdb";
            
            
            try
            {
                conn = new MySqlConnection(connectionString);
                comm = new MySqlCommand(Query, conn);
                conn.Open();
                Console.WriteLine("Connection open");
                reader = comm.ExecuteReader();
                conn.Close();
                Console.WriteLine("Connection closed");
            }
            catch(MySqlException ex)
            {
                Console.Write(ex.ToString());
            }
        }
    }
}
