using AutoMapper;
using Inve_Time.Entities.Base;
using Inve_Time.Interfaces.Services;
using Inve_Time.Models.Base;
using System.Collections.Generic;

namespace Inve_Time.Services.AutoMappers.Base
{
    internal class AutoMapper<T, TT> : IAutoMapper<T, TT>
        where T : Entity, new()
        where TT : EntityModel, new()
    {
        
        public virtual MapperConfiguration MapperConfiguration()
        {
            return new MapperConfiguration(cfg => cfg.CreateMap<T, TT>());
        }

        public TT MappToModel(T item)
        {
            var config = MapperConfiguration();
            var mapper = new Mapper(config);

            var result = mapper.Map<TT>(item);

            return result;
        }

        public ICollection<TT> MappToCollectuonModels(ICollection<T> item)
        {
            var config = MapperConfiguration();
            var mapper = new Mapper(config);

            var result = mapper.Map<ICollection<TT>>(item);

            return result;
        }

    }
}
