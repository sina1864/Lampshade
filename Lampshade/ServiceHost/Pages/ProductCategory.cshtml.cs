using _01_LampshadeQuery.Contracts.ProductCategory;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages
{
    public class ProductCategoryModel : PageModel
    {
        public ProductCategoryQueryModel ProductCategory;
        public int TotalPages;
        public int CurrentPage;

        private readonly IProductCategoryQuery _productCategoryQuery;

        public ProductCategoryModel(IProductCategoryQuery productCategoryQuery)
        {
            _productCategoryQuery = productCategoryQuery;
        }

        public void OnGet(string id, int pagenum)
        {
            ProductCategory = _productCategoryQuery.GetProductCategoryWithProducstsBy(id, pagenum);
            TotalPages = _productCategoryQuery.GetTotalPages(id, pagenum);
            CurrentPage = pagenum;
        }
    }
}
