using AutoMapper;
using UniHelper.Backend.Entities;
using UniHelper.Shared.DTOs;
using UniHelper.Shared.Models;

namespace UniHelper.Backend.Mappers
{
    /// <summary>
    /// User Mapper
    /// </summary>
    public class UserMapper : Profile
    {
        /// <summary>
        /// Init User Mapper
        /// </summary>
        public UserMapper()
        {
            CreateMap<User, UserDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Registration, opt => opt.MapFrom(src => src.Registration))
                .ForMember(dest => dest.LastLogin, opt => opt.MapFrom(src => src.LastLogin));

            CreateMap<UserModel, User>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))
                .ForMember(dest => dest.Registration, opt => opt.MapFrom(src => src.Registration))
                .ForMember(dest => dest.LastLogin, opt => opt.MapFrom(src => src.LastLogin));
        }
    }
}