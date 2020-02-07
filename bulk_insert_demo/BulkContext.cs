using Microsoft.EntityFrameworkCore;

namespace BulkInsertDemo
{
    public sealed class BulkContext : DbContext
    {
        public BulkContext(DbContextOptions<BulkContext> options) : base(options)
        {
            // ouch, but hey!
            Database.Migrate();
        }

        public DbSet<StockRow> Stocks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var entity = modelBuilder.Entity<StockRow>();
            entity.HasKey(e => new {e.Timestamp, e.StoreNo, e.ProductCode});
        }
    }
}