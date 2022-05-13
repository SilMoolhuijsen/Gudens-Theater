﻿using MySql.Data;

using Gudens_Theater.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Gudens_Theater.Database;

namespace Gudens_Theater.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var products = GetAllProducts();
            return View(products);
        }



        public List<Product> GetAllProducts()
        {
            var rows = DatabaseConnector.GetRows("select * from product");
            List<Product> products = new List<Product>();

            foreach (var row in rows)

            {
                Product product = new Product();
                product.naam = row["naam"].ToString();
                product.prijs = row["prijs"].ToString();
                products.Add(product);
            }

            return products;
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [Route("contact")]
        public IActionResult Contact()
        {
            return View();
        }
        [Route("home-pagina")]
        public IActionResult index()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [Route("shows")]
        public IActionResult shows()
        {
            return View();
        }
        [Route("prijzen")]
        public IActionResult prijzen()
        {
            return View();
        }

        [Route("product/{id}")]
        public IActionResult ProductDetails(int id)
        {
            var productt = GetProduct(id);

            return View(product);
        }

        public List<Product> GetProduct()
        {
            var rows = DatabaseConnector.GetRows($"select * from product where id = {id}");
            List<Product> products = new List<Product>();

            foreach (var row in rows)

            {
                Product product = new Product();
                product.naam = row["naam"].ToString();
                product.prijs = row["prijs"].ToString();
                products.Add(product);
            }

            return products;
        }

    }
}

