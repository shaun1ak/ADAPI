using Ad.Bizness.Implementations;
using Ad.Bizness.Implementations.Services;
using Ad.Common.ViewModels;
using Ad.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Runtime.Caching;

namespace Ad.WebAPI.Controllers
{
    public class SearchController : ApiController
    {
        ProductManager<ProductImpl> pc = new ProductManager<ProductImpl>();
        MemoryCache memCache = MemoryCache.Default;

        [HttpGet]
        public IHttpActionResult GetSearchOptions()
        {
            var mfgs = pc.GetSearchOptions;
            return Ok<ProductMappings>(mfgs);
        }

        [HttpGet]
        public IHttpActionResult GetSearchList(string keyword)
        {
            var mfgs = pc.GetSearchList(keyword);
            return Ok<SearchResults>(mfgs);
        }

        [HttpPost]
        public IHttpActionResult GetSearchResultByOptions(SearchInput input)
        {
            var products = pc.GetProducts(input.search, input.pageNo, input.sortBy);
            return Ok<ProductSearchOutput>(products);
        }

        [HttpGet]
        public IHttpActionResult GetPopularProducts(int pageNo, int pageSize)
        {
            var products = pc.GetPopularProducts(pageNo, pageSize);
            return Ok<ProductSearchOutput>(products);
        }

        [HttpGet]
        public IHttpActionResult GetSearchProducts()
        {
            List<SearchProduct> searchItems = GetAllProducts();

            var a = "a";

            var t = (from c in searchItems
                     where c.ProdName.Contains(a) || c.ProdCode.Contains(a)
                     select c).ToList();

            foreach (var item in t)
            {
                Console.WriteLine(item);
            }

            return Ok<List<SearchProduct>>(t);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [NonAction]
        private List<SearchProduct> GetAllProducts()
        {
            List<SearchProduct> searchItems = pc.GetSearchProducts();
            return searchItems;
        }

        [HttpGet]
        public IHttpActionResult GetProductById(int id)
        {
            var product = pc.GetProductById(id);
            return Ok<Product>(product);
        }
    }
}
