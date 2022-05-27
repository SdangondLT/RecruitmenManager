using AutoMapper;
using RecruitmentManager.Entities.DTOs;
using RecruitmentManager.Entities.Entities;

namespace RecruitmentManager.Core.Core.Mapping
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<ClientCreateDto, Client>();
            CreateMap<Client, ClientCreateDto>();
        }
    }
}
