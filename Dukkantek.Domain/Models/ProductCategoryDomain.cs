using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Dukkantek.Domain.Models
{
    public class ProductCategoryDomain
    { 
        public int CategoryId { get; set; }
         
        public int ProductId { get; set; }
         
        public CategoryDomain Category { get; set; }  

        [JsonIgnore]
        public ProductDomain Product { get; set; }
    }
}
