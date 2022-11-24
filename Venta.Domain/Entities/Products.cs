using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Venta.Domain.Entities
{
    [Table("Productos", Schema = "venta")]
    public class Products
    {
        [Key]
        public int ProductoID { get; set; }

        public string? Nombre { get; set; }

        public string? Descripcion { get; set; }

        public decimal Precio { get; set; }

        public int Categoria { get; set; }

        public bool Disponible { get; set; }

    }
}