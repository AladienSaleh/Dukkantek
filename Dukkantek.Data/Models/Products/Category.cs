using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dukkantek.Data.Models.Products
{
    public class Category
    {
        public Category()
        {
            CategoryProducts = new HashSet<ProductCategory>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<ProductCategory> CategoryProducts { get; set; }
    }
}
