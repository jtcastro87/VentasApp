using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

using Venta.AppServices.Core;
using Venta.AppServices.DTO;
using Venta.AppServices.Interfaces;
using Venta.AppServices.Response;
using Venta.Domain.Entities;
//using VentasApp.Api.DTO;
//using VentasApp.Api.Infraestructure.Data.Entities;
//using VentasApp.Api.Service.Contract;
//using VentasApp.Api.Service.Core;
//using VentasApp.Api.Service.Response;

namespace VentasApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: api/Product
        // API para Agrear un producto
        [HttpPost("AddProduct")]
        public async Task<ActionResult<ProductAddResponse>> AddProduct(ProductAddDTO productAddDTO)
        {
            ServicesResponse response = new ServicesResponse();

            response = await _productService.AddProduct(productAddDTO);

            return Ok(response);
        }

        // API para Desactivar un Producto
        [HttpPost("DeleteProduct")]
        public async Task<ActionResult<ProductDeleteResponse>> DeleteProduct(ProductDeleteDTO productDeleteDTO)
        {
            ProductDeleteResponse response = new ProductDeleteResponse();

            response = await _productService.DeleteProduct(productDeleteDTO);

            return Ok(response);
        }

        // API Obtiene una lista de todos los Productos
        [HttpGet("GetProducts")]
        public async Task<ActionResult<IEnumerable<Products>>> GetProducts()
        {
            ServicesResponse response = new ServicesResponse();

            response = await this._productService.GetAllProducts();

            return Ok(response);
        }

        // API Obtiene un Producto mediante su ID
        [HttpGet("GetProductID")]
        [AllowAnonymous]
        public async Task<ActionResult<ServicesResponse>> GetProductID(int id)
        {
            ServicesResponse response = new ServicesResponse();

            response = await _productService.GetProductID(id);

            return Ok(response);
        }

        // API Actualiza un Producto
        [HttpPost("UpdateProduct")]
        public async Task<ActionResult<ProductUpdateResponse>> UpdateProduct(ProductUpdateDTO productUpdateDTO)
        {
            ProductUpdateResponse response = new ProductUpdateResponse();

            response = await _productService.UpdateProduct(productUpdateDTO);

            return Ok(response);
        }




    }
}
