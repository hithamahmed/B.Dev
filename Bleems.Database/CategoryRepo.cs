using Bleems.Database.Results;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bleems.Database
{
    internal class CategoryRepo : ICategoryRepo
    {

        private readonly DataContext _db;
        public CategoryRepo(DataContext db)
        {
            _db = db;
        }
        public async Task<ICollection<CategoryResult>> GetCategories()
        {
            try
            {
                return await(from x in _db.Categories
                             select new CategoryResult()
                             {
                                 CategoryId = x.Id,
                                 CategoryName = x.CategoryName
                             }).ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
