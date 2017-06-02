using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ad.WebAPI.Controllers;
using System.Web.Http;
using System.Web.Http.Results;
using Ad.Common.ViewModels;
using Newtonsoft.Json;

namespace Ad.BiznessUnitTest
{
    [TestClass]
    public class UnitTest_CartController
    {
        [TestMethod]
        public void GetCartDetail()
        {
            CartController cartController = new CartController();

            IHttpActionResult actionResult = cartController.GetCart(4);

            var content = ((OkNegotiatedContentResult<Cart>)actionResult).Content;
            var json = JsonConvert.SerializeObject(content);
            //var t = OkNegotiatedContentResult<List<Manufacturer>>(searchResults);
            Assert.AreEqual(0, 0);
        }

        [TestMethod]
        public void UpdateCart()
        {
            CartController cartController = new CartController();

            IHttpActionResult actionResult = cartController.GetCart(4);

            var content = ((OkNegotiatedContentResult<Cart>)actionResult).Content;

            Cart cart = content;
            cartController.UpdateCart(cart);

            Assert.AreEqual(0, 0);
        }
    }
}
