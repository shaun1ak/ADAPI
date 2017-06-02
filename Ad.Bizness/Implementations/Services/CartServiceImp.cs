using Ad.Bizness.Implementations.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ad.Common.ViewModels;
using Ad.Dal.Ctx;
using Ad.Common.Models;
using Ad.Common;

namespace Ad.Bizness.Implementations.Services
{
    public class CartServiceImp : ICartService
    {
        public Cart GetCart(int id)
        {
            using (ApplicationDbContext ctx = new ApplicationDbContext())
            {
                var orders = (from o in ctx.tblOrders
                              from d in o.tblOrderDetails
                              where o.Id == id
                              select new
                              {
                                  id = o.Id,
                                  userId = o.UserId,
                                  iType = o.iType,
                                  refCartNo = o.RefCartNo,
                                  billingAddressId = o.BillingAddressId,
                                  shippingAddressId = o.ShippingAddressId,
                                  orderDetailId = d.Id,
                                  productId = d.ProductId,
                                  qty = d.Qty,
                                  rate = d.Rate
                              }
                             ).ToList();
                var orderMst = orders.FirstOrDefault();

                Cart cart = new Cart();

                if (orderMst != null)
                {
                    cart.Id = orderMst.id;
                    cart.UniqueId = orderMst.refCartNo;
                    cart.ITypeId = orderMst.iType;

                    foreach (var item in orders)
                    {
                        cart.CartDetails.Add(new CartDetail()
                        {
                            Id = item.orderDetailId,

                            ProductId = item.productId,
                            Qty = item.qty,
                            Rate = item.rate,
                            Value = item.qty * item.rate
                        });

                    }

                    cart.UserDetail = new User()
                    {
                        Id = orderMst.userId
                    };
                }

                cart.BillingDetail = new BillingAddress();
                cart.ShippingDetail = new ShippingAddress();

                return cart;
            }
        }

        public bool UpdateCart(Cart cart)
        {
            using (ApplicationDbContext ctx = new ApplicationDbContext())
            {
                //cart.Id = null; //todo: delete this line
                var order = (from o in ctx.tblOrders
                             where o.Id == cart.Id
                             select o).FirstOrDefault();
                if (order == null)
                {
                    order = new tblOrder();
                    order.RefCartNo = Guid.NewGuid().ToString();
                    order.iType = (int)CartType.InProcess;
                    order.cCreatedBy = Util.DefaultUser;
                    order.dCreatedDate = DateTime.Now;

                    ctx.tblOrders.Add(order);
                }
                else
                {
                    order.RefCartNo = cart.UniqueId;
                    order.iType = (int)cart.ITypeId;
                    order.cModifiedBy = Util.DefaultUser;
                    order.dModifiedDate = DateTime.Now;
                }
                order.UserId = cart.UserDetail.Id;

                var lstOrderDetails = (from d in ctx.tblOrderDetails
                                       where d.OrderId == cart.Id
                                       select d).ToList();

                foreach (var item in cart.CartDetails)
                {
                    var orderDetails = (from d in lstOrderDetails
                                        where d.Id == item.Id
                                        select d).FirstOrDefault();

                    if (orderDetails == null)
                    {
                        orderDetails = new tblOrderDetail();
                        orderDetails.cCreatedBy = Util.DefaultUser;
                        orderDetails.dCreatedDate = DateTime.Now;
                        order.tblOrderDetails.Add(orderDetails);
                    }
                    else
                    {
                        orderDetails.cModifiedBy = Util.DefaultUser;
                        orderDetails.dModifiedDate = DateTime.Now;
                    }
                    orderDetails.ProductId = item.ProductId;
                    orderDetails.Qty = item.Qty;
                    orderDetails.Rate = (int)item.Rate;
                }

                foreach (var item in lstOrderDetails)
                {
                    var cartDetail = (from d in cart.CartDetails
                                        where d.Id == item.Id
                                        select d).FirstOrDefault();

                    if(cartDetail == null)
                        order.tblOrderDetails.Remove(item);
                }

                int recd = ctx.SaveChanges();
            }

            return true;
        }
    }
}
