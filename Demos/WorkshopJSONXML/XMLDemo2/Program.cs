using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Linq;

namespace XMLDemo2
{
    class Program
    {
        static void Main(string[] args)
        {
            XDocument purchaseOrderDocument =
                XDocument.Load("PurchaseOrder.xml");

            XElement purchaseOrder =
                purchaseOrderDocument.Element("PurchaseOrder");

            IEnumerable<XElement> addressShippings =
                purchaseOrder.Elements("Address");

            foreach (XElement address in addressShippings)
            {
                string name = address.Element("Name").Value;
                string state = address.Element("State").Value;
                string type = address.Attribute("Type").Value;

                Console.WriteLine($"{name}, {state}, {type}");
            }

            Console.WriteLine("------------------------");

            XElement deliveryNotes = purchaseOrder.Element("DeliveryNotes");

            Console.Write($"Notas:{ deliveryNotes.Value } \n\n");

            XElement Items = purchaseOrder.Element("Items");

            foreach (XElement item in Items.Elements("Item"))
            {
                string productName = item.Element("ProductName").Value;
                int.TryParse(item.Element("Quantity").Value, out int quantity);
                decimal.TryParse(item.Element("USPrice").Value, out decimal uSPrice);
                DateTime.TryParse(item.Element("ShipDate")?.Value, out DateTime shipDate);

                Console.Write($"Item: {productName} {quantity} {uSPrice} {shipDate.ToShortDateString()} \n");

            }

            Console.ReadKey();
        }
    }
}
