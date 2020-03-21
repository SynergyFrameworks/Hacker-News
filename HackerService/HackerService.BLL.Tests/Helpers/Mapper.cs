using AutoMapper;
using HackerService.BLL.Mappings;

namespace HackerService.BLL.Tests.Helpers
{
    public static class Mapper
    {
        public static IMapper GetAutoMapper()
        {
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new HackerNewsMapping());

            });
            var mapper = mockMapper.CreateMapper();
            return mapper;
        }
    }
}
