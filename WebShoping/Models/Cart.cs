using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebShoping.Models
{
    public class Cart
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string NameProduct { get; set; }
        public int Price { get; set; }
        public int Count { get; set; }
       // public byte[] PhotoProduct { get; set; }
        public int? ProductId { get; set; }
        public Product Products { get; set; }
        //public int? ProductId { get; set; }
        //public string NameProduct { get; set; }
        //public int Price { get; set; }
        ////public Product Product { get; set; }
        ////public List<Product> Products { get; set; }
        ////public Cart()
        ////{
        ////    Products = new List<Product>();
        ////}
        //public int? UserId { get; set; }
        //public User User { get; set; }

    }
}