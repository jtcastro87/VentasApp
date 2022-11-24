using System.Collections.Generic;
using System.Threading.Tasks;
using VentaApp.Web.Models.Product;
using VentaApp.Web.Models.Product.Core;

namespace VentaApp.Web.Services.Contracts
{
    public interface IProductServiceMVC
    {
        Task<ProductRequestModel> AddNewProduct(ProductAddViewModel productAddViewModel);

        Task<List<ProductModel>> GetAllProduct();

        Task<ProductDetailViewModel> GetProductByID(int id);        

        Task<ProductRequestModel> UpdateProduct(ProductDetailViewModel productDetailViewModel);

        Task<ProductRequestModel> DeleteProduct(ProductModel productModel);
    }
}
