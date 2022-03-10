using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dukkantek.Data.Models
{
    public class ProductCategory
    {
        [Key]
        public int CategoryId { get; set; }

        [Key]
        public int ProductId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; }

        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }
    }
}
