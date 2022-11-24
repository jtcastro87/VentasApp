using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using Venta.AppServices.Core;
using Venta.AppServices.DTO;
using Venta.AppServices.Response;
using Venta.Domain.Entities;
using Venta.AppServices.Extentions;
using Venta.Infraestructure.Interface;
using Venta.AppServices.Interfaces;

namespace Venta.AppServices
{
    public class CategoryService : ICategoryService
    {
        // Atributos de la Clase
        private readonly ICategoryRepository _repository;
        private readonly IConfiguration _configuration;
        private readonly ILogger _logger;

        // Constructor
        public CategoryService(ILogger<CategoryService> logger, ICategoryRepository repository,
                               IConfiguration congiguracion)
        {
            this._repository = repository;
            this._configuration = congiguracion;
            this._logger = logger;
        }

        // Sericio de AGREGAR Categoria
        public async Task<CategoryAddResponse> AddCategory(CategoryAddDTO categoryAddDTO)
        {
            CategoryAddResponse response = new CategoryAddResponse();

            try
            {
                if (!String.IsNullOrEmpty(categoryAddDTO.Nombre))
                {

                    Category category = categoryAddDTO.ConvertFromCategoryDtoToCategory();

                    await _repository.Save(category) ;

                    response.Mensaje = this._configuration["CategoryMessage:AddMessage"] + category.Nombre;
                }
                else
                {
                    response.Success = false;
                    response.Mensaje = this._configuration["CategoryMessage:NoNombre"];
                    response.Data = response;
                    return response;
                }
                
            }
            catch (Exception e)
            {
                this._logger.LogError($"Error al guardar la nueva categoria: {e.Message}");
            }

            return response;
        }

        // Servicio para DESACTIVAR Categoria
        public async Task<CategoryDeleteResponse> DeleteCategory(CategoryDeleteDTO categoryDeleteDTO)
        {
            CategoryDeleteResponse response = new CategoryDeleteResponse();

            try
            {
                Category categoryDelete = await this._repository.GetByID(categoryDeleteDTO.CategoryID);

                if (categoryDelete != null)
                {
                    categoryDelete.Deleted = true;

                    await this._repository.Update(categoryDelete);
                    
                    response.CategoryID = categoryDelete.CategoriaID;
                    response.Nombre = categoryDelete.Nombre;
                    response.Mensaje = this._configuration["CategoryMessage:Removido"] + response.CategoryID;
                }
                else
                {
                    throw new Exception(this._configuration["CategoryMessage:NoEncontrada"]);
                }

            }
            catch (Exception e)
            {
                response.Success = false;
                response.Mensaje = e.Message;
                response.Data = response;
                this._logger.LogError(e.Message);
                return response;
            }

            return response;
        }

        // Servicio para OBTENER todas las Categorias
        public async Task<ServicesResponse> GetAllCategory()
        {
            ServicesResponse response = new ServicesResponse();

            try 
            {
                response.Data = await this._repository.GetCategories();
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Mensaje = this._configuration["CategoryMessage:ErrorGeneral"] + e.Message;
                response.Data = response;
                this._logger.LogError(response.Mensaje + e.Message);

                return response;
            }

            return response;
        }

        // Servicio para OBTENER una Categoria por su ID
        public async Task<ServicesResponse> GetCategoryID(int id)
        {
            ServicesResponse response = new ServicesResponse();
            CategoryDetailResponse detail = new CategoryDetailResponse();

            try
            {
                Category cat = await this._repository.GetByID(id);

                detail.CategoriaID = cat.CategoriaID;
                detail.Nombre = cat.Nombre;
                detail.Fecha = cat.CreateDate;

                response.Data = detail;

                response.Mensaje = this._configuration["CategoryMessage:SuccessMessage"];
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Mensaje = this._configuration["CategoryMessage:ErrorGeneral"] + e.Message;
                this._logger.LogError(response.Mensaje);
                return response;
            }

            return response;
        }

        // Servicio Actualiza una Categoria
        public async Task<CategoryUpdateResponse> UpdateCategory(CategoryUpdateDTO categoryUpdateDTO)  
        {
            CategoryUpdateResponse response = new CategoryUpdateResponse();

            try
            {
                if(!String.IsNullOrEmpty(categoryUpdateDTO.Nombre))
                {
                    Category category = await this._repository.GetByID(categoryUpdateDTO.CategoryID);

                    category.Nombre = categoryUpdateDTO.Nombre;

                    await this._repository.Update(category);
                    
                    response.Nombre = category.Nombre;
                    response.Mensaje = this._configuration["CategoryMessage:Actualizada"] + response.Nombre;
                }
                else
                {
                    throw new Exception(this._configuration["CategoryMessage:NoNombre"]);
                }
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Mensaje = this._configuration["CategoryMessage:ErrorGeneral"] + e.Message;
                this._logger.LogError(response.Mensaje);
            }

            return response;
        }
    }
}
