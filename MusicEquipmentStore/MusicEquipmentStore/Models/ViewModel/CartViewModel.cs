using Microsoft.AspNetCore.Components.Routing;
using System.Runtime.InteropServices;

namespace MusicEquipmentStore.Models.ViewModel
{
    public class CartViewModel
    {
        
        public List<CartItem> CartItems { get; set; }
        public decimal GrandTotal { get; set; }


    }
}
