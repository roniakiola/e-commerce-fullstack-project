using Application.Dto;
using Domain.Entity;
using AutoMapper;

namespace Presentation.Configuration
{
  public class MapperProfile : Profile
  {
    public MapperProfile()
    {
      CreateMap<User, UserReadDto>();
      CreateMap<UserCreateDto, User>();
      CreateMap<UserUpdateDto, User>()
        .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

      CreateMap<UserContactDetails, UserContactDetailsDto>();
      CreateMap<UserContactDetailsDto, UserContactDetails>();
      CreateMap<User, UserWithDetailsReadDto>()
        .ForMember(dest => dest.User, opt => opt.MapFrom(src => src))
        .ForMember(dest => dest.UserContactDetails, opt => opt.MapFrom(src => src.UserContactDetails));

      CreateMap<UserContactDetailsUpdateDto, UserContactDetails>()
        .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

      CreateMap<Product, ProductReadDto>();
      CreateMap<ProductCreateDto, Product>();
      CreateMap<ProductUpdateDto, Product>();

      CreateMap<Category, CategoryReadDto>();
      CreateMap<CategoryCreateDto, Category>();
      CreateMap<CategoryUpdateDto, Category>();
    }
  }
}