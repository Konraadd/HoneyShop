namespace HoneyShop.Entities
{
    public class Inventory
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public virtual int AvailableQuantity { get => Quantity - ReservedQuantity;}
        public int ReservedQuantity { get; set; }
        public int Quantity { get; set; }
    }
}
