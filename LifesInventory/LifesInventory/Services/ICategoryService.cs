using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LifesInventory.Models;

namespace LifesInventory.Services
{
    public interface ICategoryService
    {
        Task<List<Category>> Categories();
        Task AddCategoryAsync(Category category);
        Task RemoveCategoryAsync(Category category);
        Task UpdateCategoryAsync(Category category);
    }
}
