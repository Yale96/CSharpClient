using System;
using System.Collections.Generic;
using System.Text;

namespace MessageServer
{
    public class Message
    {
        public string Applicatie;
        public string Tijdstip;
        public string Loglevel;
        public string Locatie;
        public string Data;

        public Message()
        {

        }

        public override string ToString()
        {
            return "Applicatie: " + Applicatie + ", Tijdstip: " + Tijdstip + ", Loglevel: " + Loglevel + ", Locatie: " + Locatie + ", Data: " + Data;
        }
    }
}
