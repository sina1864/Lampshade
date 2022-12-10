using _0_Framework.Domain;

namespace ShopManagement.Domain.WishlistAgg
{
    public class WishlistItem : EntityBase
    {
        public long ProductId { get; private set; }
        public string ProductName { get; private set; }
        public string ProductPicture { get; private set; }
        public string ProductSlug { get; private set; }
        public long WishlistId { get; private set; }
        public Wishlist Wishlist { get; private set; }

        public WishlistItem(long productId, string productName, string productPicture, string productSlug)
        {
            ProductId = productId;
            ProductName = productName;
            ProductPicture = productPicture;
            ProductSlug = productSlug;
        }
    }
}
