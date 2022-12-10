using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagement.Domain.WishlistAgg;

namespace ShopManagement.Infrastructure.EFCore.Mapping
{
    public class WishlistMapping : IEntityTypeConfiguration<Wishlist>
    {
        public void Configure(EntityTypeBuilder<Wishlist> builder)
        {
            builder.ToTable("Wishlists");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.ProductName);
            builder.Property(x => x.ProductPicture);
            builder.Property(x => x.ProductSlug);

            builder.OwnsMany(x => x.Items, navigationBuilder =>
            {
                navigationBuilder.ToTable("WishlistItems");
                navigationBuilder.HasKey(x => x.Id);
                navigationBuilder.WithOwner(x => x.Wishlist).HasForeignKey(x => x.WishlistId);
            });
        }
    }
}
