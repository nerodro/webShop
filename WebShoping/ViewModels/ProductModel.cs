using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShoping.Models;

namespace WebShoping.ViewModels
{
    public class ProductModel
    {
        public string NameProduct { get; set; }
        public int PriceProduct { get; set; }
        public int CountProduct { get; set; }
        public Categorie Categories { get; set; }
        public int CategoriesId { get; set; }
        public IFormFile PhotoProduct { get; set; }
    }
}
