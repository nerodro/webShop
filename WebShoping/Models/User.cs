using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShoping.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int? RoleId { get; set; }
        public Role Role { get; set; }
        //public int? CartId { get; set; }
        //public List<Cart> Carts { get; set; }
        //public User()
        //{
        //    Carts = new List<Cart>();
        //}
    }
}
