using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ad.Common.ViewModels
{
    public class ProductMappings
    {
        public List<Manufacturer> Manufacturers { get; set; }
    }

    public class Manufacturer
    {
        public Manufacturer()
        {
            Categories = new List<Category>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Category> Categories { get; set; }
    }

    public class Category
    {
        public Category()
        {
            ProductTypes = new List<ProductType>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<ProductType> ProductTypes { get; set; }
    }

    public class ProductType
    {
        public ProductType()
        {
            //Products = new List<Product>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        //public List<Product> Products { get; set; }
    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ProductCode { get; set; }
        public string Description1 { get; set; }
        public string Description2 { get; set; }
        public string Resolution { get; set; }
        public string Range { get; set; }
        public string PageNo { get; set; }
        public string Make { get; set; }
        public bool? IsActive { get; set; }
        public string DigitalAnalog { get; set; }
        private decimal CostPrice { get; set; }
        private decimal QuotePrice { get; set; }
        private decimal NetPrice { get; set; }
        private decimal? Discount1 { get; set; }
        private decimal? Discount2 { get; set; }
        private decimal? MinStock { get; set; }
    }


    public class SearchResults
    {
        public List<SearchRecord> Records { get; set; }
    }

    public class SearchRecord
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Category { get; set; }
        public ProductMappingEnum RecordType { get; set; }
    }

    public class SearchInput
    {
        public Dictionary<ProductMappingEnum, List<int>> search { get; set; }
        public string sortBy { get; set; }
        public int pageNo { get; set; }
    }

    public class ProductSearchOutput
    {
        public int TotalRecords { get; set; }
        public List<Product> Rows { get; set; }
    }

    public class SearchProduct
    {
        public int ProdId { get; set; }
        public string ProdName { get; set; }
        public string ProdtType { get; set; }
        public string ProdCategory { get; set; }
        public string ProdCode { get; set; }
    }
}
