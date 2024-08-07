﻿using AutoMapper;
using Backend.BO.Commons;
using Backend.BO.Entities;
using Backend.BO.Enums;
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
            #region User
            CreateMap<User, UserResponse>().ReverseMap();
            CreateMap<UpdateUserRequest, User>()
               .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
               .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
               .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
               .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
               .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth))
               .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
               .ForMember(dest => dest.Sex, opt => opt.MapFrom(src => src.Sex))
               .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role))
               .ReverseMap();

            CreateMap<User, UserDashboardReponse>().ReverseMap();
            CreateMap<User, CustomerSignupRequest>().ReverseMap();
            CreateMap<User, ClinicOwnerSignupRequest>().ReverseMap();
            CreateMap<PageList<User>, PageList<UserDashboardReponse>>()
                            .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items));
            CreateMap<User, UserRequest>().ReverseMap();
            CreateMap<UpdateCustomerRequest, User>().ReverseMap();
            #endregion

            #region Clinic
            CreateMap<Clinic, ClinicRequest>()
                .ForMember(dest => dest.EmployeeSize, opt => opt.MapFrom(src => src.EmployeeSize.ToString()))
                .ForMember(dest => dest.OwnerId, opt => opt.MapFrom(src => src.OwnerId.ToString()))
                .ForMember(dest => dest.AreaId, opt => opt.MapFrom(src => src.AreaId.ToString()))
                .ReverseMap()
                .ForMember(dest => dest.EmployeeSize, opt => opt.MapFrom(src => int.Parse(src.EmployeeSize)))
                .ForMember(dest => dest.OwnerId, opt => opt.MapFrom(src => Guid.Parse(src.OwnerId)))
                .ForMember(dest => dest.AreaId, opt => opt.MapFrom(src => int.Parse(src.AreaId)));

            CreateMap<Clinic, ClinicResponse>()
                .ForMember(dest => dest.EmployeeSize, opt => opt.MapFrom(src => src.EmployeeSize.ToString()))
                .ForMember(dest => dest.OwnerId, opt => opt.MapFrom(src => src.OwnerId.ToString()))
                .ForMember(dest => dest.AreaId, opt => opt.MapFrom(src => src.AreaId.ToString()))
                .ReverseMap()
                .ForMember(dest => dest.EmployeeSize, opt => opt.MapFrom(src => int.Parse(src.EmployeeSize)))
                .ForMember(dest => dest.OwnerId, opt => opt.MapFrom(src => Guid.Parse(src.OwnerId)))
                .ForMember(dest => dest.AreaId, opt => opt.MapFrom(src => int.Parse(src.AreaId)));

            CreateMap<ClinicRequest, ClinicResponse>().ReverseMap();
            CreateMap<Clinic, ClinicCustomerPageResponse>()
                .ReverseMap();
            #endregion

            #region Certificate
            CreateMap<Certificate, CertificateResponse>().ReverseMap();
            CreateMap<Certificate, CertificateRequest>().ReverseMap();
            CreateMap<Certificate, UpdateCertificateRequest>().ReverseMap();
            #endregion

            CreateMap<Area, AreaResponse>().ReverseMap();

            #region Service
            CreateMap<Service, ServiceClinicResponse>();
            CreateMap<Service, ServiceResponse>();
            #endregion

            CreateMap<Dentist, DentistResponse>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
                .ReverseMap();

            #region DentistSchedule
            CreateMap<DentistScheduleRequest, DentistSchedule>()
                .ForMember(dest => dest.ScheduleId, opt => opt.MapFrom(src => Guid.NewGuid()))
                .ReverseMap();
            CreateMap<DentistScheduleResponse, DentistSchedule>().ReverseMap();
            CreateMap<UpdateScheduleWorkingTimeRequest, DentistSchedule>();
            #endregion

            CreateMap<AppointmentRequest, Appointment>();
            CreateMap<AppointmentServiceRequest, AppointmentService>();

        }
    }
}
