using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Venta.Domain.Entities
{
    [Table("Categorias", Schema = "venta")]
    public class Category
    {
        [Key]
        public int CategoriaID { get; set; }

        public string? Nombre { get; set; }

        public DateTime CreateDate { get; set; }

        public bool Deleted { get; set; }
    }
}
