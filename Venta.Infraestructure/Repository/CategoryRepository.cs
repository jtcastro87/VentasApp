using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Venta.Domain.Entities;
using Venta.Infraestructure.Context;
using Venta.Infraestructure.Core;
using Venta.Infraestructure.Interface;
using Venta.Infraestructure.Models;

namespace Venta.Infraestructure.Repository
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        private readonly ILogger _logger;

        public CategoryRepository(VentaContext context,ILogger<CategoryRepository> logger) : base(context)
        {
            this._logger = logger;
        }

        // Devuelve una lista de Categoria
        public async Task<List<CategoryModel>> GetCategories()
        {
            List<CategoryModel> listCategory = new List<CategoryModel>();
            try
            {
                listCategory = (await base.Get())
                                          .Where(cat => cat.Deleted != true)
                                          .Select(cat => new CategoryModel()
                                          {
                                              CategoriaID = cat.CategoriaID,
                                              Nombre = cat.Nombre
                                          }).ToList();
            }
            catch (Exception e)
            {
                this._logger.LogError($"Error al obtener las categorias: {e.Message}");
            }
            return listCategory;
        }

        // Deshabilita una Categoria
        public async override Task Delete(Category entity)
        {
            try
            {
                await base.Update(entity);
            }
            catch (Exception e)
            {
                this._logger.LogError($"Error al eliminar el registro {e.Message}");
            }
            
        }

        // Obtiene una categoria por su ID
        public async override Task<Category> GetByID(int entityID)
        {
            Category cat = await base.GetByID(entityID);

            if (cat == null)
                throw new Exception("Categoria no encontrada");
            if (cat.Deleted == true)
                throw new Exception("Categoria no disponible");

            return cat;
        }



    }
}
