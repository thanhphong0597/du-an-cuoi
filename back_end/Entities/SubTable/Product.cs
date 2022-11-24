using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Doan.Entities.SubTable
{
    public class Product
    {
        public int Stock { get; set; }
        public string Ima { get; set; }

        public int ColorID { get; set; }
        public int ProductID { get; set; }
        public int SizeID { get; set; }

        public Color Color { get; set; }
        public GeneralProduct GeneralProduct { get; set; }
        public Size Size { get; set; }
    }

    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> b)
        {
            b.ToTable("Product");
            b.HasKey(t => new { t.ProductID, t.ColorID, t.SizeID });

            b.HasOne(t => t.GeneralProduct)
            .WithMany(x => x.Products)
            .HasForeignKey(t => t.ProductID)
            .HasPrincipalKey(x => x.ID)
            .OnDelete(DeleteBehavior.Cascade);

            b.HasOne(t => t.Color)
            .WithMany(x => x.Products)
            .HasForeignKey(t => t.ColorID)
            .HasPrincipalKey(x => x.ID)
            .OnDelete(DeleteBehavior.Cascade);

            b.HasOne(t => t.Size)
           .WithMany(x => x.Products)
           .HasForeignKey(t => t.SizeID)
           .HasPrincipalKey(x => x.ID)
           .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
