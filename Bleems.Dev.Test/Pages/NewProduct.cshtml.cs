using Bleems.Database;
using Bleems.Database.Models;
using Bleems.Dev.Test.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Bleems.Dev.Test.Pages
{
    public class NewProductModel : PageModel
    {
        private readonly IProductsRepo productQuery;
        public NewProductModel(IProductsRepo _productQuery)
        {
            productQuery = _productQuery;

        }
        public async Task<IActionResult> OnPostAddProduct(ProductNewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (model.ProductPhoto.Length > 0)
                    {

                        if (model.ProductPhoto.Length >= 0.250 * 1024 * 1024)
                        {
                            ModelState.AddModelError("", "Please Select image smaller than 250/KB");
                            return Page();
                        }
                    }
                    string filePath = SaveProductPhoto(model.ProductPhoto);
                    string fileBase = $"{Request.Scheme}://{Request.Host}{Request.PathBase}";
                    await productQuery.AddNewProduct(new ProductAddModel()
                    {
                        ProductCategoryId = model.ProductCategoryId,
                        ProductName = model.ProductName,
                        ProductDescription = model.ProductDescription,
                        ProductPrice = model.ProductPrice,
                        ProductPhoto = filePath,
                        ProductFileUrlBase = fileBase
                    });


                    return RedirectToPage("Products");
                }
                catch (System.Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }

            }
            else
            {
                foreach (var value in ModelState.Values)
                {
                    foreach (var error in value.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.ErrorMessage);
                    }

                }
            }
            return Page();

        }

        private string SaveProductPhoto(IFormFile photoFile)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/productsPhotos");

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            FileInfo fileInfo = new FileInfo(photoFile.FileName);
            string fileName = DateTime.Now.ToString("ddMMyyyyhhmmffff") + fileInfo.Extension;

            string fileNamePath = Path.Combine(path, fileName);

            using (var stream = new FileStream(fileNamePath, FileMode.Create))
            {
                photoFile.CopyTo(stream);
            }
            return "productsPhotos/" + fileName;
        }
    }
}
