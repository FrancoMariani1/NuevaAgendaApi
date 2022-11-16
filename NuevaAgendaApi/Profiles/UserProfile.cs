using AutoMapper;
using NuevaAgendaApi.Dto;
using NuevaAgendaApi.Entities;

namespace NuevaAgendaApi.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, CreateAndUpdateUserDTO>();
            CreateMap<GetUserByIdResponse, User>();
        }
    }
}
