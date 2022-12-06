using MusicEquipmentStore.Models;

namespace MusicEquipmentStore.Services
{
    public interface IProductService
    {
        ProductTable SaveProductDetails(ProductTable products);

        List<ProductTable> GetAllProducts();

        ProductTable GetProductsDetails();
    }

}
