using AutoMapper;
using SamuraiApp.API.DTO;
using SamuraiApp.Domain;

namespace SamuraiApp.API.Profiles
{
    public class SamuraisProfile : Profile
    {
        public SamuraisProfile()
        {
            CreateMap<Samurai, SamuraiDTO>();
            CreateMap<SamuraiCreateDTO, Samurai>();
            CreateMap<SamuraiCreateWithPedangDTO, Samurai>();
        }
    }
}
