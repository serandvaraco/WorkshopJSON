namespace LabJson02
{
    using System.Collections.Generic;
    public class Books
    {
        public string BookName { get; set; }
        public string Genre { get; set; }
        public string Author { get; set; }

        public BookDetail Detail { get; set; }
        public ICollection<BookType> BooksTypes { get; set; }
    }

    public class BookDetail
    {
        public int Year { get; set; }
        public string PublishName { get; set; }
        public string ISBN { get; set; }
        public string Language { get; set; }
        public int Pages { get; set; }
    }

    public class BookType
    {
        public string Type { get; set; }
        public decimal Price { get; set; }
    }

}
