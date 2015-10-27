using System;
using System.Net;
using System.DirectoryServices;

namespace NetworkChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            var root = new DirectoryEntry("WinNT:");

            foreach (DirectoryEntry comps in root.Children)
            {
                foreach (DirectoryEntry c in comps.Children)
                {
                    if (c.Name != "Schema")
                    {
                        Console.WriteLine(c.Name);
                        GetIpFromName(c.Name);
                        Console.WriteLine("**************************");
                    }
                }

            }

            Console.ReadLine();
        }

        static void GetIpFromName(string comp)
        {
            IPHostEntry ipEntry = Dns.GetHostEntry(comp);
            IPAddress[] ipAddr = ipEntry.AddressList;

            Console.WriteLine(ipAddr[2]);    
        }
    }
}
