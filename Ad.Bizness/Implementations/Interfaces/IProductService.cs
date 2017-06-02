using System.Collections.Generic;
using Ad.Common;
using Ad.Common.ViewModels;

namespace Ad.Bizness.Implementations.Interfaces
{
    public interface IProductService
    {
        ProductMappings GetSearchOptions { get; }

        SearchResults GetSearchList(string keyword);

        //List<Product> Products(int mfgId, int catId);

        ProductSearchOutput GetPopularProducts(int pageNo, int pageSize);

        ProductSearchOutput GetProducts(Dictionary<ProductMappingEnum, List<int>> search, int pageNo, string sortBy = null);

        List<SearchProduct> GetSearchProducts();

        Product GetProductById(int id);
    }
}