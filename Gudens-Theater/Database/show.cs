
using System;

namespace Gudens_Theater.Database
{
    public class Product
    {
        public int id { get; set; }
        public string naam { get; set; }
        public string beschrijving { get; set; }
        public DateTime datum { get; set; }
        public string image { get; set; }
    }
}