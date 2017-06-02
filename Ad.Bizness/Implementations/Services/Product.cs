using Ad.Bizness.Implementations.Interfaces;
using Ad.Common.ViewModels;
using Ad.Common;
using Ad.Dal.Ctx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ad.Bizness.Implementations.Services
{
    public class ProductTemplate : IProductService
    {
        public ProductMappings GetSearchOptions
        {
            get
            {
                List<Manufacturer> mfgs = new List<Manufacturer>();

                for (int i = 0; i < 3; i++)
                {


                    List<ProductType> prodType1 = new List<ProductType>();
                    prodType1.Add(new ProductType { Id = 1, Name = "P1 Category1" });
                    prodType1.Add(new ProductType { Id = 2, Name = "P1 Category2" });

                    List<ProductType> prodType2 = new List<ProductType>();
                    prodType2.Add(new ProductType { Id = 1, Name = "P2 Category1" });
                    prodType2.Add(new ProductType { Id = 2, Name = "P2 Category2" });

                    List<Category> cat1 = new List<Category>();
                    cat1.Add(new Category { Id = 1, Name = "Product Type1", ProductTypes = prodType1 });
                    cat1.Add(new Category { Id = 2, Name = "Product Type2", ProductTypes = prodType2 });

                    Manufacturer mfg1 = new Manufacturer() { Id = i, Name = "Mfg-" + i, Categories = cat1 };
                    mfgs.Add(mfg1);
                }

                ProductMappings manufacturerContainer = new ProductMappings() { Manufacturers = mfgs };
                return manufacturerContainer;
            }
        }

        public SearchResults GetSearchList(string keyword)
        {
            return null;
        }

        public ProductSearchOutput GetProducts(Dictionary<ProductMappingEnum, List<int>> search, int pageNo, string sortBy = null)
        {
            return null;
        }

        public ProductSearchOutput GetPopularProducts(int pageNo, int pageSize)
        {
            throw new NotImplementedException();
        }

        public List<SearchProduct> GetSearchProducts()
        {
            throw new NotImplementedException();
        }

        public Product GetProductById(int id)
        {
            throw new NotImplementedException();
        }
    }

    public class ProductImpl : IProductService
    {
        public ProductMappings GetSearchOptions
        {
            get
            {
                ProductMappings manufacturerContainer = new ProductMappings();

                List<Manufacturer> manufacturers = new List<Manufacturer>();
                using (ApplicationDbContext ctx = new ApplicationDbContext())
                {
                    var mappings = (from c in ctx.tblProductMappings
                                    where c.iIsActive == true
                                    select c).ToList();

                    //var mappings = (from c in ctx.tblProductMappings
                    //                join p in ctx.tblProducts on c.ProductId equals p.Id
                    //                join s in ctx.tblCategorySortOrders on p.cCategory equals s.cCategory
                    //                orderby s.iOrder
                    //                where c.iIsActive == true
                    //                select c).ToList();

                    var lstMfgs = (from c in mappings
                                   select new
                                   {
                                       Id = c.ManufacturerId ?? 0,
                                       Name = c.tblManufacturer.cName,
                                       Description = c.tblManufacturer.cDescription
                                   }).Distinct().ToList();

                    foreach (var objMfg in lstMfgs)
                    {
                        var mfg = new Manufacturer { Id = objMfg.Id, Name = objMfg.Name, Description = objMfg.Description };

                        var t1 = (from c in mappings
                                  where c.ManufacturerId == objMfg.Id
                                  select new
                                  {
                                      Id = c.CategoryId ?? 0,
                                      Name = c.tblCategory.cName,
                                      Description = c.tblCategory.cDescription
                                  }).Distinct().ToList();

                        foreach (var item in t1)
                        {
                            mfg.Categories.Add(new Category { Id = item.Id, Name = item.Name, Description = item.Description });
                        }

                        foreach (var objCategory in mfg.Categories)
                        {
                            var t2 = (from c in mappings
                                      where c.ManufacturerId == objMfg.Id && c.CategoryId == objCategory.Id
                                      select new
                                      {
                                          Id = c.ProductTypeId ?? 0,
                                          Name = c.tblProductType.cName,
                                          Description = c.tblProductType.cDescription
                                      }).Distinct().ToList();

                            foreach (var item in t2)
                            {
                                objCategory.ProductTypes.Add(new ProductType { Id = item.Id, Name = item.Name, Description = item.Description });
                            }

                            //foreach (var objProductType in objCategory.ProductTypes)
                            //{
                            //    objProductType.Products = (from c in mappings
                            //                               where c.ManufacturerId == objMfg.Id && c.CategoryId == objCategory.Id && c.ProductTypeId == objProductType.Id
                            //                               select new Product
                            //                               {
                            //                                   Id = c.ProductId ?? 0,
                            //                                   Name = c.tblProduct.cName,
                            //                                   Description1 = c.tblProduct.cDescription1,
                            //                                   Description2 = c.tblProduct.cDescription2,
                            //                                   Resolution = c.tblProduct.cResolution,
                            //                                   Accuracy = c.tblProduct.cAccuracy,
                            //                                   Make = c.tblProduct.cMake,
                            //                                   PageNo = c.tblProduct.cPageNo
                            //                               }).Distinct().ToList();
                            //}

                        }

                        manufacturers.Add(mfg);
                    }
                }

                manufacturerContainer.Manufacturers = manufacturers;
                return manufacturerContainer;
            }
        }

        #region Obsolete
        //List<Product> IProductService.GetProducts(Dictionary<ProductMappingEnum, int> search, string sortBy = null, int? pageNo = 0)
        //{
        //    List<Product> lstProduct = new List<Product>();
        //    using (ApplicationDbContext dbContext = new ApplicationDbContext())
        //    {
        //        var lst = (from c in dbContext.tblProductMappings
        //                   select c);

        //        if (search != null && search.Count > 0)
        //        {
        //            foreach (var item in search)
        //            {
        //                if (item.Key == ProductMappingEnum.Category)
        //                    lst = lst.Where(x => x.CategoryId == item.Value);

        //                if (item.Key == ProductMappingEnum.ProductType)
        //                    lst = lst.Where(x => x.ProductTypeId == item.Value);
        //            }
        //        }

        //        foreach (var item in lst.ToList())
        //        {
        //            lstProduct.Add(new Product
        //            {
        //                Id = item.tblProduct.Id,
        //                Name = item.tblProduct.cName,
        //                Description1 = item.tblProduct.cDescription1,
        //                Description2 = item.tblProduct.cDescription2,
        //                Resolution = item.tblProduct.cResolution,
        //                Accuracy = item.tblProduct.cAccuracy,
        //                PageNo = item.tblProduct.cPageNo,
        //                Make = item.tblProduct.cMake,
        //                IsActive = item.tblProduct.iIsActive
        //                //CostPrice = item.tblProduct.dCostPrice,
        //                //QuotePrice = item.tblProduct.dCostPrice,
        //                //NetPrice = item.tblProduct.dNetPrice,
        //                //Discount1 = item.tblProduct.dDiscount1,
        //                //Discount2 = item.tblProduct.dDiscount2,
        //                //MinStock = item.tblProduct.dMinStock
        //            });
        //        }

        //    }

        //    return lstProduct;
        //}

        //Product IProductService.GetProduct(int productId)
        //{
        //    Product product = new Product();
        //    using (ApplicationDbContext dbContext = new ApplicationDbContext())
        //    {
        //        var item = (from c in dbContext.tblProductMappings
        //                    where c.ProductId == productId
        //                    select c).FirstOrDefault();

        //        if (item == null)
        //            return null;

        //        product = new Product
        //        {
        //            Id = item.tblProduct.Id,
        //            Name = item.tblProduct.cName,
        //            Description1 = item.tblProduct.cDescription1,
        //            Description2 = item.tblProduct.cDescription2,
        //            Resolution = item.tblProduct.cResolution,
        //            Accuracy = item.tblProduct.cAccuracy,
        //            PageNo = item.tblProduct.cPageNo,
        //            Make = item.tblProduct.cMake,
        //            IsActive = item.tblProduct.iIsActive
        //            //CostPrice = item.tblProduct.dCostPrice,
        //            //QuotePrice = item.tblProduct.dCostPrice,
        //            //NetPrice = item.tblProduct.dNetPrice,
        //            //Discount1 = item.tblProduct.dDiscount1,
        //            //Discount2 = item.tblProduct.dDiscount2,
        //            //MinStock = item.tblProduct.dMinStock
        //        };
        //    }

        //    return product;
        //}

        #endregion

        public SearchResults GetSearchList(string keyword)
        {
            keyword = keyword.ToLower();
            SearchResults results = new SearchResults();
            results.Records = new List<SearchRecord>();
            using (ApplicationDbContext ctx = new ApplicationDbContext())
            {
                var mappings = (from c in ctx.tblProductMappings
                                join s in ctx.tblCategorySortOrders on c.tblProduct.cCategory equals s.cCategory
                                where c.iIsActive == true
                                && c.tblProductType.cName != null
                                && (c.tblProductType.cName.ToLower().Contains(keyword)
                                || c.tblProduct.cName.ToLower().Contains(keyword)
                                || c.tblProduct.cProdId.ToLower().Contains(keyword))
                                select new
                                {
                                    pname = c.tblProduct.cProdId + " "+ c.tblProduct.cName,
                                    ptype = c.tblProductType.cName,
                                    cat = c.tblCategory.cName,
                                    order = s.iOrder
                                }).ToList();

                #region old

                var ps = mappings.Where(c => c.ptype.ToLower().Contains(keyword)).Distinct().ToList();
                results.Records.AddRange(ps.Select(m => new SearchRecord
                {
                    Name = m.ptype,
                    Type = m.ptype,
                    Category = m.cat,
                    RecordType = ProductMappingEnum.ProductType
                }).ToList());
                ps = mappings.Where(c => c.pname.ToLower().Contains(keyword)).OrderBy(o=>o.order).Distinct().ToList();
                results.Records.AddRange(ps.Select(m => new SearchRecord
                {
                    Name = m.pname,
                    Type = m.ptype,
                    Category = m.cat,
                    RecordType = ProductMappingEnum.Product
                }).ToList());
                #endregion old

                results.Records = results.Records.Take(10).ToList();
                return results;
            }
        }

        public ProductSearchOutput GetProducts(Dictionary<ProductMappingEnum, List<int>> search, int pageNo, string sortBy = null)
        {
            ProductSearchOutput output = new ProductSearchOutput();
            List<Product> lstProduct = new List<Product>();
            using (ApplicationDbContext dbContext = new ApplicationDbContext())
            {
                var lst = (from c in dbContext.tblProductMappings
                           select c);

                if (search != null && search.Count > 0)
                {
                    foreach (var item in search)
                    {
                        if (item.Key == ProductMappingEnum.Manufacturer)
                            lst = lst.Where(x => item.Value.Contains(x.ManufacturerId ?? 0));

                        if (item.Key == ProductMappingEnum.Category)
                            lst = lst.Where(x => item.Value.Contains(x.CategoryId ?? 0));

                        if (item.Key == ProductMappingEnum.ProductType)
                            lst = lst.Where(x => item.Value.Contains(x.ProductTypeId ?? 0));

                        if (item.Key == ProductMappingEnum.Product)
                            lst = lst.Where(x => item.Value.Contains(x.ProductId ?? 0));
                    }
                }

                foreach (var item in lst.ToList().Skip(10 * (pageNo - 1)).Take(AppConfig.ProductPageSize))
                {
                    var product = item.tblProduct;
                    lstProduct.Add(new Product
                    {
                        Id = product.Id,
                        Name = product.cName == null ? "" : product.cName.Trim(),
                        ProductCode = product.cProdId,
                        Description1 = product.cDescription1,
                        Description2 = product.cDescription2,
                        Resolution = product.cResolution,
                        Range = product.cRange,
                        PageNo = product.cPageNo,
                        Make = product.cMake == null ? "" : product.cMake.Trim(),
                        IsActive = product.iIsActive,
                        DigitalAnalog = product.cDigitalAnalog
                        //CostPrice = product.dCostPrice,
                        //QuotePrice = product.dCostPrice,
                        //NetPrice = product.dNetPrice,
                        //Discount1 = product.dDiscount1,
                        //Discount2 = product.dDiscount2,
                        //MinStock = product.dMinStock
                    });
                }

                output.TotalRecords = lst.Count();
            }
            output.Rows = lstProduct;
            return output;
        }

        public ProductSearchOutput GetPopularProducts(int pageNo, int pageSize)
        {
            ProductSearchOutput output = new ProductSearchOutput();
            List<Product> lstProduct = new List<Product>();
            var popularCategories = new string[] { "P1" };
            using (ApplicationDbContext dbContext = new ApplicationDbContext())
            {
                var lst = (from c in dbContext.tblProducts
                           where popularCategories.Contains(c.cCategory)
                           select c).ToList();

                foreach (var product in lst)
                {
                    lstProduct.Add(new Product
                    {
                        Id = product.Id,
                        Name = product.cName == null ? "" : product.cName.Trim(),
                        ProductCode = product.cProdId,
                        Description1 = product.cDescription1,
                        Description2 = product.cDescription2,
                        Resolution = product.cResolution,
                        Range = product.cRange,
                        PageNo = product.cPageNo,
                        Make = product.cMake == null ? "" : product.cMake.Trim(),
                        IsActive = product.iIsActive,
                        DigitalAnalog = product.cDigitalAnalog
                        //CostPrice = product.dCostPrice,
                        //QuotePrice = product.dCostPrice,
                        //NetPrice = product.dNetPrice,
                        //Discount1 = product.dDiscount1,
                        //Discount2 = product.dDiscount2,
                        //MinStock = product.dMinStock
                    });
                }

                output.TotalRecords = lst.Count();
            }
            output.Rows = lstProduct;
            return output;
        }

        public List<SearchProduct> GetSearchProducts()
        {
            List<SearchProduct> searchProducts = new List<SearchProduct>();
            using (ApplicationDbContext dbContext = new ApplicationDbContext())
            {
                var productMappings = (from c in dbContext.tblProductMappings
                                       select c);

                foreach (var item in productMappings)
                {
                    searchProducts.Add(new SearchProduct
                    {
                        ProdId = item.tblProduct.Id,
                        ProdName = item.tblProduct.cName,
                        ProdtType = item.tblProductType.cName,
                        ProdCategory = item.tblCategory.cName,
                        ProdCode = item.tblProduct.cProdId
                    });
                }
            }
            

            return searchProducts;
        }

        public Product GetProductById(int id)
        {
            Product output = new Product();
            using (ApplicationDbContext ctx = new ApplicationDbContext())
            {
                var product = ctx.tblProducts.Where(p => p.Id == id).FirstOrDefault();
                output = new Product
                {
                    Id = product.Id,
                    ProductCode = product.cProdId,
                    Name = product.cName == null ? "" : product.cName.Trim(),
                    Description1 = product.cDescription1,
                    Description2 = product.cDescription2,
                    Resolution = product.cResolution,
                    Range = product.cRange,
                    PageNo = product.cPageNo,
                    Make = product.cMake == null ? "" : product.cMake.Trim(),
                    IsActive = product.iIsActive,
                    DigitalAnalog = product.cDigitalAnalog
                    //CostPrice = product.dCostPrice,
                    //QuotePrice = product.dCostPrice,
                    //NetPrice = product.dNetPrice,
                    //Discount1 = product.dDiscount1,
                    //Discount2 = product.dDiscount2,
                    //MinStock = product.dMinStock
                };
            }
            return output;
        }
    }
}
