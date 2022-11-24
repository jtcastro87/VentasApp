using System.ComponentModel.DataAnnotations;

namespace Venta.AppServices.DTO
{
    public class CategoryAddDTO
    {
        [Required (ErrorMessage ="El nombre es requerido"),MinLength(3)]        
        public string Nombre { get; set; }
    }
}
