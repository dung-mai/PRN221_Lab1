using AutoMapper;
using AutoMapper.Execution;
using BusinessLayer.BusinessObject;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Configuration
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<Product, ProductObject>();
            CreateMap<Order, OrderObject>().ReverseMap();
            CreateMap<DataAccess.Models.Member, MemberObject>().ReverseMap();
            CreateMap<OrderDetail, OrderDetailObject>().ReverseMap();

        }
    }
}
