namespace XMLDemo
{
    using System;
    using System.Collections.Generic;
    using System.Xml.Linq;
    class Program
    {
        static void Main(string[] args)
        {
            XDocument document = XDocument.Load("Catalog.xml");

            XElement catalog = document.Element("Catalog");

            IEnumerable<XElement> books = catalog.Elements("Book");

            foreach (XElement book in books)
            {
                Console.WriteLine(
                    $"\n\t identificador de libro " +
                    $"{book.Attribute("id").Value}");

                Console.WriteLine("----");
                Console.Write($"Título: {book.Element("Title").Value} \n\t\t\t" +
                    $"Autor: {book.Element("Author").Value}");
            }

            Console.ReadKey();
        }
    }
}
