using Inve_Time.Interfaces.Entities;

namespace Inve_Time.Entities.Base
{
    public abstract class Entity : IEntity
    {
        public int Id { get; set; }
    }
}
