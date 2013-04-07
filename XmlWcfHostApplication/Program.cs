using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace XmlWcfHostApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Xml Wcf Host Application";

            using (ServiceHost host = new ServiceHost(
                typeof(XmlWcfServiceLibrary.XmlWcfService)))
            {
                host.AddServiceEndpoint(typeof(
                    XmlWcfServiceLibrary.IXmlWcfService),
                    new NetTcpBinding(),
                    "net.tcp://localhost:9001/WcfEndPoint");

                host.Open();
                Console.ReadLine();           
            }
        }
    }
}