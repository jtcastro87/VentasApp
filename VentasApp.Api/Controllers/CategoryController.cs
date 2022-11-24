using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Venta.AppServices.Core;
using Venta.AppServices.DTO;
using Venta.AppServices.Interfaces;
using Venta.AppServices.Response;

namespace VentasApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        // Atributos
        private readonly ICategoryService _categoryService;

        // Constructor
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        //API para AGREGAR una nueva Categoria
        [HttpPost("AddCategory")]
        public async Task<ActionResult<CategoryAddResponse>> AddCategory(CategoryAddDTO categoryAddDTO)
        {
            CategoryAddResponse response = new CategoryAddResponse();

            response = await this._categoryService.AddCategory(categoryAddDTO);

            return Ok(response);
        }

        // API para DESHABILITAR una Categoria
        [HttpPost("DeleteCategory")]
        public async Task<ActionResult<CategoryDeleteResponse>> DeleteCategory(CategoryDeleteDTO categoryDeleteDTO)
        {
            CategoryDeleteResponse response = new CategoryDeleteResponse();

            response = await this._categoryService.DeleteCategory(categoryDeleteDTO);

            return Ok(response);
        }

        // API para obtener una LiSTA de Categorias
        [HttpGet("GetAllCategory")]
        public async Task<ActionResult<IEnumerable<ServicesResponse>>> GetAllCategory()
        {
            ServicesResponse response = new ServicesResponse();

            response = await this._categoryService.GetAllCategory();

            return Ok(response);
        }

        // API para BUSCAR una Categoria por su ID
        [HttpGet("categoryID")]
        public async Task<ActionResult<ServicesResponse>> GetCategoryID(int categoryID)
        {
            ServicesResponse response = new ServicesResponse();

            response = await this._categoryService.GetCategoryID(categoryID);

            return Ok(response);
        }

        // API para Actualizar una categoria
        [HttpPost("UpdateCategory")]
        public async Task<ActionResult<CategoryUpdateResponse>> UpdateCategory(CategoryUpdateDTO categoryUpdateDTO)
        {
            CategoryUpdateResponse response = new CategoryUpdateResponse();

            response = await this._categoryService.UpdateCategory(categoryUpdateDTO);

            return Ok(response);
        }

         


    }
}
