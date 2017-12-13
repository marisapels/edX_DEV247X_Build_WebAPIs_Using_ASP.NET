using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebServer.Models;

namespace WebServer.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller 
    {
        [HttpGet]
        public Product[] GetProducts()
        {
            return FakeData.Products.Values.ToArray();
        }

        [HttpGet("{id}")]
        public Product GetProduct(int id)
        {
            if (FakeData.Products.ContainsKey(id))
            {
                return FakeData.Products[id];
            }
                else
            {
                return null;
            }
        }     

        [HttpPost]
        public Product CreateProduct([FromBody]Product product) 
        {

            //I would move logic to product class, 
            // but the tut is tut so left it as is.
            product.ID = FakeData.Products.Keys.Max() + 1;
            FakeData.Products.Add(product.ID, product);
            return product;
        }  

        [HttpPut]
        public void UpdateProduct(int id, [FromBody]Product product)
        {
            if (FakeData.Products.ContainsKey(id))
            {
                var target = FakeData.Products[id];
                target.ID = product.ID;
                target.Name = product.Name;
                target.Price = product.Price;
            }
        }

        [HttpDelete("{id}")]
        public void DeleteProduct(int id)
        {
            if (FakeData.Products.ContainsKey(id))
            {
                FakeData.Products.Remove(id);
            }
        }

        
    }
}