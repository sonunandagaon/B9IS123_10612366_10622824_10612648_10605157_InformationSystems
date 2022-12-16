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
