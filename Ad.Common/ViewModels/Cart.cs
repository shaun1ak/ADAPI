using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ad.Common.ViewModels
{
    public class Cart
    {
        public Cart()
        {
            CartDetails = new List<CartDetail>();
            UserDetail = new User();
            BillingDetail = new BillingAddress();
            ShippingDetail = new ShippingAddress();
        }

        public int? Id { get; set; }
        public string UniqueId { get; set; }
        public int ITypeId { get; set; }
        public IList<CartDetail> CartDetails { get; set; } 

        public User UserDetail { get; set; }
        public BillingAddress BillingDetail { get; set; }
        public ShippingAddress ShippingDetail { get; set; }

        public string CouponId { get; set; }
        public double TotalAmt { get; set; }
        public double DiscountAmt { get; set; }
        public double DiscountPerc { get; set; }
    }

    public class CartDetail
    {
        public int? Id { get; set; }
        public int ProductId { get; set; }
        public int Qty { get; set; }
        public double Rate { get; set; }
        public double Value { get; set; }
    }

    public class Address
    {
        public int Id { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Area { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Pin { get; set; }
    }

    public class BillingAddress: Address
    {

    }

    public class ShippingAddress: Address
    {

    }

    public class User
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailId { get; set; }
    }
}
