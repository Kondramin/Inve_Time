using Inve_Time.DataBase.dll.Entities;

namespace Inve_Time.Models
{
    class EmployeeBaseInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        public string Patronymic { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string PositionName { get; set; }



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
                return this.SecondName + this.Name + this.Patronymic + this.Phone + this.Email + this.PositionName;
            }
        }

    }
}
