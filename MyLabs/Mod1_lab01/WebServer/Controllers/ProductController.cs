using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebServer.Models;

namespace WebServer.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller 
    {
        [HttpGet]
        public Product[] GetProducts()
        {
            return FakeData.Products.Values.ToArray();
        }
       
    }
}