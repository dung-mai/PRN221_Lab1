using DataAccess.Models;
using System;
using System.Collections.Generic;

namespace BusinessLayer.BusinessObject
{
    public class OrderObject
    {
        public OrderObject()
        {
            OrderDetails = new HashSet<OrderDetailObject>();
        }

        public int OrderId { get; set; }
        public int MemberId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? RequiredDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public decimal? Freight { get; set; }

        public virtual MemberObject Member { get; set; } = null!;
        public virtual ICollection<OrderDetailObject> OrderDetails { get; set; }

        public double _totalMoney = 0;
        public double TotalMoney { 
            get {
                _totalMoney = 0;
                OrderDetails.ToList().ForEach(o =>
                {
                    _totalMoney += o.Quantity * (double)o.UnitPrice * (1 - o.Discount);
                });
                return _totalMoney + (Freight != null ?  (double) Freight : 0);
            }
        }

    }
}
