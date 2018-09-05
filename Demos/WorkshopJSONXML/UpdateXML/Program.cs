using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace UpdateXML
{
    class Book
    {
        public string Author { get; set; }
    }
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


            ///insert XML 

            System.Xml.Serialization.XmlSerializer writer =
            new System.Xml.Serialization.XmlSerializer(typeof(Book));

            writer.Serialize(new StreamWriter("Path"), new Book { Author = "new" }); 

            Console.ReadKey();

            

        }
    }
}
