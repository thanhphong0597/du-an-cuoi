using Doan.Entities;
using Doan.Entities.SubTable;
using System.ComponentModel.DataAnnotations.Schema;

namespace Doan.Models
{
    public class CategoryModel
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public CategoryModel()
        {
            GeneralProducts = new HashSet<GeneralProductModel>();
        }
        public IEnumerable<GeneralProductModel> GeneralProducts { get; set; }
    }
    public class ProductModel
    {
        public string ID { get; set; }
        public int Stock { get; set; }
        public string Ima { get; set; }

        public string Color { get; set; }
        public string  Product{ get; set; }
        public string Size { get; set; }
    }

    public class ColorModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }

    public class SizeModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
    public class GeneralProductModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public double Rate { get; set; }
        public int Count { get; set; }
        public string Ima { get; set; }

        public string Category { get; set; }
        public int CategoryID { get; set; }
        public virtual ICollection<ProductModel> Products { get; set; }
    }
}
