using DataAccess.Models;
using System;
using System.Collections.Generic;

namespace BusinessLayer.BusinessObject
{
    public class MemberObject
    {
        public MemberObject()
        {
            Orders = new HashSet<OrderObject>();
        }

        public int MemberId { get; set; }
        public string Email { get; set; } = null!;
        public string CompanyName { get; set; } = null!;
        public string City { get; set; } = null!;
        public string Country { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Address { get; set; } = null!;

        public virtual ICollection<OrderObject> Orders { get; set; }
    }
}
