using AutoMapper;
using MtnraProvidersManager_BAL.Dtos.Interlocutor;
using MtnraProvidersManager_DAL.Models;

namespace MtnraProvidersManager_PAL.Profiles
{
    public class InterlocutorProfile : Profile
    {
        public InterlocutorProfile()
        {
            CreateMap<Interlocutor, InterlocutorReadDto>();
            CreateMap<InterlocutorReadDto, Interlocutor>();
            CreateMap<Interlocutor, InterlocutorWriteDto>();
            CreateMap<InterlocutorWriteDto, Interlocutor>();
            CreateMap<Interlocutor, InterlocutorUpdateDto>();
            CreateMap<InterlocutorUpdateDto, Interlocutor>();
        }
    }
}
