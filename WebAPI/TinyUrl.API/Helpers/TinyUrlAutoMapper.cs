using AutoMapper;
using TinyUrl.Repository.Model;
using TinyUrl.ViewModels;

namespace TinyUrl.API.Helpers
{
    public class TinyUrlAutoMapper : Profile
    {
        public TinyUrlAutoMapper()
        {
           CreateMap<Repository.Model.TinyUrl, TinyURLAddViewModel>().ReverseMap();
            CreateMap<Repository.Model.TinyUrl, TinyURLDTOViewModel>().ForMember(dest => dest.TinyURLId,
        opt => opt.MapFrom(src => src.Id)).ReverseMap();


        }
    
    }
}
