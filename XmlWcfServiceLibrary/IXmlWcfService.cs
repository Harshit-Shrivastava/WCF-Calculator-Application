using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace XmlWcfServiceLibrary
{
    [ServiceContract(Namespace = "www.harshits.in/Harshit/DemoApp")]

    //interface declaration
    public interface IXmlWcfService
    {
        [OperationContract]
        int calculate(int a, int b, char c);

    }
}
