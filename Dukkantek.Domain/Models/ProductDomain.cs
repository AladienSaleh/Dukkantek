using Dukkantek.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dukkantek.Domain.Models
{
    public class ProductDomain
    { 
        public int Id { get; set; }

        public string Name { get; set; }

        public string Barcode { get; set; }

        public string Description { get; set; }

        public double Weight { get; set; }

        public Status Status { get; set; }

        public virtual ICollection<ProductCategoryDomain> ProductCategory { get; set; }
    }
}
