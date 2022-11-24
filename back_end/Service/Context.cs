using Doan.Entities;
using Doan.Entities.SubTable;
using Microsoft.EntityFrameworkCore;

namespace Doan.Service
{
    public class Context : DbContext
    {
        public DbSet<GeneralProduct> GeneralProducts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public Context(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder b)
        {
            b.ApplyConfiguration(new ProductConfig());
            b.Initial();

        }
    }

    public static class DuLieuMau
    {
        public static void Initial(this ModelBuilder b)
        {
            b.Entity<Category>().HasData(
                new Category { ID = 1, Name = "Men's Clothing" },
                new Category { ID = 2, Name = "Women's Clothing" },
                new Category { ID = 3, Name = "Jewelery" },
                new Category { ID = 4, Name = "Electronics" }
            );

            b.Entity<Color>().HasData(
                new Color { ID = 1, Name = "Purple" },
                new Color { ID = 2, Name = "Blue" },
                new Color { ID = 3, Name = "Green" },
                new Color { ID = 4, Name = "Red" },
                new Color { ID = 5, Name = "White" }
                );
            b.Entity<Size>().HasData(
                new Size { ID = 1, Name = "s" },
                new Size { ID = 2, Name = "m" },
                new Size { ID = 3, Name = "l" },
                new Size { ID = 4, Name = "xl" }
                );
            b.Entity<GeneralProduct>().HasData(
                new GeneralProduct
                {
                    ID = 1,
                    Name = "Mens Casual Premium Slim Fit T-Shirts ",
                    Title = "Men",
                    Description = "Slim-fitting style, contrast raglan long sleeve, three-button henley placket, light weight & soft fabric for breathable and comfortable wearing. And Solid stitched shirts with round neck made for durability and a great fit for casual fashion wear and diehard baseball fans. The Henley style round neckline includes a three-button placket.",
                    Count = 259,
                    Price = 22,
                    Rate = 4.1,
                    CategoryID=1,
                    Ima= "https://fakestoreapi.com/img/71-3HjGNDUL._AC_SY879._SX._UX._SY._UY_.jpg"
                },
                new GeneralProduct
                {
                      ID = 2,
                      Name = "Mens Cotton Jacket ",
                      Title = "Men",
                      Description = "great outerwear jackets for Spring/Autumn/Winter",
                      Count = 500,
                      Price = 22,
                      Rate = 4.7,
                      CategoryID = 1,
                      Ima = "https://fakestoreapi.com/img/71li-ujtlUL._AC_UX679_.jpg"

                }
                );
            b.Entity<Product>().HasData(
                new Product { ProductID = 1, ColorID = 1, SizeID = 1, Stock = 2, Ima = "" },
                new Product { ProductID = 1, ColorID = 1, SizeID = 2, Stock = 1, Ima = "" },
                new Product { ProductID = 1, ColorID = 2, SizeID = 3, Stock = 5, Ima = "" },
                new Product { ProductID = 2, ColorID = 1, SizeID = 2, Stock = 1, Ima = "" }
                );


        }
    }
}

