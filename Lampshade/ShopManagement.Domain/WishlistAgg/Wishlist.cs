using _0_Framework.Domain;
using System.Collections.Generic;

namespace ShopManagement.Domain.WishlistAgg
{
    public class Wishlist : EntityBase
    {
        public long AccountId { get; private set; }
        public string ProductName { get; private set; }
        public string ProductPicture { get; private set; }
        public string ProductSlug { get; private set; }
        public List<WishlistItem> Items { get; private set; }

        public Wishlist(long accountId, string productName, string productPicture, string productSlug)
        {
            AccountId = accountId;
            ProductName = productName;
            ProductPicture = productPicture;
            ProductSlug = productSlug;
            Items = new List<WishlistItem>();
        }

        public void AddItem(WishlistItem item)
        {
            Items.Add(item);
        }
    }

}
