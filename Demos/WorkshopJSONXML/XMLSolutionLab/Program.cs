using System;
using System.Linq;
using System.Xml.Linq;

namespace XMLSolutionLab
{
    class Program
    {
        static void Main(string[] args)
        {

            XDocument document = XDocument.Load("CustomerOrder.xml");

            #region Customers
            var CustomerOrdersCollection = from c in document.Descendants("Customer")
                                           join o in document.Descendants("Order")
                                           on c.Attribute("CustomerID").Value equals o.Element("CustomerID").Value
                                           select new
                                           {
                                               customerId = c.Attribute("CustomerID").Value,
                                               contactName = c.Element("ContactName").Value,
                                               companyName = c.Element("CompanyName").Value,
                                               contactTitle = c.Element("ContactTitle").Value,
                                               customerPhone = c.Element("Phone").Value,

                                               fullAddress = new
                                               {
                                                   address = c.Element("FullAddress").Element("Address").Value,
                                                   city = c.Element("FullAddress").Element("City").Value,
                                                   region = c.Element("FullAddress").Element("Region").Value,
                                                   postalCode = c.Element("FullAddress").Element("PostalCode").Value,
                                                   country = c.Element("FullAddress").Element("Country").Value
                                               },

                                               OrderDate = DateTime.Parse(o.Element("OrderDate").Value),
                                               EmployeeID = o.Element("EmployeeID").Value
                                           };


            #endregion

            #region Get Customer by Id

            var customerById = CustomerOrdersCollection.Where(x => x.customerId == "GREAL");
            Console.WriteLine($"cliente: {customerById.ToList()[0].contactName}");
            foreach (var customer in customerById)
            {
                Console.WriteLine($"Fecha de Pedido: {customer.OrderDate} empleado {customer.EmployeeID}");
            }

            #endregion

            #region Orders by customer

            var OrderByCustomer = (from C in CustomerOrdersCollection
                                   select new
                                   {
                                       orders = CustomerOrdersCollection.Count(x => x.customerId == C.customerId),
                                       C.contactName,
                                       C.customerId
                                   }).Distinct();

            foreach (var item in OrderByCustomer)
            {
                Console.WriteLine($" Cliente { item.contactName} Id {item.customerId} Cant Pedidos {item.orders}");
            }

            #endregion

            #region Order by date 

            var OrderByDate = CustomerOrdersCollection.Where(x => x.OrderDate.Year >= 1997 && x.OrderDate.Year <= 1999);
            foreach (var item in OrderByDate)
            {
                Console.WriteLine($"{item.contactName} {item.OrderDate.ToShortDateString()}");
            }

            #endregion 


            Console.ReadKey();
        }
    }
}
