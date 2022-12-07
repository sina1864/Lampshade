using _01_LampshadeQuery.Contracts.ProductCategory;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages
{
    public class ProductSubcategoryModel : PageModel
    {
        public ProductCategoryQueryModel ProductCategory;
        public int TotalPages;
        public int CurrentPage;

        private readonly IProductCategoryQuery _productCategoryQuery;

        public ProductSubcategoryModel(IProductCategoryQuery productCategoryQuery)
        {
            _productCategoryQuery = productCategoryQuery;
        }

        public void OnGet(string id, int pagenum)
        {
            ProductCategory = _productCategoryQuery.GetProductSubcategoryWithProducstsBy(id, pagenum);
            TotalPages = _productCategoryQuery.GetTotalPages(id, pagenum);
            CurrentPage = pagenum;
        }
    }
}
