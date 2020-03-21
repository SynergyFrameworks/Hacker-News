using AutoMapper;

namespace HackerService.API.Mappings
{
    public class NewsViewMappings : Profile
    {
        public NewsViewMappings()
        {
            CreateMap<BLL.Models.News, Models.News>()
                .ForMember(d => d.id, opt => opt.MapFrom(src => src.id))
                .ForMember(d => d.title, opt => opt.MapFrom(src => src.title))
                .ForMember(d => d.type, opt => opt.MapFrom(src => src.type))
                .ForMember(d => d.time, opt => opt.MapFrom(src => src.time));


            CreateMap<Models.News, BLL.Models.News>()
                .ForMember(d => d.id, opt => opt.MapFrom(src => src.id))
                .ForMember(d => d.title, opt => opt.MapFrom(src => src.title))
                .ForMember(d => d.type, opt => opt.MapFrom(src => src.type))
                .ForMember(d => d.time, opt => opt.MapFrom(src => src.time));

        }
    }
}
