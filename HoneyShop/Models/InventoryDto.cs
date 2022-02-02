using HoneyShop.Entities;

namespace HoneyShop.Models
{
    public class InventoryDto
    {
        public int Id { get; set; }
        public Product Product{ get; set; }
        public int AvailableQuantity { get => Quantity - ReservedQuantity; }
        public int ReservedQuantity { get; set; }
        public int Quantity { get; set; }
    }
}
