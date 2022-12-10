using System.Collections.Generic;

namespace ShopManagement.Application.Contracts.Wishlist
{
    public interface IWishlistApplication
    {
        List<WishlistViewModel> GetItems(long wishlistId);
        long AddItem(long productId);
        void RemoveItem(long id);
    }
}
