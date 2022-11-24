using System.Threading.Tasks;

using Venta.AppServices.Core;
using Venta.AppServices.DTO;
using Venta.AppServices.Response;

namespace Venta.AppServices.Interfaces
{
    public interface IProductService
    {
        Task<ServicesResponse> GetProductID(int id);

        Task<ServicesResponse> GetAllProducts();

        Task<ProductAddResponse> AddProduct(ProductAddDTO productAddDTO);

        Task<ProductUpdateResponse> UpdateProduct(ProductUpdateDTO productUpdateDTO);

        Task<ProductDeleteResponse> DeleteProduct(ProductDeleteDTO productDeleteDTO);
    }
}
