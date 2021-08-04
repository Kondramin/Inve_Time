using Inve_Time.DataBase.dll.Entities.Base;

namespace Inve_Time.DataBase.dll.Entities
{
    public class Password : NamedEntity
    {
        public int? EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
