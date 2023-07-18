using AutoMapper;
using ShopApp.Core.Entities;
using ShopApp.Service.Dtos.BrandDtos;
using ShopApp.Service.Dtos.ProductDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Service.Profiles
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<BrandCreateDto, Brand>();
            CreateMap<Brand, BrandGetDto>();
            CreateMap<Brand,BrandInProductGetDto>();
            CreateMap<Brand,BrandGetAllItemDto>();

            CreateMap<ProductCreateDto, Product>();
            CreateMap<Product, ProductGetDto>()
                .ForMember(d => d.Profit, s => s.MapFrom(m => m.SalePrice - m.CostPrice));
            CreateMap<Product, ProductGetAllItemDto>();
        }
    }
}
