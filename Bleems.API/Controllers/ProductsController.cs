using Bleems.API.Models;
using Bleems.Database;
using Bleems.Database.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bleems.API.Controllers
{
    [ApiController]
    [Route("API")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsRepo productsRepo; 
        public ProductsController(IProductsRepo _productsRepo) 
        {
            productsRepo = _productsRepo;
        }

        [HttpGet]
        [Route("GetProductsListRandomOrderSQL")]
        public async Task<IEnumerable<ProductDtoModel>> GetProductsListRandomOrderSQL()
        {
            ICollection<ProductResult> data = await productsRepo.GetAllProductsRnd();
            return data.Select(x => new ProductDtoModel() { Name = x.ProductName, Description = x.ProductDescription, Price = x.ProductPrice }).AsEnumerable();
        }

        [HttpGet]
        [Route("GetProductsListRandomOrder")]
        public async Task<IEnumerable<ProductDtoModel>> GetProductsListRandomOrder()
        {
            ICollection<ProductResult> data = await productsRepo.GetAllProducts();
            return data.Select(x => 
            new ProductDtoModel() 
            { 
                Name = x.ProductName, 
                Description = x.ProductDescription, 
                Price = x.ProductPrice 
            }).OrderBy(x => Guid.NewGuid()).AsEnumerable();
        }

        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProductDtoModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("GetProductDetailsById")]
        public async Task<IActionResult> GetProductDetailsById(int productId)
        {
            ProductResult product = await productsRepo.GetProduct(productId);
            if (product == null)
                return new NotFoundResult();

            return Ok(new ProductDtoModel() { Name = product.ProductName, Description = product.ProductDescription, Price = product.ProductPrice });
        }


        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProductCurrencyDtoModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("GetProductDetailsByIdWithCurrency")]
        public async Task<IActionResult> GetProductDetailsByIdWithCurrency(int productId)
        {
            ProductResult product = await productsRepo.GetProductSP(productId);
            if (product == null)
                return new NotFoundResult();

            return Ok(new ProductCurrencyDtoModel() { Name = product.ProductName, Description = product.ProductDescription, PriceCurrency = product.ProductPriceCurrency });
        }
    }
}
