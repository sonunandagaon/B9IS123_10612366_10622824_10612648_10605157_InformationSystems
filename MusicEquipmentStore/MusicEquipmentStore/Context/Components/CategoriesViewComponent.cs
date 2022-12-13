using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicEquipmentStore.Context;



namespace MusicEquipmentStore.Context.Components
{
    public class CategoriesViewComponent : ViewComponent
    {
        private readonly MusicEquipmentStoreContext _context;



        public CategoriesViewComponent(MusicEquipmentStoreContext context)
        {
            _context = context;
        }



        public async Task<IViewComponentResult> InvokeAsync() => View(await _context.Categories.ToListAsync());
    }
}
