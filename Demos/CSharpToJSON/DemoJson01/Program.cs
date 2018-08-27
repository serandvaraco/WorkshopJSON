using ServiceStack;
using ServiceStack.Text;
using System;
using System.Collections.Generic;

namespace DemoJson01
{
    class Program
    {
        static void Main(string[] args)
        {
            var movies = new[] {
                new { Title = "Star Trek: La película",  Year = 1979 },
                new { Title = "Star Trek II: La ira de Khan", Year = 1982 },
                new { Title = "Star Trek III: En busca de Spock", Year = 1984 },
                new { Title = "Star Trek IV: Misión: salvar la Tierra", Year = 1986 },
                new { Title = "Star Trek V: La última frontera", Year = 1989 },
                new { Title = "Star Trek VI: Aquel país desconocido", Year = 1991 },
                new { Title = "Star Trek: La próxima generación", Year = 1994 },
                new { Title = "Star Trek: primer contacto", Year = 1996 },
                new { Title = "Star Trek: Insurrección", Year = 1998 },
                new { Title = "Star Trek: Némesis", Year = 2002 },
                new { Title = "Star Trek", Year = 2009 },
                new { Title = "Star Trek: en la oscuridad", Year = 2013 },
                new { Title = "Star Trek: sin límites (Hispanoamérica) Star Trek: más allá (España)", Year = 2016 }
            }; 

            Console.WriteLine(movies.ToJson());

            var json = "{\"Id\":\"fb1d17c7298c448cb7b91ab7041e9ff6\",\"Name\":\"John\",\"DateOfBirth\":\"\\/Date(317433600000-0000)\\/\"}";

            var obj = JsonObject.Parse(json);
            obj.Get<Guid>("Id").ToString().Print();
            obj.Get<string>("Name").Print();
            obj.Get<DateTime>("DateOfBirth").ToLongDateString().Print();

            dynamic dyn = DynamicJson.Deserialize(json);
            string id = dyn.Id;
            string name = dyn.Name;
            string dob = dyn.DateOfBirth;

            "DynamicJson: {0}, {1}, {2}".Print(id, name, dob);

            
            JsConfig.ConvertObjectTypesIntoStringDictionary = true;
            var map = (Dictionary<string, object>)json.FromJson<object>();
            map.PrintDump();

            Console.ReadKey(); 
        }
    }
}
