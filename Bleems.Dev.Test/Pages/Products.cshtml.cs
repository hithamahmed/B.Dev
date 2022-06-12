using Bleems.Database;
using Bleems.Database.Results;
using Bleems.Dev.Test.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bleems.Dev.Test.Pages
{
    public class ProductsModel : PageModel
    {
        private readonly IProductsRepo productQuery;
        public ProductsModel(IProductsRepo _productQuery)
        {
            productQuery = _productQuery;

        }

        [BindProperty]
        public ICollection<ProductModel> ProductsList { get; set; }

        //public IActionResult OnGetAllProducts()
        //{
        //    return ViewComponent("ProductList");
        //}
        public async Task<IActionResult> OnGetAllProducts()
        {
            ICollection<ProductResult> requests = await productQuery.GetAllProducts();
            var data = (from x in requests
                            select new ProductModel()
                            {
                                ProductId = x.ProductId,
                                ProductName = x.ProductName,
                                ProductPrice = x.ProductPrice,
                                ProductPhoto = x.ProductPhoto
                            }).ToList();
            return new JsonResult(data);
        }
        public async Task<IActionResult> OnGet()
        {
            ICollection<ProductResult> requests = await productQuery.GetAllProducts();
            ProductsList = (from x in requests
                            select new ProductModel()
                            {
                                ProductId = x.ProductId,
                                ProductName = x.ProductName,
                                ProductPrice = x.ProductPrice,
                                ProductPhoto = x.ProductPhoto
                            }).ToList();
            return Page();
        }

        public async Task<IActionResult> OnGetRemoveProduct( int productId)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Page();
                }

                if (productId == 0)
                    return Page();

                await productQuery.DeleteProduct(productId);

                return new JsonResult("Done");

            }
            catch (System.Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

    }
}
