using Ad.Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ad.Bizness.Implementations.Interfaces
{
    public interface ICartService
    {
        Cart GetCart(int id);

        bool UpdateCart(Cart cart);
    }
}
