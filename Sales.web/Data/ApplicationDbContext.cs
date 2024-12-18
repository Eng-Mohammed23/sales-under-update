using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Sales.web.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.HasSequence("SerialNumber", schema: "shared").StartsAt(1);

            builder.Entity<Order>().Property(o => o.SerialNumber).HasDefaultValueSql("NEXT VALUE FOR shared.SerialNumber");

            //builder.Entity<OrdersItems>().HasKey(o => new { o.OrderId, o.ItemId });
        }
        public DbSet<Order> Orders { get; set; }
        //public DbSet<Category> Categories { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Client> Clients { get; set; }

        public DbSet<ItemDetails> ItemsDetails { get; set; }
        public DbSet<Account> Accounts { get; set; }
    }
}
