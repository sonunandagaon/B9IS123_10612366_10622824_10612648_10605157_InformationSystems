﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicEquipmentStore.DataAccessLayer;
using MusicEquipmentStore.Models;
using MusicEquipmentStore.Services;
using Newtonsoft.Json;

namespace MusicEquipmentStore.Controllers
{
    public class ProductsController : Controller
    {

        IProductService _productService = null;

        ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: ProductsController
        public ActionResult Index()
        {
            ProductDAL _ProductDAL = new ProductDAL();
            List<Products> ProductList = new List<Products>();
            ProductList = _ProductDAL.GetAllProducts();
            return View();
        }

        // GET: ProductsController/SearchProduct/5
        public ActionResult SearchProduct(int id)
        {
            ProductDAL _productDAL = new ProductDAL();
            List<Products> list = new List<Products>();
            //list = _productDAL.GetProductById();
            list = _productDAL.GetAllProducts();
            return View(list);
        }

        [HttpPost]
        public string SaveProductDetails(FileUpload file)
        {
            Products products = JsonConvert.DeserializeObject<Products>(file.Product);
            if (file.File.Length > 0)
            {
                using (var ms= new MemoryStream())
                {
                    file.File.CopyTo(ms);
                    var filebytes = ms.ToArray();
                    products.Photo = filebytes;

                    products = _productService.SaveProductDetails(products);

                    if(products.ProductId > 0)
                    {
                        return "Saved";
                    }
                }
            }
            return "Failed";
        }

        [HttpGet]
        public JsonResult GetProductsDetails()
        {
            var product = _productService.GetProductsDetails();
            product.Photo = this.GetImage(Convert.ToBase64String(product.Photo));
            return Json(product);
        }

        public byte[] GetImage(string base64string)
        {
            byte[] bytes = null;
            if (!string.IsNullOrEmpty(base64string))
            {
                bytes = Convert.FromBase64String(base64string);
            }
            return bytes;
        }

        // GET: ProductsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
