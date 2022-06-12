using Bleems.Database.Models;
using Bleems.Database.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bleems.Database
{
    public interface IProductsRepo
    {
        Task<ICollection<ProductResult>> GetAllProducts();
        Task DeleteProduct(int productId);
        Task AddNewProduct(ProductAddModel productAddModel);
        Task<ICollection<ProductResult>> GetAllProductsRnd();
        Task<ProductResult> GetProduct(int productId);
        Task<ProductResult> GetProductSP(int productId);
    }
}
