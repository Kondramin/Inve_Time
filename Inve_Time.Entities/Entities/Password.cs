using Inve_Time.Entities.Base;

namespace Inve_Time.Entities.Entities
{
    public class Password : NamedEntity 
    { 
        public int? EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
