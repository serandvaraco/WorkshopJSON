namespace WorkshopJSON
{
    using System;
    using System.Collections.Generic;
    using ServiceStack;
    using ServiceStack.Text;
    class Program
    {
        static void Main(string[] args)
        {

            var movies = new[]
            {
                new { name = "Movie 1", year = 1985 },
                new { name = "Movie 2", year = 1986 }

            };


            var json = "{\"id\": 1, \"name\": \"sergio\"}";

            //Option 1
            var obj = JsonObject.Parse(json);
            var id = obj.Get<int>("id").ToString();
            var name = obj.Get<string>("name");
            //Console.WriteLine($"Id= {id} Name = {name}");

            //option 2
            dynamic dyn = DynamicJson.Deserialize(json);
            //Console.WriteLine($"Dinámico {dyn.id} {dyn.name}");

            //Option 3
            JsConfig.ConvertObjectTypesIntoStringDictionary = true;
            var map = (Dictionary<string, object>)json.FromJson<object>();
            map.PrintDump(); 
            /*
            var idMap = map["id"];
            var nameMap = map["name"]; 
            */



            //Console.WriteLine(movies.ToJson());

            Console.ReadKey();
            Console.WriteLine("FIN");

        }
    }
}
