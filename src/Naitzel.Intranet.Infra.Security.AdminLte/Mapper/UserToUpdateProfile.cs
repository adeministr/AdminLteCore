using AutoMapper;

using Naitzel.Intranet.Domain.AdminLte.Entities;
using Naitzel.Intranet.Infra.Security.AdminLte.ViewModel;

namespace Naitzel.Intranet.Infra.Security.AdminLte.Mapper
{
    public class UserToUpdateProfile : Profile
    {
        public UserToUpdateProfile()
        {
            CreateMap<User, UserUpdateViewModel>()
                .ReverseMap()
                .ForMember(dst => dst.AvatarURL, opt => opt.Ignore())
                .ForMember(dst => dst.NormalizedUserName, opt => opt.Ignore())
                .ForMember(dst => dst.NormalizedEmail, opt => opt.Ignore())
                .ForMember(dst => dst.EmailConfirmed, opt => opt.Ignore())
                .ForMember(dst => dst.PasswordHash, opt => opt.Ignore())
                .ForMember(dst => dst.SecurityStamp, opt => opt.Ignore())
                .ForMember(dst => dst.ConcurrencyStamp, opt => opt.Ignore())
                .ForMember(dst => dst.PhoneNumber, opt => opt.Ignore())
                .ForMember(dst => dst.PhoneNumberConfirmed, opt => opt.Ignore())
                .ForMember(dst => dst.TwoFactorEnabled, opt => opt.Ignore())
                .ForMember(dst => dst.LockoutEnd, opt => opt.Ignore())
                .ForMember(dst => dst.LockoutEnabled, opt => opt.Ignore())
                .ForMember(dst => dst.AccessFailedCount, opt => opt.Ignore());
        }
    }
}