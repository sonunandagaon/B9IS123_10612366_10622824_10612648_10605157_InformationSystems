using MusicEquipmentStore.Models;

namespace MusicEquipmentStore.Services
{
        public interface IProductService
        {
            Products SaveProductDetails(Products products);

            Products GetProductsDetails();
        }
    
}
