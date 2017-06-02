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
    public class CartManager<T> where T : ICartService, new()
    {
        ICartService service;

        public CartManager()
        {
            this.service = new T();
        }

        public Cart GetCart(int id)
        {
            return service.GetCart(id);
        }

        public bool UpdateCart(Cart cart)
        {
            return service.UpdateCart(cart);
        }
    }

}
