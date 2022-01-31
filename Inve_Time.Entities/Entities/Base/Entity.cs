using Inve_Time.Entities.Interface;

namespace Inve_Time.Entities.Base
{
    public abstract class Entity : IEntity
    {
        public int Id { get; set; }
    }
}
