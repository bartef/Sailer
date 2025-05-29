using Application.DTOs;
using AutoMapper;
using Core.Entities;

namespace Infrastructure.Mappers;

public static class AutoMapperConfig
{
    public static IMapper Initialize() => new MapperConfiguration(cfg =>
    {
        cfg.CreateMap<User, UserDTO>()
            .ConstructUsing(x =>
                new UserDTO(x.Email.Value, x.Phone!.Present(), x.UserName!.Name, x.UserName!.Surname, x.Age!.Value))
            .ForMember(x => x.Email, m => m.MapFrom(u => u.Email.Value))
            .ForMember(x => x.Phone, m => m.MapFrom(u => u.Phone!.Present()))
            .ForMember(x => x.Name, m => m.MapFrom(u => u.UserName!.Name))
            .ForMember(x => x.Surname, m => m.MapFrom(u => u.UserName!.Surname))
            .ForMember(x => x.Age, m => m.MapFrom(u => u.Age!.Value));
    }).CreateMapper();
}