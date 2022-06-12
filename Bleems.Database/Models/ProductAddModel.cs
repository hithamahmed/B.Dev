using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bleems.Database.Models
{
    public sealed class ProductAddModel
    {
        public int ProductCategoryId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductPhoto { get; set; }
        public string ProductFileUrlBase { get; set; }
    }
}
