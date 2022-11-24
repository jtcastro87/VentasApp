using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using VentaApp.Web.Models.Category;
using VentaApp.Web.Services.Contracts;

namespace VentaApp.Web.Services
{
    public class CategoryServicesMVC : ICategoryServicesMVC
    {
        // Atributos
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly ILogger _logger;
        private readonly string baseURl;

        //Constructor
        public CategoryServicesMVC(ILogger<CategoryServicesMVC> logger,IHttpClientFactory httpClientFactory,IConfiguration configuration)
        {
            this._logger = logger;
            this._httpClientFactory = httpClientFactory;
            this._configuration = configuration;
            this.baseURl = this._configuration["APICategory:URL"];
        }

        // Servicio Agrega una Nueva Categoria
        public async Task<CategoryRequest> AddCategory(CategoryAddViewModel categoryAddViewModel)
        {
            CategoryRequest request = new CategoryRequest();
            CategoryAddModel categoryAddModel = new CategoryAddModel()
            {
                Nombre = categoryAddViewModel.Nombre
            };

            try
            {
                using (var httpClient = this._httpClientFactory.CreateClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(categoryAddModel), Encoding.UTF8, "application/json");

                    using (var response = await httpClient.PostAsync($"{this.baseURl}/AddCategory", content))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var result = await response.Content.ReadAsStringAsync();

                            request = JsonConvert.DeserializeObject<CategoryRequest>(result);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                _logger.LogError($"Error al guardar nueva categoria: {e.Message}");
            }

            return request;

        }

        // Servicio Delete Category
        public async Task<CategoryRequest> DeleteCategory(CategoryDeleteViewModel categoryDeleteViewModel)
        {
            CategoryRequest request = new CategoryRequest();

            CategoryDeleteModel categoryDeleteModel = new CategoryDeleteModel() { CategoryID = categoryDeleteViewModel.CategoryID };

            try
            {
                using (var httpClient = this._httpClientFactory.CreateClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(categoryDeleteModel), Encoding.UTF8, "application/json");

                    using (var response = await httpClient.PostAsync($"{this.baseURl}/DeleteCategory",content))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var result = await response.Content.ReadAsStringAsync();

                            request = JsonConvert.DeserializeObject<CategoryRequest>(result);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                this._logger.LogError($"Ocurrio un problema eliminando la categoria {categoryDeleteModel}: {e.Message}");
            }

            return request;
        }

        // Servicio Obtiene todas la categorias
        public async Task<List<CategoryModel>> GetAllCategory()
        {
            List<CategoryModel> categoria = new List<CategoryModel>();

            try
            {
                using (var httpClient = this._httpClientFactory.CreateClient())
                {
                    using (var response = await httpClient.GetAsync($"{this.baseURl}/GetAllCategory")) // Hace la consulta al API 
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var result = await response.Content.ReadAsStringAsync();

                            categoria = (JsonConvert.DeserializeObject<CategoryViewModel>(result)).Data;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                this._logger.LogError($"Error obteniendo las categorias: {e.Message}");
            }

            return categoria;
        }

        // Servicio Obtiene una Categoria desde API de Categorias
        public async Task<CategoryModel> GetByID(int id)
        {
            CategoryModel category = new CategoryModel();

            try
            {
                using (var httpClient = this._httpClientFactory.CreateClient())
                {
                    using (var response = await httpClient.GetAsync($"{this.baseURl}/categoryID?categoryID={id}"))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var result = await response.Content.ReadAsStringAsync();

                            category = (JsonConvert.DeserializeObject<CategoryDetailViewModel>(result)).DataModel;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                this._logger.LogError($"Ocurrio un problema obteniendo la categoria {id} : {e.Message}");
            }

            return category;
        }

        // Servicio Actializa una Categoria
        public async Task<CategoryRequest> UpdateCategory(CategoryModel categoryModel)
        {
            CategoryRequest request = new CategoryRequest();

            CategoryUpdateModel categoryUpdateModel = new CategoryUpdateModel()
            {
                CategoryID = categoryModel.CategoryID,
                Nombre = categoryModel.Nombre
            };

            try
            {
                using (var httpClient = this._httpClientFactory.CreateClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(categoryUpdateModel), Encoding.UTF8, "application/json");

                    using (var response = await httpClient.PostAsync($"{this.baseURl}/Updatecategory", content))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var result = await response.Content.ReadAsStringAsync();

                            request = JsonConvert.DeserializeObject<CategoryRequest>(result);
                        }
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }

            return request;
        }






    }
}
