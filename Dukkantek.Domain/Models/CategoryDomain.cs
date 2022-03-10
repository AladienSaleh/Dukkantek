using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Dukkantek.Domain.Models
{
    public class CategoryDomain
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        [JsonIgnore]
        public virtual ICollection<ProductCategoryDomain> CategoryProducts { get; set; }
    }
}
