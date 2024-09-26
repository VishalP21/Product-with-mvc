using System;
using System.Collections.Generic;

namespace Product_with_mvc;

public partial class ProductsAboveAveragePrice
{
    public string ProductName { get; set; } = null!;

    public decimal? UnitPrice { get; set; }
}
