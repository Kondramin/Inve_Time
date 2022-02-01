using AutoMapper;
using Inve_Time.Entities.Entities;
using Inve_Time.Models;
using Inve_Time.Services.AutoMappers.Base;

namespace Inve_Time.Services.AutoMappers
{
    internal class MappToCategorySearchWordModel : AutoMapper<CategorySearchWord, CategorySearchWordModel>
    {
        public override MapperConfiguration MapperConfiguration()
        {
            return new MapperConfiguration(cfg => cfg.CreateMap<CategorySearchWord, CategorySearchWordModel>()
                .ForMember("CategoryName", opt=>opt.MapFrom(h=>h.Category.Name)));
        }
    }
}
