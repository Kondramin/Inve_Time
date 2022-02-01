using Inve_Time.Entities.Interface;
using Inve_Time.Interfaces.ModelEntities;
using System.Collections.Generic;

namespace Inve_Time.Interfaces.Services
{
    public interface IAutoMapper<T, TT> 
        where T : class, IEntity, new() 
        where TT : class, IEntityModel, new()
    {
        public TT MappToModel(T item);

        public ICollection<TT> MappToCollectuonModels(ICollection<T> item);
    }
}
