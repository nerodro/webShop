using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShoping.ViewModels
{
    public class CategorieModel
    {
        public int Id { get; set; }
        public string NameCategory { get; set; }
        public ICollection<ProductModel> Products { get; set; }
        public CategorieModel()
        {
            Products = new List<ProductModel>();
        }
    }
}
