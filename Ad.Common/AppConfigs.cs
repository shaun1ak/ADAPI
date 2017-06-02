using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ad.Common
{
    public enum ProductMappingEnum
    {
        Manufacturer,
        Category,
        ProductType,
        Product
    };

    public static class AppConfig
    {
        public static int ProductPageSize { get; } = 10;
    }
}
