using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

using Venta.AppServices.DTO;
using Venta.AppServices.Response;
using Venta.AppServices.Extentions;
using Venta.AppServices.Core;
using Venta.AppServices.Interfaces;
using Venta.Domain.Entities;
using Venta.Infraestructure.Interface;

namespace Venta.AppServices
{
    public class ProductService : IProductService
    {
        // Atributos
        private readonly ILogger _logger;
        private readonly IConfiguration _configuration;
        private readonly IProductRepository _repository;

        // Constructor
        public ProductService(ILogger<ProductService> logger,
            IProductRepository productRepository,IConfiguration configuration)
        {
            this._logger = logger;
            this._configuration = configuration;
            this._repository = productRepository;
        }

        // Metodos
        // Servicio para Agregar un nuevo Producto
        public async Task<ProductAddResponse> AddProduct(ProductAddDTO productAddDTO)
        {
            ProductAddResponse response = new ProductAddResponse();

            try
            {
                if (!String.IsNullOrEmpty(productAddDTO.Nombre))
                {
                    Products product = productAddDTO.ConvertFromProductAddDtoToProduct();

                    await _repository.Save(product);

                    response.ProductoID = product.ProductoID;
                    response.Nombre = product.Nombre;               
                    response.Mensaje = this._configuration["ProductMessage:AddMessage"] + productAddDTO.Nombre;
                }
                else
                {
                    response.Success = false;
                    response.Mensaje = this._configuration["ProductMessage:NoNombre"];
                    return response;
                }
            }
            catch (Exception e)
            {
                this._logger.LogError(this._configuration["ProductMessage:ErrorGeneral"] + e.Message);
            }

            return response;
        }

        // Servicio Desactiva un Producto
        public async Task<ProductDeleteResponse> DeleteProduct(ProductDeleteDTO productDeleteDTO)
        {
            ProductDeleteResponse response = new ProductDeleteResponse();

            try
            {
                Products productDelete = await this._repository.GetByID(productDeleteDTO.ProductoID);

                if (productDelete != null)
                {
                    productDelete.Disponible = false;

                    await this._repository.Update(productDelete);

                    response.ProductoID = productDelete.ProductoID;
                    response.Nombre = productDelete.Nombre;
                    response.Mensaje = this._configuration["ProductMessage:Removido"] + response.ProductoID;
                }
                else
                {
                    throw new Exception(this._configuration["ProductMessage:NoEncontrada"]);
                }

            }
            catch (Exception e)
            {
                response.Success = false;
                response.Mensaje = e.Message;
                this._logger.LogError(e.Message);
                return response;
            }

            return response;
        }

        // Servicio Otiene todos los Productos
        public async Task<ServicesResponse> GetAllProducts()
        {
            ServicesResponse response = new ServicesResponse();
            try
            {
                response.Data = (await this._repository.GetAllProducts());

                response.Mensaje = this._configuration["ProductMessage:SuccessMessage"];
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Mensaje = this._configuration["ProductMessage:ErrorGeneral"] + e.Message;
                this._logger.LogError(response.Mensaje + e.Message);
            }

            return response;
        }

        // Servicio Obtiene un Producto por su ID
        public async Task<ServicesResponse> GetProductID(int id)
        {
            ServicesResponse response = new ServicesResponse();
            ProductDetailResponse detail = new ProductDetailResponse();
            try
            {
                response.Data = await this._repository.GetByID(id) ;

                response.Mensaje = this._configuration["ProductMessage:SuccessMessage"];
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Mensaje = this._configuration["ProductMessage:ErrorGeneral"] + e.Message;
                this._logger.LogError(response.Mensaje);
                return response;
            }

            return response;
        }

        // Servicio para Actualizar un Producto
        public async Task<ProductUpdateResponse> UpdateProduct(ProductUpdateDTO productUpdateDTO)
        {
            ProductUpdateResponse response = new ProductUpdateResponse();

            try
            {
                Products product = await this._repository.GetByID(productUpdateDTO.ProductoID);

                if (product == null)
                    throw new Exception(this._configuration["ProductMessage:NoEncontrada"]);

                product.Nombre = productUpdateDTO.Nombre;
                product.Descripcion = productUpdateDTO.Descripcion;
                product.Precio = productUpdateDTO.Precio;
                product.Categoria = productUpdateDTO.Categoria;

                await this._repository.Update(product);

                response.ProductoID = product.ProductoID;
                response.Nombre = product.Nombre;
                response.Descripcion = product.Descripcion;
                response.Categoria = product.Categoria;
                response.Mensaje = this._configuration["ProductMessage:Actualizada"] + response.Nombre;
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Mensaje = this._configuration["ProductMessage:ErrorGeneral"] + e.Message;
                this._logger.LogError(response.Mensaje);
            }

            return response;
        }

       
    }
}
