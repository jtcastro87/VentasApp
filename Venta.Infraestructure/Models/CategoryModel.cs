using System.ComponentModel.DataAnnotations;

namespace Venta.Infraestructure.Models
{
    public class CategoryModel
    {
        [Key]
        public int CategoriaID { get; set; }

        public string? Nombre { get; set; }
    }
}
