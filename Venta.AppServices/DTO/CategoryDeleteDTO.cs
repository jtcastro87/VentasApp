using System.ComponentModel.DataAnnotations;

namespace Venta.AppServices.DTO
{
    public class CategoryDeleteDTO
    {
        [Required(ErrorMessage="Este ID es requerido")]
        public int CategoryID { get; set; }
    }
}
