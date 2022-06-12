using Bleems.Database;
using Bleems.WebSite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bleems.WebSite.Pages
{
    public class ProductsModel : PageModel
    {
        private readonly IProductsRepo productQuery;
        public ProductsModel(IProductsRepo _productQuery)
        {
            productQuery = _productQuery;

        }

        [BindProperty]
        public ICollection<ProductsListModel> ProductsList { get; set; }
        public async Task<IActionResult> OnGet()
        {
            var _productsList = await productQuery.GetAllProducts();
            ProductsList = (from p in _productsList
                            select new ProductsListModel()
                            {
                                ProductName = p.ProductName,
                                ProductPrice = p.ProductPrice,
                                ProductPhoto = p.ProductFullFileUrl
                            }).ToList();
            return Page();
        }
    }
}
