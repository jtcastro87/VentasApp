using System.Collections.Generic;
using System.Threading.Tasks;
using Venta.Domain.Core;
using Venta.Domain.Entities;
using Venta.Infraestructure.Models;

namespace Venta.Infraestructure.Interface
{
    public interface IProductRepository : IRepositoryBase<Products>
    {
        Task<List<ProductModel>> GetAllProducts();
    }
}
