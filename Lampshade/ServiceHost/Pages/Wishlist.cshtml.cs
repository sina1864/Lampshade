using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ShopManagement.Application.Contracts.Wishlist;

namespace ServiceHost.Pages
{
    public class WishlistModel : PageModel
    {
        public List<WishlistViewModel> WishlistItems;
        private readonly IWishlistApplication _wishlistApplication;

        public WishlistModel(IWishlistApplication wishlistApplication)
        {
            WishlistItems = new List<WishlistViewModel>();
            _wishlistApplication = wishlistApplication;
        }

        public void OnGet(long id)
        {
            WishlistItems = _wishlistApplication.GetItems(id);
        }

        public IActionResult OnGetRemoveItem(long id)
        {
            _wishlistApplication.RemoveItem(id);
            return RedirectToPage("/Wishlist");
        }
    }
}
