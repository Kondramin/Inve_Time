using Inve_Time.Entities.Base;
using Inve_Time.Interfaces.Services;
using Inve_Time.Models.Base;
using System;
using System.Collections.Generic;

namespace Inve_Time.Services.AutoMappers
{
    internal class AutoMapper<T, TT> : IAutoMapper<T, TT>
        where T : Entity, new()
        where TT : EntityModel, new()
    {
        public ICollection<T> MappToCollectuonEntities(TT item)
        {
            throw new NotImplementedException();
        }

        public ICollection<TT> MappToCollectuonModels(T item)
        {
            throw new NotImplementedException();
        }

        public T MappToEntity(TT item)
        {
            throw new NotImplementedException();
        }

        public TT MappToModel(T item)
        {
            throw new NotImplementedException();
        }
    }
}
