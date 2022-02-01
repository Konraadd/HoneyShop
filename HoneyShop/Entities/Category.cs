namespace HoneyShop.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Product> Products { get; set; }

        internal object Include(string v)
        {
            throw new NotImplementedException();
        }
    }
}
