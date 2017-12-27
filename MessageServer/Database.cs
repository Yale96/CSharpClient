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
    }
}
