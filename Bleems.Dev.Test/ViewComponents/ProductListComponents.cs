using Bleems.Database;
using Bleems.Database.Results;
using Bleems.Dev.Test.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bleems.Dev.Test.ViewComponents
{
    [ViewComponent(Name = "ProductList")]
    public class ProductListComponents : ViewComponent
    {
        private readonly IProductsRepo productQuery;
        public ProductListComponents(IProductsRepo _productQuery)
        {
            productQuery = _productQuery;

        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            try
            {
                ICollection<ProductResult> data = await productQuery.GetAllProducts();
                var productsList = (from x in data
                                    select new ProductModel() { ProductId = x.ProductId,
                                    ProductName = x.ProductName,
                                    ProductPrice = x.ProductPrice,
                                    ProductPhoto = x.ProductPhoto}).ToList();

                return View(productsList);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

