using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ad.Bizness.Implementations;
using Ad.Bizness.Implementations.Services;
using System.Collections.Generic;
using Ad.Common;

namespace Ad.BiznessUnitTest
{
    [TestClass]
    public class UnitTest_SearchService
    {
        //[TestMethod]
        //public void TestMethod1()
        //{
        //    ProductClient pc = new ProductClient();
        //    var t = pc.ProductService.GetManufacturer;

        //    foreach (var item in t)
        //    {
        //        Console.WriteLine(item.Name);
        //    }
        //}


        [TestMethod]
        public void TestMethod4()
        {
            ProductManager<ProductImpl> pc = new ProductManager<ProductImpl>();

            Dictionary<ProductMappingEnum, int> search = new Dictionary<ProductMappingEnum, int>();

            search.Add(ProductMappingEnum.Category, 1);
            search.Add(ProductMappingEnum.ProductType, 1);

            //var lstProducts = pc.GetProducts(search, 1);
        }
    }
}
