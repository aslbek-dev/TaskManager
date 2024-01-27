using Microsoft.EntityFrameworkCore;

namespace WebApi.Data;
public class AppDbcontext: DbContext
{
    public AppDbcontext(DbContextOptions<AppDbcontext> options) : base (options){}
    public DbSet<Item> Items => Set<Item>();
    protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Item>(entity =>
            {
                entity.Property(e => e.ItemName)
                .IsRequired()
                .HasMaxLength(100);
                entity.Property(e => e.ItemDescription)
                .IsRequired()
                .HasMaxLength(100);
                entity.Property(e => e.ItemStatus)
                .IsRequired()
                .HasMaxLength(1);
            });

            base.OnModelCreating(builder);
        }
}