using Ad.Bizness.Implementations;
using Ad.Bizness.Implementations.Services;
using Ad.Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;

namespace Ad.WebAPI.Controllers
{
    public class CartController : ApiController
    {
        CartManager<CartServiceImp> crt = new CartManager<CartServiceImp>();

        [HttpGet]
        public IHttpActionResult GetCart(int id)
        {
            var result = crt.GetCart(id);

            return Ok<Cart>(result);
        }

        [HttpGet]
        public IHttpActionResult GetCart1()
        {
            Cart cart = new Cart();

            List<CartDetail> cartDetails = new List<CartDetail>();

            for (int i = 0; i < 2; i++)
            {
                int prdCnt = new Random().Next(10, 20);
                int prdRate = new Random().Next(100, 1000);

                cartDetails.Add(new CartDetail
                {
                    Id = i + 1,
                    ProductId = i + 1,
                    Qty = StaticRandom.Instance.Next(1, 10),
                    Rate = StaticRandom.Instance.Next(20, 100)
                });
            }

            cartDetails.ForEach(c => c.Value = c.Qty * c.Rate);

            BillingAddress billingAddress = new BillingAddress()
            {
                Id = 1,
                Address1 = "Impress Society",
                Address2 = "Narayani Mandeer Rd",
                Area = "Kartaj",
                City = "Pune",
                Country = "India",
                State = "Maharashtra",
                Pin = "411206"
            };

            ShippingAddress shippingAddress = new ShippingAddress()
            {
                Id = 1,
                Address1 = "Impress Society",
                Address2 = "Narayani Mandeer Rd",
                Area = "Kartaj",
                City = "Pune",
                Country = "India",
                State = "Maharashtra",
                Pin = "411206"
            };

            User user = new User() { Id = 1, FirstName = "Ashok", LastName = "More", UserId = "ashokm", EmailId = "abc@gmail.com" };

            cart.UserDetail = user;
            cart.ShippingDetail = shippingAddress;
            cart.BillingDetail = billingAddress;
            cart.CartDetails = cartDetails;
            cart.UniqueId = $"Test_{ new Random().Next(100, 1000)}";
            return Ok<Cart>(cart);
        }

        [HttpPost]
        public IHttpActionResult UpdateCart(Cart cart)
        {
            var result = crt.UpdateCart(cart);

            return Ok<bool>(true);
        }
    }

    public static class StaticRandom
    {
        private static int seed;

        private static ThreadLocal<Random> threadLocal = new ThreadLocal<Random>
            (() => new Random(Interlocked.Increment(ref seed)));

        static StaticRandom()
        {
            seed = Environment.TickCount;
        }

        public static Random Instance { get { return threadLocal.Value; } }
    }
}
