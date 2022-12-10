using _0_Framework.Domain;
using ShopManagement.Application.Contracts.Wishlist;
using System.Collections.Generic;

namespace ShopManagement.Domain.WishlistAgg
{
    public interface IWishlistRepository : IRepository<long, Wishlist>
    {
        List<WishlistViewModel> GetItems(long wishlistId);
        void RemoveItem(long id);
    }
}
