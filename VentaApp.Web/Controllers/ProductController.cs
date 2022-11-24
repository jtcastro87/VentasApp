using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VentaApp.Web.Models.Product;
using VentaApp.Web.Models.Product.Core;
using VentaApp.Web.Services.Contracts;

namespace VentaApp.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger _logger;
        private readonly IProductServiceMVC _productServicesMVC;

        public ProductController(ILogger<ProductController> logger,IProductServiceMVC productServiceMVC)
        {
            this._logger = logger;
            this._productServicesMVC = productServiceMVC;
        }


        // Devuelve la Lista de los Productos
        public async Task<ActionResult> Index()
        {
            List<ProductModel> listProduct = new List<ProductModel>();
            try
            {
                listProduct = await _productServicesMVC.GetAllProduct();
            }
            catch (System.Exception e)
            {
                _logger.LogError($"Ha ocurrido un problema: {e.Message}");
            }
            return View(listProduct);
        }


        // Muestra un Producto con todo detalle
        public async Task<ActionResult> Details(int id)
        {
            ProductDetailViewModel productDetailViewModel = new ProductDetailViewModel();
            try
            {
                productDetailViewModel = await _productServicesMVC.GetProductByID(id);
            }
            catch (System.Exception e)
            {
                _logger.LogError(e.Message);
            }

            return View(productDetailViewModel);
        }


        // Llama la Vista para Agregar un Nuevo Producto
        public ActionResult Create()
        {
            return View();
        }


        // Agrega un Nuevo Producto al Listado de producto
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ProductAddViewModel productAddViewModel)
        {
            ProductRequestModel productRequestModel = new ProductRequestModel();

            try
            {
                productRequestModel = await _productServicesMVC.AddNewProduct(productAddViewModel);

                if (productRequestModel.Success)
                    return RedirectToAction(nameof(Index));
                else
                    return null;
            }
            catch(Exception e)
            {
                return View(e.Message);
            }
        }


        // Edit product
        public async Task<ActionResult> Edit(int id)
        {
            ProductDetailViewModel productDetailViewModel = new ProductDetailViewModel();
            try
            {
                productDetailViewModel =  await this._productServicesMVC.GetProductByID(id);
            }
            catch (Exception e)
            {
                _logger.LogError($"No se pudo obtener el producto {e.Message}");
            }

            return View(productDetailViewModel);
        }


        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ProductDetailViewModel productDetailViewModel)
        {
            try
            {
                ProductRequestModel productRequestModel = await _productServicesMVC.UpdateProduct(productDetailViewModel);

                if (!productRequestModel.Success)
                    return View();        
            }
            catch(Exception e)
            {
                _logger.LogError(e.Message);
                return View(e.Message);
            }
            return RedirectToAction(nameof(Index));
        }


        // GET: ProductController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            ProductDetailViewModel deleteProduct = new ProductDetailViewModel();
            try
            {
                deleteProduct = await this._productServicesMVC.GetProductByID(id);
            }
            catch (Exception ex)
            {
                this._logger.LogError($"Ha ocurrido un problema: {ex.Message}");
            }
            return View(deleteProduct);
        }


        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(ProductDetailViewModel deleteProduct)
        {
            ProductRequestModel requestModel = new ProductRequestModel();
            try
            {
                requestModel = await _productServicesMVC.DeleteProduct(deleteProduct);

                if (!requestModel.Success)
                    throw new Exception($"Hay un problema: {requestModel.Message}");
                  
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.Message);
                return View();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
