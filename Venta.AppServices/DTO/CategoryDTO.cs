using System.ComponentModel.DataAnnotations;

namespace Venta.AppServices.DTO
{
    public class CategoryDTO
    {
        [Required(ErrorMessage="El ID es requerido")]
        public int CategoriaID { get; set; }
    }
}
