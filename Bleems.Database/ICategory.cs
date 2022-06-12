using Bleems.Database.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bleems.Database
{
    public interface ICategoryRepo
    {
        Task<ICollection<CategoryResult>> GetCategories();
    }
}
