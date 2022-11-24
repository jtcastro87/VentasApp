using Microsoft.EntityFrameworkCore;
using Venta.Domain.Entities;
using Venta.Infraestructure.Models;

namespace Venta.Infraestructure.Context
{
    public class VentaContext : DbContext
    {
        private readonly DbContextOptions _options;

        public VentaContext(DbContextOptions<VentaContext> options) : base(options)
        {
            this._options = options;
        }

        public DbSet<Products>? Products { get; set; }
        public DbSet<Category>? Category { get; set; }

        public DbSet<CategoryModel>? CategoryModel { get; set; }
        public DbSet<ProductModel>? ProductModel { get; set; }
       // public DbSet<ProductCategoryModel> ProductCategoryModel { get; set; }




    }
}
