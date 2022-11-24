using Doan.Entities.SubTable;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Doan.Entities
{
    public class GeneralProduct
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public double Rate { get; set; }
        public int Count { get; set; }
        public string Ima { get; set; }
        
        public Category Category { get; set; }
        [ForeignKey("Category")]
        public int CategoryID { get; set; }

        public virtual ICollection<Product> Products { get; set; }


    }
}