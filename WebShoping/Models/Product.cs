using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShoping.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string NameProduct { get; set; }
        public int Price { get; set; }
        public int Count { get; set; }
        public byte[] PhotoProduct { get; set; }
        public int? CategoriesId { get; set; }
        public Categorie Categories { get; set; }
    }
}
