using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bleems.Database
{
    [Keyless]
    [NotMapped]
    internal class SingleProduct
    {
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string ProductPrice { get; set; }
    }
}
