using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace UpdateXML
{
    class Program
    {
        static void Main(string[] args)
        {

            XDocument doc = XDocument.Load("Catalog.xml");
            XElement catalog = doc.Element("Catalog");

            IEnumerable<XElement> books = catalog.Elements("Book");

            foreach (XElement book in books)
            {


                Console.Write($"\t{book.Attribute("id").Value}");
                Console.WriteLine("---");
                Console.Write($"Title: {book.Element("Title").Value} Author: { book.Element("Author").Value}");
                //book.Remove(); 
                book.Element("Title").Value = "HACK!!";
            }

            doc.Save("CatalogHACK!!!.xml");


            Console.ReadKey();


        }
    }
}
