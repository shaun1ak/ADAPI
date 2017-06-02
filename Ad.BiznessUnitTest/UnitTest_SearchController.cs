using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ad.WebAPI.Controllers;
using System.Web.Http.Results;
using Ad.Common.ViewModels;
using System.Collections.Generic;
using System.Web.Http;
using Newtonsoft.Json;
using Ad.Common;

namespace Ad.BiznessUnitTest
{
    [TestClass]
    public class UnitTest_SearchController
    {
        [TestMethod]
        public void TestOptions()
        {
            SearchController searchController = new SearchController();
            IHttpActionResult actionResult = searchController.GetSearchOptions();

            var content = ((OkNegotiatedContentResult<ProductMappings>)actionResult).Content;
            var json = JsonConvert.SerializeObject(content);
            Assert.AreEqual(0, 0);
            //var t = OkNegotiatedContentResult<List<Manufacturer>>(searchResults);
            //Assert.IsType<OkResult>(actionResult);
        }

        [TestMethod]
        public void TestSearchByAction1()
        {
            SearchInput searchInput = new SearchInput();
            var searchMapping = new Dictionary<ProductMappingEnum, List<int>>();
            searchMapping.Add(ProductMappingEnum.Manufacturer, new List<int> {100000 });

            searchInput.search = searchMapping;
            SearchController searchController = new SearchController();
            IHttpActionResult actionResult = searchController.GetSearchResultByOptions(searchInput);

            var content = ((OkNegotiatedContentResult<List<Product>>)actionResult).Content;
            var json = JsonConvert.SerializeObject(content);
            //var t = OkNegotiatedContentResult<List<Manufacturer>>(searchResults);
            Assert.AreEqual(0, 0);
        }

        [TestMethod]
        public void TestGetPopularProtucts()
        {
            SearchController searchController = new SearchController();
            IHttpActionResult actionResult = searchController.GetPopularProducts(0,4);

            var content = ((OkNegotiatedContentResult<ProductSearchOutput>)actionResult).Content;
            var json = JsonConvert.SerializeObject(content);

            Assert.AreEqual(0, 0);
        }

        [TestMethod]
        public void TestGetSearchProducts()
        {
            SearchController searchController = new SearchController();
            IHttpActionResult actionResult = searchController.GetSearchProducts();

            var content = ((OkNegotiatedContentResult<List<SearchProduct>>)actionResult).Content;
            var json = JsonConvert.SerializeObject(content);

            Assert.AreEqual(0, 0);

        }

        //[TestMethod]
        //public void TestGetProduct()
        //{
        //    SearchController searchController = new SearchController();
        //    IHttpActionResult actionResult = searchController.GetProduct(1);

        //    var content = ((OkNegotiatedContentResult<Product>)actionResult).Content;
        //    var json = JsonConvert.SerializeObject(content);
        //    //var t = OkNegotiatedContentResult<List<Manufacturer>>(searchResults);
        //    Assert.AreEqual(0, 0);
        //}

        //[TestMethod]
        //public void TestSearchByAction2()
        //{
        //    SearchController searchController = new SearchController();
        //    Dictionary<ProductMappingEnum, int> search = new Dictionary<ProductMappingEnum, int>();
        //    search.Add(ProductMappingEnum.Category, 2);

        //    IHttpActionResult actionResult = searchController.GetSearchResultByOptions(search);

        //    var content = ((OkNegotiatedContentResult<List<Product>>)actionResult).Content;
        //    var json = JsonConvert.SerializeObject(content);
        //    //var t = OkNegotiatedContentResult<List<Manufacturer>>(searchResults);
        //    Assert.AreEqual(0, 0);
        //}
    }
}
