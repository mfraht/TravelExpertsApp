using System;
using System.Collections.Generic;
using System.Text;

namespace ProductMaintenance.Models
{
    partial class Products
    {
         public Products(int prodId, string name, decimal version)
        {
            this.ProductId = prodId;
            this.ProdName = name;
            
        }
    }
}
