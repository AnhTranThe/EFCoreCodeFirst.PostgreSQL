using EFCoreCodeFirst.PostgreSQL.Entity;
using Microsoft.EntityFrameworkCore;

namespace EFCoreCodeFirst.PostgreSQL.Data
{
    public class AppDbContext : DbContext
    {
        private readonly string _ConnectionString = "Host=ep-soft-hall-a1doa2gt.ap-southeast-1.aws.neon.tech;Database=neondb;Username=AnhTranThe;Password=1S3RwbetyBZX";
        public DbSet<User> Users { get; set; }
        public DbSet<UserDetail> UserDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<UserOrder> UserOrders { get; set; }
        public DbSet<UserOrderProduct> UserOrderProducts { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            _ = optionsBuilder.UseNpgsql(_ConnectionString);
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            _ = modelBuilder.Entity<UserOrderProduct>()
               .HasOne(a => a.UserOrder)
               .WithMany(a => a.UserOrderProducts)
               .HasForeignKey(a => a.UserOrderId).OnDelete(DeleteBehavior.Cascade);

            _ = modelBuilder.Entity<User>()
             .HasOne(a => a.UserDetail)
             .WithOne(a => a.User)
             .HasForeignKey<UserDetail>(a => a.UserId).OnDelete(DeleteBehavior.Cascade);

            _ = modelBuilder.Entity<UserOrder>()
               .HasOne(a => a.User)
               .WithMany(a => a.UserOrders)
               .HasForeignKey(a => a.UserId).OnDelete(DeleteBehavior.Cascade);




        }



    }
}
