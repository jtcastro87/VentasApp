using Venta.AppServices.DTO;
using Venta.Domain.Entities;

namespace Venta.AppServices.Extentions
{
    public static class CategoryExtention
    {
        public static Category ConvertFromCategoryDtoToCategory(this CategoryAddDTO categoryAddDTO)
        {
            Category category = new Category()
            {
                Nombre = categoryAddDTO.Nombre,
                CreateDate = System.DateTime.Now,
                Deleted = false                
            };
           
            return category;
        }
    }
}
