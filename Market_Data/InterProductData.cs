﻿using Market_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market_Data
{
    public interface InterProductData
    {
        List<ProductsInfo> products();
        void saveProducts(List<ProductsInfo> products);
        void updateProducts(ProductsInfo products);

    }
}
