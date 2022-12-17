namespace MusicEquipmentStore.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductPrice { get; set; }
        public int ProductId { get; set; }
        public string ProductQuantity { get; set; }
        public string UserName { get; set; }
       // public string? UserAddress { get; set; }
    }
}