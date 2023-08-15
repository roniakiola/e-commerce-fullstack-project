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
      CreateMap<UserUpdateDto, User>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
    }
  }
}