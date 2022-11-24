using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VentaApp.Web.Models.Category;

namespace VentaApp.Web.Services.Contracts
{
    public interface ICategoryServicesMVC
    {
        Task<List<CategoryModel>> GetAllCategory();

        Task<CategoryModel> GetByID(int id);

        Task<CategoryRequest> UpdateCategory(CategoryModel updateCategory);

        Task<CategoryRequest> AddCategory(CategoryAddViewModel categoryAddViewModel);

        Task<CategoryRequest> DeleteCategory(CategoryDeleteViewModel categoryDeleteViewModel);
    }
}
