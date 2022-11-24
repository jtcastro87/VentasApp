using Venta.AppServices.DTO;
using Venta.Domain.Entities;

namespace Venta.AppServices.Extentions
{
    public static class ProductExtention
    {
        public static Products ConvertFromProductAddDtoToProduct(this ProductAddDTO productAddDTO)
        {
            return new Products() { 
                
                Nombre = productAddDTO.Nombre,
                Descripcion = productAddDTO.Descripcion,
                Precio = productAddDTO.Precio,
                Categoria = productAddDTO.Categoria,
                Disponible = true
            };
        }
    }
}
