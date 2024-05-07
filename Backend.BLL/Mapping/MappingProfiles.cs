using AutoMapper;
using Backend.BO.Commons;
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
        }
    }
}
