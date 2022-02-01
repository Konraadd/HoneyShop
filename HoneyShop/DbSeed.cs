using HoneyShop.Entities;

namespace HoneyShop
{
    public class DbSeed
    {
        private readonly HoneyShopDbContext _dbContext;
        public DbSeed(HoneyShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                if (!_dbContext.Categories.Any())
                {
                    var categories = GetCategories();
                    _dbContext.Categories.AddRange(categories);
                    _dbContext.SaveChanges();
                }
                if (!_dbContext.Inventory.Any())
                {
                    var inventories = GetInventories();
                    _dbContext.Inventory.AddRange(inventories);
                    _dbContext.SaveChanges();
                }
            }
        }

        private IEnumerable<Category> GetCategories()
        {
            var categories = new List<Category>()
            {
                new Category() {
                    Name = "Honey",
                    Products = new List<Product>()
                    {
                        new Product() {
                            Name = "Miód lipowy",
                            Price = 35,
                            Size = "700ml"
                        },
                        new Product() {
                            Name = "Miód akacjowy",
                            Price = 32,
                            Size = "700ml"
                        },
                        new Product()
                        {
                            Name = "Miód gryczany",
                            Price = 37,
                            Size = "500ml"
                        }
                    },
                },
                new Category() { 
                    Name = "Equipment",
                    Products =new List<Product>()
                    {
                        new Product {
                            Name = "Ul",
                            Price = 60,
                        },
                        new Product
                        {
                            Name = "Strój pszczelarza",
                            Price = 120,
                        }
                    }
                },
                new Category() { 
                    Name = "Flower seeds",
                    Products =new List<Product>()
                    {
                        new Product {
                            Name = "Nasiona fiołków",
                            Size = "50 nasion",
                            Price = 4
                        },
                        new Product {
                            Name = "Nasiona wiosennych kwiatów, nie wiem nie znam się",
                            Size = "50 nasion",
                            Price = 4
                        },
                        new Product() {
                            Name = "Nasiona fiołków",
                            Size = "10 nasion",
                            Price = 0.50M
                        }
                    }
                }
            };

            return categories;
        }

        private IEnumerable<Inventory> GetInventories()
        {
            Random random = new Random();

            var inventories = new List<Inventory>();

            var products = _dbContext.Products;

            foreach(var product in products)
            {
                int quantity = random.Next(10, 1000);
                int reservedQuantity = random.Next(0, 1000 - quantity);

                inventories.Add(
                    new Inventory()
                    {
                        ProductId = product.Id,
                        Quantity = quantity,
                        ReservedQuantity = reservedQuantity
                    });
            }

            return inventories;
        }
    }
}
