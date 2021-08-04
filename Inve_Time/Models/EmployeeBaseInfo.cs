using Inve_Time.DataBase.dll.Entities;

namespace Inve_Time.Models
{
    class EmployeeBaseInfo : Employee
    {
        public string Fio
        {
            get
            {
                return this.SecondName + " " + this.Name + " " + this.Patronymic;
            }
        }

        public string Any
        {
            get
            {
                return this.SecondName + this.Name + this.Patronymic + this.Phone + this.Email + this.Position.Name;
            }
        }

    }
}
