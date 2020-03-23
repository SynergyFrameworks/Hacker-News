using AutoMapper;
using HackerService.DAL.Models;
using News = HackerService.BLL.Models.News;
using NewsType = HackerService.BLL.Models.NewsType;

namespace HackerService.BLL.Mappings
{
    public class HackerNewsMapping : Profile
    {
        public HackerNewsMapping()
        {
            CreateMap<News, NewsEntity>()
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