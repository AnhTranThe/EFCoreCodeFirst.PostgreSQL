using EFCoreCodeFirst.PostgreSQL.Entity;

namespace EFCoreCodeFirst.PostgreSQL.Data
{
    public class DummyData
    {
        public static List<string> LsUserId = new();
        public static List<string> LsProductId = new();
        public static List<string> LsUserOrderId = new();
        private readonly AppDbContext _context;

        public DummyData(AppDbContext context)
        {
            _context = context;
        }


        // Method to seed initial data
        public async Task SeedDataAsync()
        {
            if (!_context.Products.Any())
            {
                List<Product> dummyProducts = DummyData.GetDummyProducts();
                await _context.Products.AddRangeAsync(dummyProducts);
            }


            if (!_context.Users.Any())
            {
                List<User> dummyUsers = DummyData.GetDummyUsers();
                await _context.Users.AddRangeAsync(dummyUsers);
            }


            if (!_context.UserOrders.Any())
            {
                List<UserOrder> dummyUserOrders = DummyData.GetDummyUserOrders();
                await _context.UserOrders.AddRangeAsync(dummyUserOrders);
            }

            if (!_context.UserOrderProducts.Any())
            {
                List<UserOrderProduct> dummyUserOrderProducts = DummyData.GetDummyUserOrderProducts();
                await _context.UserOrderProducts.AddRangeAsync(dummyUserOrderProducts);
            }

            // Similarly, add seeding for UserDetail, UserOrder, and UserOrderProduct entities if needed

            _ = await _context.SaveChangesAsync();
        }



        public static List<Product> GetDummyProducts()
        {
            List<Product> products = new();

            for (int i = 1; i <= 50; i++)
            {
                string newProductId = Guid.NewGuid().ToString();
                products.Add(new Product
                {
                    Id = newProductId,
                    ProductName = $"Product {i}",
                    Quantity = i * 2,
                    Price = 10 + (i * 5) // Some dummy price calculation
                });
                LsProductId.Add(newProductId);
            }

            return products;
        }

        public static List<User> GetDummyUsers()
        {
            List<User> users = new();

            for (int i = 1; i <= 50; i++)
            {
                string newUserId = Guid.NewGuid().ToString();
                users.Add(new User
                {
                    Id = newUserId,
                    Name = $"User {i}",
                    Email = $"user{i}@example.com",
                    Password = $"password{i}",
                    EmailConfirmed = true,
                    UserDetail = new UserDetail
                    {
                        Id = Guid.NewGuid().ToString(),
                        UserId = newUserId,
                        Avatar = $"avatar_{i}.jpg",
                        Age = 20 + i,
                        Birthday = DateTimeOffset.Now.AddYears(-20 - i)
                    },

                });
                LsUserId.Add(newUserId);
            }

            return users;
        }



        public static List<UserOrder> GetDummyUserOrders()
        {
            List<UserOrder> userOrders = new();


            for (int i = 0; i < 50; i++)
            {
                string newUserOrderId = Guid.NewGuid().ToString();
                string MapUserId = GetRandomId(LsUserId);
                userOrders.Add(new UserOrder
                {
                    Id = newUserOrderId,
                    Status = i % 2 == 0 ? "Pending" : "Completed",
                    TotalPrice = 100 + (i * 5),
                    UserId = MapUserId
                });
                LsUserOrderId.Add(newUserOrderId);
            }

            return userOrders;
        }

        public static List<UserOrderProduct> GetDummyUserOrderProducts()
        {
            List<UserOrderProduct> userOrderProducts = new();

            for (int i = 0; i < 50; i++)
            {
                string MapProductId = GetRandomId(LsProductId);
                string MapUserOrderId = GetRandomId(LsUserOrderId);
                userOrderProducts.Add(new UserOrderProduct
                {
                    ProductId = MapProductId,
                    UserOrderId = MapUserOrderId,
                    Quantity = 1 + (i % 5),
                    CurrentPrice = 20 + (i % 10),
                    Note = $"Note for product {i + 1}",
                    Discount = i % 3 == 0 ? 5 : null
                });
            }

            return userOrderProducts;
        }
        public static string GetRandomId(List<string> ListRandomId)
        {

            Random rand = new();
            int index = rand.Next(ListRandomId.Count);
            return ListRandomId[index];
        }

    }
}
