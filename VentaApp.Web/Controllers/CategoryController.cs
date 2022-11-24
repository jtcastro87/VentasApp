using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using VentaApp.Web.Models;
using VentaApp.Web.Models.Category;
using VentaApp.Web.Services.Contracts;

namespace VentaApp.Web.Controllers
{
    public class CategoryController : Controller
    {
        // Atributos
        private readonly ILogger _logger;
        private  ICategoryServicesMVC _categoryServicesMVC;
 
        // Constructor
        public CategoryController(ICategoryServicesMVC categoryServicesMVC,ILogger<CategoryController> logger)
        {
            this._logger = logger;
            this._categoryServicesMVC = categoryServicesMVC;
        }


        // GET: CategoryController 
        public async Task<ActionResult> Index()
        {
            List<CategoryModel> categoryModels = new List<CategoryModel>();
            try
            {
                categoryModels = await this._categoryServicesMVC.GetAllCategory();
            }
            catch (Exception e)
            {
                this._logger.LogError($"Ocurrio un problema: {e.Message}");
            }

            return View(categoryModels);
        }

        // GET: CategoryController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            CategoryModel cat = new CategoryModel();

            try
            {
                cat = await this._categoryServicesMVC.GetByID(id);
            }
            catch (Exception e)
            {
                this._logger.LogError($"Ocurrio un problema al obtener la categoria: {e.Message}");
            }
            return View(cat);
        }

        // GET: CategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CategoryAddViewModel categoryAddViewModel)
        {
            CategoryRequest request = new CategoryRequest();
            try
            {

                request = await this._categoryServicesMVC.AddCategory(categoryAddViewModel);

                if (request.Success)
                    return RedirectToAction(nameof(Index));
                else
                    this._logger.LogError(request.Mensaje); ;
            }
            catch
            {
                return View();
            }

            return null;
        }


        // GET: CategoryController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            CategoryModel categoryEdit = new CategoryModel();
            try
            {
                categoryEdit = await this._categoryServicesMVC.GetByID(id);
            }
            catch (Exception e)
            {
                this._logger.LogError($"No se pudo actualizar la Categoria: {e.Message}");
            }

            return View(categoryEdit);
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(CategoryModel categoryModel)
        {            
            try
            {
                CategoryRequest request =  await this._categoryServicesMVC.UpdateCategory(categoryModel);

                if (request.Success)
                    return RedirectToAction(nameof(Index));
                else
                    this._logger.LogError(request.Mensaje);
            }
            catch(Exception e)
            {
                return View(e.Message);
            }

            return null;
        }

        // GET: CategoryController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            CategoryModel categoryDelete = new CategoryModel();
            try
            {
                categoryDelete = await this._categoryServicesMVC.GetByID(id);
            }
            catch (Exception e)
            {
                this._logger.LogError($"No se pudo actualizar la Categoria: {e.Message}");
            }

            return View(new CategoryDeleteViewModel()
            {
                CategoryID = categoryDelete.CategoryID,
                Nombre = categoryDelete.Nombre
            });
            // return View(categoryDelete);
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(CategoryDeleteViewModel categoryDeleteViewModel)
        {
            try
            {
                CategoryRequest request = await this._categoryServicesMVC.DeleteCategory(categoryDeleteViewModel);

                if (request.Success)
                    return RedirectToAction(nameof(Index));
                else
                    this._logger.LogError(request.Mensaje);
            }
            catch(Exception e)
            {
                return View(e.Message);
            }

            return View();
        }
    }
}
