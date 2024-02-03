using AutoMapper;
using MtnraProvidersManager_BAL.Dtos.Direction;
using MtnraProvidersManager_BAL.Dtos.Interlocutor;
using MtnraProvidersManager_DAL.Models;

namespace MtnraProvidersManager_PAL.Profiles
{
    public class DirectionProfile : Profile
    {
        public DirectionProfile()
        {
            CreateMap<Direction, DirectionReadDto>()
                .ForMember(
                    dest => dest.Interlocutor,
                    opt => opt.MapFrom(src =>
                        new InterlocutorReadDto { Id = (Guid)src.InterlocutorId! }
                    ));
            CreateMap<DirectionReadDto, Direction>();
            CreateMap<Direction, DirectionWriteDto>();
            CreateMap<DirectionWriteDto, Direction>();
            CreateMap<Direction, DirectionUpdateDto>();
            CreateMap<DirectionUpdateDto, Direction>();
        }

    }
}
