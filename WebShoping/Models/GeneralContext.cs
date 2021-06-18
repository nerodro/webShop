using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShoping.Models
{
    public class GeneralContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public  DbSet<Product> Products { get; set; }
        public DbSet<Categorie> Categories { get; set; }
        public GeneralContext(DbContextOptions<GeneralContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            string adminRoleName = "admin";
            string moderRoleName = "moder";
            string userRoleName = "user";

            string adminEmail = "admin@mail.ru";
            string adminPassword = "123";

            string moderEmail = "moder@mail.ru";
            string moderPassword = "1234";

            string techCategoryName = "Электронника";
            string pcCategoryName = "Компьтеры";

            string productTechName = "Телефон";
            string productPcName = "Зверь пк";

            int pricePhone = 1000;
            int pricePc = 1000000;

            int countPhone = 10;
            int countPc = 2;


            Role adminRole = new Role { Id = 1, Name = adminRoleName };
            Role moderRole = new Role { Id = 2, Name = moderRoleName };
            Role userRole = new Role { Id = 3, Name = userRoleName };
            User adminUser = new User { Id = 1, Email = adminEmail, Password = adminPassword, RoleId = adminRole.Id};
            User moderUser = new User { Id = 2, Email = moderEmail, Password = moderPassword, RoleId = moderRole.Id };

            Categorie techCategoty = new Categorie { Id = 1, NameCategory = techCategoryName };
            Categorie pcCategory = new Categorie { Id = 2, NameCategory = pcCategoryName };
            Product techProduct = new Product { Id = 1, NameProduct = productTechName, Count = countPhone, Price = pricePhone, CategoriesId = techCategoty.Id };
            Product pcProduct = new Product { Id = 2, NameProduct = productPcName, Count = countPc, Price = pricePc, CategoriesId = pcCategory.Id };

            modelBuilder.Entity<Role>().HasData(new Role[] { adminRole, moderRole,userRole });
            modelBuilder.Entity<User>().HasData(new User[] { adminUser, moderUser });
            modelBuilder.Entity<Categorie>().HasData(new Categorie[] { techCategoty, pcCategory });
            modelBuilder.Entity<Product>().HasData(new Product[] { techProduct, pcProduct });
            base.OnModelCreating(modelBuilder);
        }
    }
}
