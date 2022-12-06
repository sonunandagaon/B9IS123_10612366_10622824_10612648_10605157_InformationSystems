
using MusicEquipmentStore.Models;

namespace MusicEquipmentStore.Services
{
    public class ProductService : IProductService
    {
        //private readonly DatabaseContext _context;

        protected ProductsContext _patternDbContext;
        public ProductService(ProductsContext patternDbContext)
        {
            _patternDbContext = patternDbContext;
        }

        //public ProductService(DatabaseContext context)
        //{
        //    _context = context;
        //}

        public ProductTable GetProductsDetails()
        {
            return _patternDbContext.ProductTables.SingleOrDefault();
        }


        public List<ProductTable> GetAllProducts()
        {
            //_context.Products.Add(prod);
            //_context.SaveChanges();
            //return result.ToList();
            return _patternDbContext.ProductTables.ToList();
        }

        public ProductTable SaveProductDetails(ProductTable products)
        {
            _patternDbContext.ProductTables.Add(products);
            _patternDbContext.SaveChanges();
             return products;
        }
    }
}
