using AutoMapper;
using HackerService.API.Models;
using HackerService.DAL.Models;

namespace HackerService.API.Mappings
{
    public class NewsViewMappings : Profile
    {
        public NewsViewMappings()
        {
            CreateMap<BLL.Models.News, NewsEntity>()
                .ForMember(d => d.id, opt => opt.MapFrom(src => src.id.ToString()))
                .ForMember(d => d.title, opt => opt.MapFrom(src => src.title))
                .ForMember(d => d.type, opt => opt.MapFrom(src => src.type))
                .ForMember(d => d.text, opt => opt.MapFrom(src => src.text))
                .ForMember(d => d.url, opt => opt.MapFrom(src => src.url))
                .ForMember(d => d.score, opt => opt.MapFrom(src => src.score))
                .ForMember(d => d.time, opt => opt.MapFrom(src => src.time));




            CreateMap<NewsEntity, News>()
                .ForMember(d => d.id, opt => opt.MapFrom(src => src.id.ToString()))
                .ForMember(d => d.title, opt => opt.MapFrom(src => src.title))
                .ForMember(d => d.type, opt => opt.MapFrom(src => src.type))
                .ForMember(d => d.text, opt => opt.MapFrom(src => src.text))
                .ForMember(d => d.url, opt => opt.MapFrom(src => src.url))
                .ForMember(d => d.by, opt => opt.MapFrom(src => src.by))
                .ForMember(d => d.score, opt => opt.MapFrom(src => src.score))
                .ForMember(d => d.time, opt => opt.MapFrom(src => src.time));

        }
    }
}