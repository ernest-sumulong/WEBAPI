using System;
using System.Collections.Generic;

namespace Northwind.Models;

public partial class AlphabeticalListOfProduct
{
    public int ProductId { get; set; }

    public int ProductName { get; set; }

    public int SupplierId { get; set; }

    public int CategoryId { get; set; }

    public int QuantityPerUnit { get; set; }

    public int UnitPrice { get; set; }

    public int UnitsInStock { get; set; }

    public int UnitsOnOrder { get; set; }

    public int ReorderLevel { get; set; }

    public int Discontinued { get; set; }

    public int CategoryName { get; set; }
}
