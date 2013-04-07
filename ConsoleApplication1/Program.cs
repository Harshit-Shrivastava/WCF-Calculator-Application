using System;
using System.Text;
using System.ServiceModel;
using System.Xml;
using System.Xml.Schema;

[ServiceContract(Namespace = "www.harshits.in/Harshit/DemoApp")]

    //interface declaration
public interface IXmlWcfService
{
    [OperationContract]
    int calculate(int a, int b, char c);
}


namespace XmlWcfClientApplication
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Title="Xml Wcf Client Application";

            //creating the proxy object
            IXmlWcfService proxy = ChannelFactory<IXmlWcfService>.CreateChannel(
                new NetTcpBinding(),
                new EndpointAddress(
                    "net.tcp://localhost:9001/WcfEndPoint"));


            //string XmlFile = Server.MapPath("C:\\Documents and Settings\\SESA270296\\My Documents\\Visual Studio 2010\\Projects\\XmlWcfHostApplication\\ConsoleApplication1\\input.xml");

            //creating the reader
            XmlTextReader reader = new XmlTextReader("C:\\Documents and Settings\\SESA270296\\My Documents\\Visual Studio 2010\\Projects\\XmlWcfHostApplication\\ConsoleApplication1\\input.xml");

            //validate the Xml file

            //XmlTextReader reader = new XmlTextReader(XmlFile);

            XmlTextWriter writer = new XmlTextWriter("C:\\Documents and Settings\\SESA270296\\My Documents\\Visual Studio 2010\\Projects\\XmlWcfHostApplication\\ConsoleApplication1\\output.xml", null);

            writer.WriteStartDocument();
            writer.Formatting = Formatting.Indented;

            writer.WriteComment("Created @" + DateTime.Now.ToString());
            writer.WriteStartElement("results");


            StringBuilder str = new StringBuilder();

            int a=0, b=0;
            int i = 0;
            char c='+';

            //reading through all the values
            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.XmlDeclaration:                                      
                        break;

                    case XmlNodeType.Element:
                        break;

                    case XmlNodeType.Text:
                        if (i % 3 == 0)
                        {
                            a = int.Parse(reader.Value.ToString());
                            i++;
                        }

                        else if (i % 3 == 1)
                        {
                            b = int.Parse(reader.Value.ToString());
                            i++;
                        }

                        else if(i % 3 == 2)

                        {
                            c = char.Parse(reader.Value.ToString());
                            i++;
                            int d = proxy.calculate(a, b, c);
                            Console.WriteLine(d.ToString());
                            writer.WriteStartElement("operation");
                            writer.WriteElementString("variablea",a.ToString());
                            writer.WriteElementString("variableb",b.ToString());
                            writer.WriteElementString("operator",c.ToString());
                            writer.WriteElementString("result",d.ToString());
                            writer.WriteEndElement();
                        }
                        break;
                }
            }
            writer.WriteEndElement();
            writer.Close();
            reader.Close();
            Console.Read();
        }
    }
}