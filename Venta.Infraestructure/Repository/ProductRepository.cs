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
    public class ProductRepository : RepositoryBase<Products>, IProductRepository
    {
        // Atributos
        private readonly ILogger _logger;

        // Constructor
        public ProductRepository(ILogger<ProductRepository> logger, VentaContext context) : base(context)
        {
            this._logger = logger;
        }       


        // Devuelve una LISTA de Productos
        public async Task<List<ProductModel>> GetAllProducts()
        {
            List<ProductModel> lista = new List<ProductModel>();

            try
            {
                lista = (await base.Get())
                                   .Where(pro => pro.Disponible != false)
                                   .Select(pro => new ProductModel() { 
                                        
                                       ProductoID = pro.ProductoID,
                                       Nombre = pro.Nombre,
                                       Descripcion = pro.Descripcion

                                   }).ToList();
            }
            catch (Exception e)
            {
                this._logger.LogError($"Error al obtener las categorias: {e.Message}");
            }

            return lista;
        }

        // Desactiva un Producto
        public async override Task Delete(Products entity)
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

        //// Obtiene un Producto mediante su ID
        public async override Task<Products> GetByID(int entityID)
        {
            Products pro = await base.GetByID(entityID);

            if (pro == null)
                throw new Exception("Producto no encontrado");
            if (pro.Disponible == false)
                throw new Exception("Producto no disponible");

            return pro;
        }






    }
}
