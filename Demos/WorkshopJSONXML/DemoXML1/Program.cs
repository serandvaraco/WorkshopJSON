using System;
using System.Collections.Generic;
using System.Xml.Linq;
namespace DemoXML1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            XDocument doc = XDocument.Load("Catalog.xml");
            XElement catalog = doc.Element("Catalog");

            IEnumerable<XElement> books = catalog.Elements("Book");

            foreach (XElement book in books)
            {
                Console.Write($"\t{book.Attribute("id").Value}");
                Console.WriteLine("---");
                Console.Write($"Title: {book.Element("Title").Value} Author: { book.Element("Author").Value}");

            }

            Console.ReadKey();
        }
    }
}
