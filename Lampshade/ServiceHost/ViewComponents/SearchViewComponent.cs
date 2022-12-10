using _01_LampshadeQuery;
using _01_LampshadeQuery.Contracts.ProductCategory;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.ViewComponents
{
    public class SearchViewComponent : ViewComponent
    {
        private readonly IProductCategoryQuery _productCategoryQuery;

        public SearchViewComponent(IProductCategoryQuery productCategoryQuery)
        {
            _productCategoryQuery = productCategoryQuery;
        }

        public IViewComponentResult Invoke()
        {
            var result = new SearchModel
            {
                ProductCategories = _productCategoryQuery.GetProductCategories()
            };
            return View(result);
        }
    }
}
