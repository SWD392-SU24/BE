using AutoMapper;
using Backend.BO.Commons;
using Backend.BO.Entities;
using Backend.BO.Payloads.Requests;
using Backend.BO.Payloads.Responses;

namespace Backend.BLL.Mapping
{
    public class MappingProfiles : Profile
    {
        /// <summary>
        /// A class used for mapping entities with other response types, using AutoMapper
        /// </summary>
        public MappingProfiles()
        {
            CreateMap<User, UserResponse>().ReverseMap();
            CreateMap<User, CustomerSignupRequest>().ReverseMap();
            CreateMap<User, ClinicOwnerSignupRequest>().ReverseMap();

            CreateMap<Clinic, ClinicRequest>()
            .ForMember(dest => dest.NumberOfEmployees, opt => opt.MapFrom(src => src.NumberOfEmployees.ToString()))
            .ForMember(dest => dest.OwnerId, opt => opt.MapFrom(src => src.OwnerId.ToString()))
            .ForMember(dest => dest.AreaId, opt => opt.MapFrom(src => src.AreaId.ToString()))
            .ReverseMap()
            .ForMember(dest => dest.NumberOfEmployees, opt => opt.MapFrom(src => int.Parse(src.NumberOfEmployees)))
            .ForMember(dest => dest.OwnerId, opt => opt.MapFrom(src => Guid.Parse(src.OwnerId)))
            .ForMember(dest => dest.AreaId, opt => opt.MapFrom(src => int.Parse(src.AreaId)));
            CreateMap<Clinic, ClinicResponse>()
            .ForMember(dest => dest.NumberOfEmployees, opt => opt.MapFrom(src => src.NumberOfEmployees.ToString()))
            .ForMember(dest => dest.OwnerId, opt => opt.MapFrom(src => src.OwnerId.ToString()))
            .ForMember(dest => dest.AreaId, opt => opt.MapFrom(src => src.AreaId.ToString()))
            .ReverseMap()
            .ForMember(dest => dest.NumberOfEmployees, opt => opt.MapFrom(src => int.Parse(src.NumberOfEmployees)))
            .ForMember(dest => dest.OwnerId, opt => opt.MapFrom(src => Guid.Parse(src.OwnerId)))
            .ForMember(dest => dest.AreaId, opt => opt.MapFrom(src => int.Parse(src.AreaId)));
            CreateMap<ClinicRequest, ClinicResponse>().ReverseMap();
        }
    }
}
