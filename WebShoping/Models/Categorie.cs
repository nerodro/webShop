using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShoping.Models
{
    public class Categorie
    {
        public int Id { get; set; }
        public string NameCategory { get; set; }
        public ICollection<Product> Products { get; set; } 
        public Categorie()
        {
            Products = new List<Product>();
        }
    }
}
