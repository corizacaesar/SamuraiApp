using AutoMapper;
using SamuraiApp.API.DTO;
using SamuraiApp.Domain;

namespace SamuraiApp.API.Profiles
{
    public class PedangsProfile : Profile
    {
        public PedangsProfile()
        {
            CreateMap<Pedang, PedangDTO>();
            CreateMap<PedangCreateDTO, Pedang>();
            CreateMap<PedangCreateWithElementDTO, Pedang>();
            CreateMap<Pedang, PedangDTO>();
            CreateMap<ElementDTO, Element>();
        }
    }
}
