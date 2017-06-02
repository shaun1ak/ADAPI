using Ad.Bizness.Implementations.Interfaces;
using Ad.Bizness.Implementations.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ad.Common;
using Ad.Common.ViewModels;

namespace Ad.Bizness.Implementations
{
    public class ProductManager<T> where T : IProductService, new()
    {
        IProductService service;

        public ProductManager()
        {
            this.service = new T();
        }

        public ProductMappings GetSearchOptions
        {
            get
            {
                return service.GetSearchOptions;
            }
        }

        public SearchResults GetSearchList(string keyword)
        {
            return service.GetSearchList(keyword);
        }

        public ProductSearchOutput GetProducts(Dictionary<ProductMappingEnum, List<int>> search, int pageNo, string sortBy = null)
        {
            return service.GetProducts(search, pageNo, sortBy);
        }

        public ProductSearchOutput GetPopularProducts(int pageNo, int pageSize)
        {
            return service.GetPopularProducts(pageNo, pageSize);
        }

        public List<SearchProduct> GetSearchProducts()
        {
            return service.GetSearchProducts();
        }

        public Product GetProductById(int id)
        {
            return service.GetProductById(id);
        }
    }
    
}
