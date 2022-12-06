using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicEquipmentStore.DataAccessLayer;
using MusicEquipmentStore.Models;
using MusicEquipmentStore.Services;
using Newtonsoft.Json;

namespace MusicEquipmentStore.Controllers
{
    public class ProductsController : Controller
    {

        private IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: ProductsController
        public ActionResult Index()
        {
            //ProductDAL _ProductDAL = new ProductDAL();
            //List<ProductTable> ProductList = new List<ProductTable>();
            _productService.GetProductsDetails();//_ProductDAL.GetAllProducts();
            return View();
        }

        // GET: ProductsController/SearchProduct/5
        //public ActionResult SearchProduct(int id)
        //{
        //    ProductDAL _productDAL = new ProductDAL();
        //    List<ProductTable> list = new List<ProductTable>();
        //    //list = _productDAL.GetProductById();
        //    list = _productDAL.GetAllProducts();
        //    return View(list);
        //}

        //[HttpPost]
        //public string SaveProductDetails(FileUpload file)
        //{
        //    ProductTable products = JsonConvert.DeserializeObject<ProductTable>(file.ProductTable);
        //    if (file.File.Length > 0)
        //    {
        //        using (var ms= new MemoryStream())
        //        {
        //            file.File.CopyTo(ms);
        //            var filebytes = ms.ToArray();
        //            products.Productimage = filebytes;

        //            products = _productService.SaveProductDetails(products);

        //            if(products.ProductId > 0)
        //            {
        //}
        //                return "Saved";
        //            }
        //        }
        //    }
        //    return "Failed";

        [HttpGet]
        public JsonResult GetProductsDetails()
        {
            var product = _productService.GetProductsDetails();
            product.Productimage = this.GetImage(Convert.ToBase64String(product.Productimage));
            ViewBag.Base64String= this.GetImage(Convert.ToBase64String(product.Productimage));
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
