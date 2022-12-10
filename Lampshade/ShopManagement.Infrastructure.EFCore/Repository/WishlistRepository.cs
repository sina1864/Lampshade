using System.Collections.Generic;
using System.Linq;
using _0_Framework.Infrastructure;
using ShopManagement.Application.Contracts.Wishlist;
using ShopManagement.Domain.WishlistAgg;

namespace ShopManagement.Infrastructure.EFCore.Repository
{
    public class WishlistRepository : RepositoryBase<long, Wishlist>, IWishlistRepository
    {
        private readonly ShopContext _context;

        public WishlistRepository(ShopContext context) : base(context)
        {
            _context = context;
        }
        public List<WishlistViewModel> GetItems(long wishlistId)
        {
            var wishlist = _context.Wishlists.FirstOrDefault(x => x.Id == wishlistId);
            if (wishlist == null)
                return new List<WishlistViewModel>();
            var items = wishlist.Items.Select(x => new WishlistViewModel
            {
                Id = x.Id,
                ProductName = x.ProductName,
                ProductPicture = x.ProductPicture,
                ProductSlug = x.ProductSlug,
            }).ToList();
            return items;
        }

        public void RemoveItem(long id)
        {
            var item = _context.Wishlists.FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                _context.Wishlists.Remove(item);
            }
        }
    }
}
