using Inve_Time.Interfaces.dll;

namespace Inve_Time.DataBase.dll.Entities.Base
{
    public abstract class Entity : IEntity
    {
        public int Id { get; set; }
    }
}
