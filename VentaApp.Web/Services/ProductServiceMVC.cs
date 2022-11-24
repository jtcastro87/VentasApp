using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using VentaApp.Web.Models.Product;
using VentaApp.Web.Models.Product.Core;
using VentaApp.Web.Services.Contracts;

namespace VentaApp.Web.Services
{
    public class ProductServiceMVC : IProductServiceMVC
    {
        // Atributos
        private string baseURL;
        private readonly ILogger _logger;
        private readonly IConfiguration _configuration;
        private readonly IHttpClientFactory _httpClientFactory;
        
        // Constructor
        public ProductServiceMVC(ILogger<ProductServiceMVC> logger, IConfiguration configuration,
                                 IHttpClientFactory httpClientFactory)
        {
            this._logger = logger;
            this._configuration = configuration;
            this._httpClientFactory = httpClientFactory;
            this.baseURL = this._configuration["APIProduct:URL"];
        }

        // Servicio para Agregar un Producto
        public async Task<ProductRequestModel> AddNewProduct(ProductAddViewModel productAddViewModel)
        {
            ProductRequestModel productRequestModel = new ProductRequestModel();
            try
            {
                using(var httpClient = _httpClientFactory.CreateClient())
                {
                    StringContent stringContent = new StringContent(JsonConvert.SerializeObject(productAddViewModel), Encoding.UTF8, "application/json");

                    using (var response = await httpClient.PostAsync($"{this.baseURL}/AddProduct", stringContent) )
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var result = await response.Content.ReadAsStringAsync();

                            productRequestModel = JsonConvert.DeserializeObject<ProductRequestModel>(result);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                _logger.LogError($"No se pudo agregar el producto. {e.Message}");
            }

            return productRequestModel;
        }

        // Servicio para Obtener todos los Productos
        public async Task<List<ProductModel>> GetAllProduct()
        {
            List<ProductModel> listProduct = new List<ProductModel>();

            try
            {
                using (var httpClient = _httpClientFactory.CreateClient())
                {
                    using (var response = await httpClient.GetAsync($"{this.baseURL}/GetProducts"))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var result = await response.Content.ReadAsStringAsync();

                            listProduct = (JsonConvert.DeserializeObject<ProductViewModel>(result)).Data;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                _logger.LogError($"Error al llamar la lista de productos: {e.Message}");
            }

            return listProduct;
        }

        // Servicio Devuelve un Producto
        public async Task<ProductDetailViewModel> GetProductByID(int id)
        {
            ProductDetailViewModel productDetailView = new ProductDetailViewModel();
            try
            {
                using (var httpClient = _httpClientFactory.CreateClient())
                {
                    using (var response = await httpClient.GetAsync($"{this.baseURL}/GetProductID?id={id}"))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var result = await response.Content.ReadAsStringAsync();

                            productDetailView = (JsonConvert.DeserializeObject<ProductDetailViewModel>(result)).Data;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                _logger.LogError($"Ocurrio un problema obteniendo el producto. {e.Message}");
            }

            return productDetailView;
        }

        // Servicio Actualiza un Producto
        public async Task<ProductRequestModel> UpdateProduct(ProductDetailViewModel productDetailViewModel)
        {
            ProductRequestModel productRequestModel = new ProductRequestModel();

            try
            {
                using (var httpClient = _httpClientFactory.CreateClient())
                {
                    StringContent stringContent = new StringContent(JsonConvert.SerializeObject(productDetailViewModel), Encoding.UTF8, "application/json");

                    using (var response = await httpClient.PostAsync($"{this.baseURL}/UpdateProduct", stringContent))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var result = await response.Content.ReadAsStringAsync();

                            productRequestModel = JsonConvert.DeserializeObject<ProductRequestModel>(result);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                _logger.LogError($"No se pudo actualizar el producto {e.Message}");                
            }

            return productRequestModel;
        }

        // Servicio Elimina un Producto
        public async  Task<ProductRequestModel> DeleteProduct(ProductModel productModel)
        {
            ProductRequestModel request = new ProductRequestModel();
            ProductDeleteModel productDeleteModel = new ProductDeleteModel()
            {
                ProductID = productModel.ProductoID
            };

            try
            {
                using (var httpClient = _httpClientFactory.CreateClient())
                {
                    StringContent stringContent = new StringContent(JsonConvert.SerializeObject(productDeleteModel), Encoding.UTF8, "application/json");

                    using (var response = await httpClient.PostAsync($"{this.baseURL}/DeleteProduct", stringContent))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var result = await response.Content.ReadAsStringAsync();

                            request = JsonConvert.DeserializeObject<ProductRequestModel>(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.Message);
                request.Success = false;
                request.Message = $"No se pudo eliminar el producto. {ex.Message}";
            }

            return request;
        }





    }
}
