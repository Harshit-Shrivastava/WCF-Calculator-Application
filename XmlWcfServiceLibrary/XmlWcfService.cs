using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XmlWcfServiceLibrary
{
    public class XmlWcfService : IXmlWcfService
    {
        public int calculate(int a, int b, char c)
        {

            //accepting the data and calculating result
            //Console.WriteLine("Recieved data from " + name);
            //Console.WriteLine(a.ToString());
            //Console.WriteLine(b.ToString());
            //Console.WriteLine(c.ToString());
            int result;
            if (c == '+')
                result = a + b;
            else if (c == '-')
                result = a - b;
            else if (c == '*')
                result = a * b;
            else
                if (b == 0)
                    //error condition
                    result = -1;
                else
                    result = a / b;

            return result;
        }
    }
}
