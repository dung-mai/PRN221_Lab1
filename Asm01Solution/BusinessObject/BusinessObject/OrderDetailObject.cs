using DataAccess.Models;
using System;
using System.Collections.Generic;

namespace BusinessLayer.BusinessObject
{
    public class OrderDetailObject
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public double Discount { get; set; }

        public virtual OrderObject Order { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
    }
}
