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
    [ViewComponent(Name = "CategoryDropDown")]
    public class CategoryDropDownComponents : ViewComponent
    {
        private readonly ICategoryRepo categoryRepo;
        public CategoryDropDownComponents(ICategoryRepo _productQuery)
        {
            categoryRepo = _productQuery;

        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            try
            {
                ICollection<CategoryResult> data = await categoryRepo.GetCategories();
                var categoriesList = (from x in data
                                    select new CategoryModel()
                                    {
                                        CategoryId = x.CategoryId,
                                        CategoryName = x.CategoryName
                                    }).ToList();

                return View(categoriesList);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}


