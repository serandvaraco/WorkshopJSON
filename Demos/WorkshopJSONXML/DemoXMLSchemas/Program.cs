using System;
using System.Collections.Generic;
using System.Text;
namespace DemoXMLSchemas
{
    using System.Xml.Linq;
    using System.Xml.Schema;
    class Program
    {
        static void Main(string[] args)
        {
            XmlSchemaSet schema = new XmlSchemaSet();
            schema.Add("", "CustomerOrder.xsd");

            XDocument customerOrder = XDocument.Load("CustomerOrder.xml");

            bool errors = false;

            customerOrder.Validate(schema, (o, a) =>
            {
                Console.WriteLine($"{a.Message}");
                errors = true;
            });

            if (errors)
            {
                Console.ReadKey();
                return;
            }




        }


    }
}
