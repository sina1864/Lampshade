using System.Collections.Generic;
using _0_Framework.Application;
using ShopManagement.Application.Contracts.Wishlist;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Domain.WishlistAgg;

namespace ShopManagement.Application
{
    public class WishlistApplication : IWishlistApplication
    {
        private readonly IWishlistRepository _wishlistRepository;
        private readonly IProductRepository _productRepository;
        private readonly IAuthHelper _authHelper;

        public WishlistApplication(IWishlistRepository wishlistRepository, IProductRepository productRepository, IAuthHelper authHelper)
        {
            _wishlistRepository = wishlistRepository;
            _productRepository = productRepository;
            _authHelper = authHelper;
        }

        public List<WishlistViewModel> GetItems(long wishlistId)
        {
            return _wishlistRepository.GetItems(wishlistId);
        }

        public long AddItem(long productId)
        {
            var currentAccountId = _authHelper.CurrentAccountId();
            var product = _productRepository.GetProductWithCategory(productId);
            var wishlist = new Wishlist(currentAccountId, product.Name, product.Picture, product.Slug);
            _wishlistRepository.Create(wishlist);
            _wishlistRepository.SaveChanges();
            return wishlist.Id;
        }

        public void RemoveItem(long id)
        {
            _wishlistRepository.RemoveItem(id);
        }
    }
}
