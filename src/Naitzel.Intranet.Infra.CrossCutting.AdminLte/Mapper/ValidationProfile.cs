using AutoMapper;
using CValidation = Naitzel.Intranet.Domain.AdminLte.Validation.ValidationResult;
using CValidationFailure = Naitzel.Intranet.Domain.AdminLte.Validation.ValidationFailure;
using FValidation = FluentValidation.Results.ValidationResult;
using FValidationFailure = FluentValidation.Results.ValidationFailure;

namespace Naitzel.Intranet.Infra.CrossCutting.AdminLte.Mapper
{
    public class ValidationProfile : Profile
    {
        public ValidationProfile()
        {
            CreateMap<CValidation, FValidation>()
                .ForMember(dst => dst.Errors, opt => opt.MapFrom(src => src.Errors))
                .ForMember(dst => dst.IsValid, opt => opt.Ignore());

            CreateMap<CValidationFailure, FValidationFailure>()
                .ForMember(dst => dst.PropertyName, opt => opt.MapFrom(src => src.PropertyName))
                .ForMember(dst => dst.ErrorMessage, opt => opt.MapFrom(src => src.ErrorMessage))
                .ForMember(dst => dst.AttemptedValue, opt => opt.Ignore())
                .ForMember(dst => dst.CustomState, opt => opt.Ignore())
                .ForMember(dst => dst.ErrorCode, opt => opt.Ignore())
                .ForMember(dst => dst.FormattedMessageArguments, opt => opt.Ignore())
                .ForMember(dst => dst.FormattedMessagePlaceholderValues, opt => opt.Ignore())
                .ForMember(dst => dst.ResourceName, opt => opt.Ignore())
                .ForMember(dst => dst.Severity, opt => opt.Ignore());
        }
    }
}