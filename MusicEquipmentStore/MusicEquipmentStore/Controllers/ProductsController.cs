using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicEquipmentStore.Context;
using MusicEquipmentStore.Models;
using MusicEquipmentStore.Models.ViewModel;

namespace MusicEquipmentStore.Controllers
{
    public class ProductsController : Controller
    {
        private readonly MusicEquipmentStoreContext _context;

        public ProductsController(MusicEquipmentStoreContext context)
        {
            _context = context;
        }

        //public async Task<IActionResult> Products(string categorySlug = "", int p = 1)
        //{
        //    int pageSize = 3;
        //    ViewBag.PageNumber = p;
        //    ViewBag.PageRange = pageSize;
        //    ViewBag.CategorySlug = categorySlug;

        //    if (categorySlug == "")
        //    {
        //        ViewBag.TotalPages = (int)Math.Ceiling((decimal)_context.Products.Count() / pageSize);

        //        return View(await _context.Products.OrderByDescending(p => p.Id).Skip((p - 1) * pageSize).Take(pageSize).ToListAsync());
        //    }

        //    Category category = await _context.Categories.Where(c => c.Slug == categorySlug).FirstOrDefaultAsync();
        //    if (category == null) return RedirectToAction("Index");

        //    var productsByCategory = _context.Products.Where(p => p.CategoryId == category.Id);
        //    ViewBag.TotalPages = (int)Math.Ceiling((decimal)productsByCategory.Count() / pageSize);

        //    return View(await productsByCategory.OrderByDescending(p => p.Id).Skip((p - 1) * pageSize).Take(pageSize).ToListAsync());
        //}

        public async Task<IActionResult> ViewProduct(int id)
        {
            ProductViewModel productViewModel = new ProductViewModel();
            //productViewModel.Products = await _context.Products.Where(x => x.Id == id).Include(y=>y.CategoryId).FirstOrDefaultAsync();
            productViewModel.Products = await _context.Products.Where(x => x.Id == id).FirstOrDefaultAsync();
            return View(productViewModel);
        }

        public async Task<IActionResult> AddProduct(int id)
        {
            ProductViewModel productViewMode = new ProductViewModel();
            //productViewModel.Products = await _context.Products.Where(x => x.Id == id).Include(y=>y.CategoryId).FirstOrDefaultAsync();
            productViewMode.Products = await _context.Products.Where(x => x.Id == id).FirstOrDefaultAsync();
            return View(productViewMode);
        }
    }
}
