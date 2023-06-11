using AutoMapper;
using codegeneratorservice.Model;

namespace codegeneratorservice.Helper
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<UniqueCode, UniqueCodeDTO>().ReverseMap();
        }
    }
}