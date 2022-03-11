using Dukkantek.Data.Models.Products;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dukkantek.Data.Models.Configuration
{
    public static class ModelBuilderExtensions
    {
        public static void SeedData(this ModelBuilder builder)
        { 
            builder.Entity<Category>().HasData(
                new Category() { Id=1, Name= "Beverages" , Description= "coffee/tea, juice, soda" },
                new Category() {Id=2, Name= "Bread/Bakery", Description= "sandwich loaves, dinner rolls, tortillas, bagels" }
               );

            builder.Entity<Product>().HasData(
                new Product() {Id=1, Name="CocaCola",Description="soda/ soft drink", Barcode="000001", Status=Shared.Enums.Status.InStock, Weight=0.5 },
                new Product() { Id = 2, Name = "Pepsi", Description = "soda/ soft drink", Barcode = "000002", Status = Shared.Enums.Status.InStock, Weight = 0.5 },
                new Product() { Id = 3, Name = "Croissant", Description = "A croissant is a buttery, flaky, viennoiserie pastry of Austrian origin", Barcode = "000003", Status = Shared.Enums.Status.InStock, Weight = 0.5 },
                new Product() { Id = 4, Name = "Pancake", Description = "A pancake is a flat cake, often thin and round", Barcode = "000004", Status = Shared.Enums.Status.InStock, Weight = 0.5 }
               );

            builder.Entity<ProductCategory>().HasData(
                new ProductCategory() { CategoryId=1,ProductId=1 },
                new ProductCategory() { CategoryId = 1, ProductId = 2 },
                new ProductCategory() { CategoryId = 2, ProductId = 3 },
                new ProductCategory() { CategoryId = 2, ProductId = 4 }
               );
        }
    }
}
