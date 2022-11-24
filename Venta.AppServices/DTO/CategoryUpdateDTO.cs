using System.ComponentModel.DataAnnotations;

namespace Venta.AppServices.DTO
{
    public class CategoryUpdateDTO
    {
        [Required (ErrorMessage ="El ID es requerido")]
        public int CategoryID { get; set; }

        [MinLength(5,ErrorMessage ="El nombre de la categoria no es valido")]
        public string Nombre { get; set; }

    }
}
