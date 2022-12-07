using System.Collections.Generic;

namespace _01_LampshadeQuery.Contracts.ProductCategory
{
    public interface IProductCategoryQuery
    {
        ProductCategoryQueryModel GetProductCategoryWithProducstsBy(string id, int pagenum);
        ProductCategoryQueryModel GetProductSubcategoryWithProducstsBy(string id, int pagenum);
        List<ProductCategoryQueryModel> GetProductCategories();
        List<ProductCategoryQueryModel> GetProductCategoriesWithProducts();
        int GetTotalPages(string id, int pagenum);
    }
}
