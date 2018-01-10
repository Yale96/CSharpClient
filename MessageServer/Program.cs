using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace MessageServer
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Run(args);
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e);
            }
        }

        static void Run(string[] args)
        {
            TcpListener listener = new TcpListener(8080);
            listener.Start();

            while (true)
            {
                
                using (TcpClient client = listener.AcceptTcpClient())
                {
                    try
                    {
                        Read(client);
                    }
                    catch (Exception e)
                    {
                        Console.Error.WriteLine(e);
                    }
                }
            }
        }

        static void Read(TcpClient client)
        {
            Database db = new Database();
            Console.WriteLine("Got connection: {0}", DateTime.Now);
            NetworkStream ns = client.GetStream();
            BinaryReader reader = new BinaryReader(ns);

            Message msg = new Message();
            //// first read the Id
            //msg.Id = reader.ReadInt32();

            // length of content in bytes.
            int length = reader.ReadInt32();

            // read the content bytes into the byte array.
            // recall that java side is writing two bytes for every character.
            byte[] contentArray = reader.ReadBytes(length);
            msg = JsonConvert.DeserializeObject<Message>(Encoding.UTF8.GetString(contentArray));
            //msg.Content = Encoding.UTF8.GetString(contentArray);
                        
            Console.WriteLine(msg.Applicatie);
            Console.WriteLine(msg.Tijdstip);
            Console.WriteLine(msg.Loglevel);
            Console.WriteLine(msg.Locatie);
            Console.WriteLine(msg.Data);

            db.WriteToFile(msg.ToString());
            Console.WriteLine("Writing data to file is done");
            db.WriteToDatabase(msg);
            Console.WriteLine("Writing data to DB is done");

            client.Client.Shutdown(SocketShutdown.Both);
            ns.Close();
        }
    }
}

