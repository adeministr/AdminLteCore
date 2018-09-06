using AutoMapper;

namespace Naitzel.Intranet.Service.AdminLte.Mapper
{
    public class ValidationProfile : Profile
    {
        public ValidationProfile()
        {
            CreateMap<FluentValidation.Results.ValidationFailure, Domain.AdminLte.Validation.ValidationFailure>()
                .ForMember(dest => dest.AttemptedValue, opt => opt.MapFrom(src => src.AttemptedValue))
                .ForMember(dest => dest.ErrorMessage, opt => opt.MapFrom(src => src.ErrorMessage))
                .ForMember(dest => dest.PropertyName, opt => opt.MapFrom(src => src.PropertyName));

            CreateMap<FluentValidation.Results.ValidationResult, Domain.AdminLte.Validation.ValidationResult>()
                .ForMember(dest => dest.Errors, opt => opt.MapFrom(src => src.Errors))
                .ForMember(dest => dest.IsValid, opt => opt.MapFrom(src => src.IsValid));
        }
    }
}