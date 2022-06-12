using Bleems.Database.Models;
using Bleems.Database.Results;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bleems.Database
{
    internal class ProductsQuery : IProductsRepo
    {

        private readonly DataContext _db;
        public ProductsQuery(DataContext db)
        {
            _db = db;
        }

        public async Task AddNewProduct(ProductAddModel productAddModel)
        {
            try
            {
                Product newProduct = new Product()
                {
                    ProductName = productAddModel.ProductName,
                    ProductDescription = productAddModel.ProductDescription,
                    ProductPrice = productAddModel.ProductPrice,
                    CategoryId = productAddModel.ProductCategoryId,
                    ProductPhoto = productAddModel.ProductPhoto,
                    FileUrlBase = productAddModel.ProductFileUrlBase
                };

                await _db.Products.AddAsync(newProduct);
                await _db.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task DeleteProduct(int productId)
        {
            try
            {
                if(productId > 0)
                {
                    var product=  _db.Products.Find(productId);
                    if(product!= null)
                    {
                        _db.Products.Remove(product);
                        await _db.SaveChangesAsync();
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ICollection<ProductResult>> GetAllProducts()
        {
            return await (from x in _db.Products select new ProductResult()
            {
                ProductId = x.Id,
                ProductName = x.ProductName,
                ProductDescription =x.ProductDescription,
                ProductPrice = x.ProductPrice,
                ProductPhoto = x.ProductPhoto,
                ProductCategoryId = x.CategoryId,
                ProductFullFileUrl = $"{x.FileUrlBase}/{x.ProductPhoto}"
            }).ToListAsync();
           
        }

        public async Task<ICollection<ProductResult>> GetAllProductsRnd()
        {
            try
            {
                return await(from x in _db.Products
                             select new ProductResult()
                             {
                                 ProductId = x.Id,
                                 ProductName = x.ProductName,
                                 ProductDescription = x.ProductDescription,
                                 ProductPrice = x.ProductPrice,
                                 ProductPhoto = x.ProductPhoto,
                                 ProductCategoryId = x.CategoryId,
                                 ProductFullFileUrl = x.GetFullPhotoUrl()
                             }).OrderBy(x=> Guid.NewGuid()).ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ProductResult> GetProduct(int productId)
        {
            try
            {
                var product =  await _db.Products.FindAsync(productId);
                if (product == null)
                    return new ProductResult();

                return new ProductResult() { 
                    ProductId = productId ,
                    ProductCategoryId = productId ,
                    ProductName = product.ProductName,
                    ProductDescription = product.ProductDescription,
                    ProductPrice = product.ProductPrice,
                    ProductPhoto = product.ProductPhoto,
                    ProductFullFileUrl = product.GetFullPhotoUrl()
                };
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ProductResult> GetProductSP(int productId)
        {
            try
            {
                var products = _db.SingleProducts
                    .FromSqlInterpolated($"GetItemDetails {productId}")
                    .AsEnumerable();

                if (!products.Any())
                    return new ProductResult();

                return (from product in products select  new ProductResult()
                {
                    ProductName = product.ProductName,
                    ProductDescription = product.ProductDescription,
                    ProductPriceCurrency = product.ProductPrice,
                }).FirstOrDefault();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
