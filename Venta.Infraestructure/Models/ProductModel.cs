using System.ComponentModel.DataAnnotations;

namespace Venta.Infraestructure.Models
{
    public class ProductModel
    {
        [Key]
        public int ProductoID { get; set; }

        public string? Nombre { get; set; }

        public string? Descripcion { get; set; }
    }
}
