using MusicEquipmentStore.Context;
using MusicEquipmentStore.Models;

namespace MusicEquipmentStore.Services
{
    public class ProductService : IProductService
    {
        private readonly DatabaseContext _context;

        public ProductService(DatabaseContext context)
        {
            _context = context;
        }
        public Products GetProductsDetails()
        {
            return _context.Products.SingleOrDefault();
        }


        public Products SaveProductDetails(Products products)
        {
            _context.Products.Add(products);
            _context.SaveChanges();
            return products;
        }
    }
}
