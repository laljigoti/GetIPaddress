using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace ConsoleApp1
{
    public class Program
    {
        static void Main(string[] args)
        {
            //var address = NetworkInterface
            //.GetAllNetworkInterfaces()
            //.Where(i => i.NetworkInterfaceType == NetworkInterfaceType.Wireless80211)
            //.SelectMany(i => i.GetIPProperties().UnicastAddresses)
            //.Where(a => a.Address.AddressFamily == AddressFamily.InterNetwork)
            //.Select(a => a.Address.ToString())
            //.ToList();

            //Console.WriteLine("expectin Wlan IP {0}", address.ToString());
            //GetIpAddressFromHostName();
            networkinfo();
            GetNameOfAdapterType();
            Console.ReadLine();
        }

        public static void networkinfo()
        {
            IPGlobalProperties computerProperties = IPGlobalProperties.GetIPGlobalProperties();
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            Console.WriteLine("Interface information for {0}.{1}     ",
                    computerProperties.HostName, computerProperties.DomainName);
            foreach (NetworkInterface adapter in nics)
            {
                IPInterfaceProperties properties = adapter.GetIPProperties();
                Console.WriteLine(adapter.Description);
                Console.WriteLine(String.Empty.PadLeft(adapter.Description.Length, '='));
                Console.WriteLine("  Interface type .......................... : {0}", adapter.NetworkInterfaceType);
                Console.WriteLine("  Physical Address ........................ : {0}",
                           adapter.GetPhysicalAddress().ToString());
                Console.WriteLine("  Is receive only.......................... : {0}", adapter.IsReceiveOnly);
                Console.WriteLine("  Multicast................................ : {0}", adapter.SupportsMulticast);
                Console.WriteLine();
            }



            Console.ReadLine();
        }

        private static void GetIpAddressFromHostName()
        {


            IPHostEntry host;
            string localIP = "";
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily.ToString() == "InterNetwork")
                {
                    if (ip.ToString().StartsWith("192.168.178."))
                    {
                        localIP = ip.ToString();
                        Console.WriteLine(localIP);
                    }

                }
            }

        }
        private static void GetNameOfAdapterType()
        {
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            IPHostEntry host;
            string localIP = "";
            host = Dns.GetHostEntry(Dns.GetHostName());

            foreach (NetworkInterface adapter in nics)
            {
                if (adapter.NetworkInterfaceType.ToString() == "Wireless80211")
                {
                    foreach (IPAddress ip in host.AddressList)
                    {
                        if (ip.AddressFamily.ToString() == "InterNetwork")
                        {

                            localIP = ip.ToString();
                            Console.WriteLine(localIP);


                        }
                    }
                    Console.WriteLine("  Interface type .......................... : {0}", adapter.NetworkInterfaceType);
                }

            }
        }



    }
}
