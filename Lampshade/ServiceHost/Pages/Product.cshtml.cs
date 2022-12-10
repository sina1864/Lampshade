using _01_LampshadeQuery.Contracts.Product;
using CommentManagement.Application.Contracts.Comment;
using CommnetManagement.Infrastructure.EFCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Contracts.Wishlist;

namespace ServiceHost.Pages
{
    public class ProductModel : PageModel
    {
        public ProductQueryModel Product;

        private readonly IProductQuery _productQuery;
        private readonly ICommentApplication _commentApplication;
        private readonly IWishlistApplication _wishlistApplication;

        public ProductModel(IProductQuery productQuery, ICommentApplication commentApplication, IWishlistApplication wishlistApplication)
        {
            _productQuery = productQuery;
            _commentApplication = commentApplication;
            _wishlistApplication = wishlistApplication;
        }

        public void OnGet(string id)
        {
            Product = _productQuery.GetProductDetails(id);
        }

        public IActionResult OnPost(AddComment command, string productSlug)
        {
            command.Type = CommentType.Product;
            var result = _commentApplication.Add(command);
            return RedirectToPage("/Product", new { Id = productSlug });
        }

        public IActionResult onGetAddItem(long productId)
        {
            _wishlistApplication.AddItem(productId);
            return RedirectToPage("/Wishlist");
        }
    }
}
