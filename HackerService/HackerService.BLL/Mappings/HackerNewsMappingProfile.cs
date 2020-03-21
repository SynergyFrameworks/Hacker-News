using AutoMapper;
using HackerService.BLL.Models;
using HackerService.DAL.Models;
using System;

namespace HackerService.BLL.Mappings
{
    public class HackerNewsMapping : Profile
    {
        public HackerNewsMapping()
        {
            CreateMap<News, NewsEntity>()
                .ForMember(d => d.id, opt => opt.MapFrom(src => src.id.ToString()))
                .ForMember(d => d.title, opt => opt.MapFrom(src => src.title))
                .ForMember(d => d.type, opt => opt.MapFrom(src => (int) src.type))
                .ForMember(d => d.time, opt => opt.MapFrom(src => src.time));


            CreateMap<NewsEntity, News>()
                .ForMember(d => d.id, opt => opt.MapFrom(src => Guid.Parse(src.id)))
                .ForMember(d => d.title, opt => opt.MapFrom(src => src.title))
                .ForMember(d => d.type, opt => opt.MapFrom(src => (NewsType) src.type))
                .ForMember(d => d.time, opt => opt.MapFrom(src => src.time));

        }
    }
}
