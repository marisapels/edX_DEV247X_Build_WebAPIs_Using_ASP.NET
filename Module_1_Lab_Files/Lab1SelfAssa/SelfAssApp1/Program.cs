using System;
using Newtonsoft.Json;

namespace SelfAssApp1
{
    class Program
    {
        /// Progam steps:
        ///  * Serialize the object to JSON string
        ///  * Deserialize the JSON string back to a Product type object.
        
        /// Serialize a Rocket array to JSON string
        private static string DoSerialization() 
        {
            Product[] products = 
            {
                new Product
                { 
                    ID = 101, Name = "Product-101", Price = 99
                }
            };   
            var json = JsonConvert.SerializeObject(products);
            return json;
        }

        /// Deserialize back to object and write some output from it
        private static void DoDeserialization(string json)
        {
            //Assume that this is possible to get array of products
            var products = JsonConvert.DeserializeObject<Product[]>(json);
            foreach (var product in products)
            {
               System.Console.WriteLine($"ID:{product.ID} Name:{product.Name} Price:{product.Price}");
            }
        }

        static void Main(string[] args)
        {
            var json = DoSerialization();
            System.Console.WriteLine(json);
            DoDeserialization(json);
        }
    }
}
