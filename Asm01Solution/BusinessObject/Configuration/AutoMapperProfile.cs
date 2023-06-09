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

            CreateMap<Product, ProductObject>().ReverseMap();
            CreateMap<Order, OrderObject>()
                    .ForMember(dest => dest.Member, opt => opt.MapFrom(src => src.Member))
                    .ReverseMap()
                    .ForMember(dest => dest.Member, opt => opt.MapFrom(src => src.Member));
            CreateMap<DataAccess.Models.Member, MemberObject>()
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => $"{src.City}, {src.Country}")).ReverseMap();
            CreateMap<OrderDetail, OrderDetailObject>()
                    .ForMember(dest => dest.Total, opt => opt.MapFrom(src => src.Quantity * (double)src.UnitPrice * (1 - src.Discount)))
                    .ReverseMap();
        }
    }
}
