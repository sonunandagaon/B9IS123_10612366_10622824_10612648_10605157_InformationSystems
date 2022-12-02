using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicEquipmentStore.DataAccessLayer;
using MusicEquipmentStore.Models;

namespace MusicEquipmentStore.Controllers
{
    public class ProductsController : Controller
    {
      

        // GET: ProductsController
        public ActionResult Index()
        {
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
