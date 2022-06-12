using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bleems.Database.Results
{
    public class ProductResult
    {
        public int ProductId { get; set; }
        public int ProductCategoryId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductPriceCurrency { get; set; }
        public string ProductPhoto { get; set; }
        public string ProductFullFileUrl { get; set; }

    }
}
