using Ad.Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ad.Bizness.Implementations.Services
{
    //public class ProductManager
    //{
    //    public IQueryable<Manufacturer> GetManufacturers()
    //    {
    //        var t = ProductCreation.CreateProductService<ProductServiceTemplate>();
    //        var t1 = t.GetManufacturer;
    //        var t3 = (from c in t1
    //                  select c).AsQueryable<Manufacturer>();
    //        return t3;
    //    }

    //    public IQueryable<Product> GetProducts()
    //    {
    //        var t = ProductCreation.CreateProductService<ProductServiceTemplate>();
    //        var t1 = t.Products(1, 1);
    //        var t3 = (from c in t1
    //                  select c).AsQueryable<Product>();
    //        return t3;
    //    }
    //}

    //public abstract class ProductCreation
    //{
    //    public static T CreateProductService<T>() where T : IProduct, new()
    //    {
    //        return new T();
    //    }
    //}

    //public class ProductCreation
    //{
    //    IProductService productService;

    //    public ProductManager(IProductService productService)
    //    {
    //        this.productService = productService;
    //    }

    //    public IProductService Product
    //    {
    //        get
    //        {
    //            return productService;
    //        }
    //    }
    //}
}