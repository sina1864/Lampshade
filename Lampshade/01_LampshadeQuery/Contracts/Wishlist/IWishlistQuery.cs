using ShopManagement.Application.Contracts.Wishlist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_LampshadeQuery.Contracts.Wishlist
{
    public interface IWishlistQuery
    {
        List<WishlistQueryModel> GetItems(long userId);
        void RemoveItem(long id);

    }
}
