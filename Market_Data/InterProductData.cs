using Market_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market_Data
{
    internal interface InterProductData
    {
        List<ProductsInfo> getProductsInfo();
        void saveProducts(List<ProductsInfo> products);
        void updateProducts(ProductsInfo products);
    }
}
