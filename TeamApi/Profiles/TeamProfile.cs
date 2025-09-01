using AutoMapper;
using TeamApi.Data.Dtos;
using TeamApi.Models;

namespace TeamApi.Profiles;

public class TeamProfile : Profile
{
    public TeamProfile()
    {
        CreateMap<Team, ReadTeamDtos>();
        CreateMap<CreateDto, Team>();
        CreateMap<UpdateDto, Team>();
        CreateMap<Team, UpdateDto>();

    }
}
