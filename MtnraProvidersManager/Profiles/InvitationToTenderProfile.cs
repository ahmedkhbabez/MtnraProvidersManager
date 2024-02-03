using AutoMapper;
using MtnraProvidersManager_BAL.Dtos.Direction;
using MtnraProvidersManager_BAL.Dtos.InvitationToTender;
using MtnraProvidersManager_DAL.Models;

namespace MtnraProvidersManager_PAL.Profiles
{
	public class InvitationToTenderProfile : Profile
	{
		public InvitationToTenderProfile()
		{
			CreateMap<InvitationToTender, InvitationToTenderReadDto>()
				.ForMember(
					dest => dest.Direction,
					opt => opt.MapFrom(src =>
						new DirectionReadDto
						{
							Id = src.DirectionId!
						}));
			CreateMap<InvitationToTenderReadDto, InvitationToTender>();
			CreateMap<InvitationToTenderWriteDto, InvitationToTender>();
			CreateMap<InvitationToTender, InvitationToTenderWriteDto>();
			CreateMap<InvitationToTenderUpdateDto, InvitationToTender>();
			CreateMap<InvitationToTender, InvitationToTenderUpdateDto>();
		}
	}
}
