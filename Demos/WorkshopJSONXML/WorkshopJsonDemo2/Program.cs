
namespace WorkshopJsonDemo2
{
    using System;
    using Newtonsoft.Json;

    class Program
    {
        static void Main(string[] args)
        {

            var movies = new[]
           {
                new { name = "Movie 1", year = 1985 },
                new { name = "Movie 2", year = 1986 }

            };

            var json=   JsonConvert.SerializeObject(movies);
            //Console.WriteLine(json);

            var jsonString = "{\"id\": 1, \"name\": \"sergio\"}";

            var objectJson = JsonConvert.DeserializeAnonymousType(jsonString,
                new { id = 0, name = "" });

            Console.WriteLine($"Id= {objectJson.id}, Name = {objectJson.name}");

            Console.ReadKey();
            Console.WriteLine("FIN ");
        }
    }
}
