namespace ShopManagement.Application.Contracts.Wishlist
{
    public class WishlistViewModel
    {
        public long Id { get; set; }
        public long AccountId { get; set; }
        public string ProductName { get; set; }
        public string ProductPicture { get; set; }
        public string ProductSlug { get; set; }
    }
}
