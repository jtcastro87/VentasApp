using System.Threading.Tasks;

using Venta.AppServices.Core;
using Venta.AppServices.DTO;
using Venta.AppServices.Response;

namespace Venta.AppServices.Interfaces
{
    public interface ICategoryService
    {
        Task<ServicesResponse> GetCategoryID(int id);

        Task<ServicesResponse> GetAllCategory();

        Task<CategoryAddResponse> AddCategory(CategoryAddDTO categoryAddDTO);

        Task<CategoryUpdateResponse> UpdateCategory(CategoryUpdateDTO categoryUpdateDTO);

        Task<CategoryDeleteResponse> DeleteCategory(CategoryDeleteDTO categoryDeleteDTO);
    }
}
