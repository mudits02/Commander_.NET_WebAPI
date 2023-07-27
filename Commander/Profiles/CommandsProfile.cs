using Commander.DTO;
using Commander.Models;
using AutoMapper;

namespace Commander.Profiles
{
    public class CommandsProfile : Profile
    {
        public CommandsProfile()
        {
            CreateMap<Command , CommandReadDTO>();
            CreateMap<CommandCreateDTO , Command>();
        }
    }
}