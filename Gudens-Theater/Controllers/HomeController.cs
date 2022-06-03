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
            var shows = GetAllProducts();
            return View(shows);
        }



        public List<Product> GetAllProducts()
        {
            var rows = DatabaseConnector.GetRows("select * from `show`");
            List<Product> shows = new List<Product>();

            foreach (var row in rows)

            {
                Product p = new Product();
                p.naam = row["naam"].ToString();
                p.beschrijving = row["beschrijving"].ToString();
                p.id = Convert.ToInt32(row["id"]);
                shows.Add(p);
            }

            return shows;
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [Route("contact")]
        public IActionResult Contact(string firstname, string lastname)
        {
            ViewData["firstname"] = firstname;
            ViewData["lastname"] = lastname;

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
        [Route("beschrijvingen")]
        public IActionResult beschrijvingen()
        {
            return View();
        }

        [Route("show/{id}")]
        public IActionResult ProductDetails(int id)
        {
            var show = GetProduct(id);

            return View(show);
        }

        public Product GetProduct(int id)
        {
            var rows = DatabaseConnector.GetRows($"select * from `show` where id = {id}");
            List<Product> shows = new List<Product>();

            foreach (var row in rows)

            {
                Product p = new Product();
                p.naam = row["naam"].ToString();
                p.beschrijving = row["beschrijving"].ToString();
                p.id = Convert.ToInt32(row["id"]);
                shows.Add(p);
            }

            return shows[0];
        }

    }
}

