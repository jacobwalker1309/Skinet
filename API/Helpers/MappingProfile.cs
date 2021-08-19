using API.DTOs;
using AutoMapper;
using Core.Entities;
using Core.Entities.Identity;

namespace API.Helpers
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Product,ProductToReturnDTO>()
            .ForMember(d => d.ProductBrand,o => o.MapFrom(s => s.ProductBrand.Name))
            .ForMember(d => d.ProductType,o => o.MapFrom(s => s.ProductType.Name))
            .ForMember(d => d.PictureUrl,o => o.MapFrom<ProductURLResolver>());
            CreateMap<Address,AddressDTO>().ReverseMap();

        }
        
    }
}