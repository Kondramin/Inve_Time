using Inve_Time.DataBase.dll.Entities;

namespace Inve_Time.Models
{
    /// <summary>
    /// Helpfull class of model. 
    /// Using to working with colections to show info about Employees. 
    /// </summary>
    class EmpBaseInfo
    {
        /// <summary>Simple ctor</summary>
        public EmpBaseInfo() { }

        /// <summary>Ctor to convert Employee to EmpBaseInfo</summary>
        /// <param name="emp">Employee entity</param>
        public EmpBaseInfo(Employee emp)
        {
            Id = emp.Id;
            SecondName = emp.SecondName;
            Name = emp.Name;
            Patronymic = emp.Patronymic;
            Phone = emp.Phone;
            Email = emp.Email;
            Login = emp.Login;
            Position = emp.Position;
        }

        public int Id { get; set; }
        public string SecondName { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public Position Position{ get; set; }



        /// <summary>Helpful property. Return SecondName, Name, Patronymic in one field as FIO</summary>
        public string Fio
        {
            get
            {
                return this.SecondName + " " + this.Name + " " + this.Patronymic;
            }
        }



        /// <summary>Helpful property. Using in filters</summary>
        public string Any
        {
            get
            {
                return this.SecondName + this.Name + this.Patronymic + this.Phone + this.Email + this.Position.Name;
            }
        }


        /// <summary>Helpful method. Convert EmpBaseInfo to Employee</summary>
        /// <returns>Employee entity</returns>
        public Employee ConvertToEmployee()
        {
            return new Employee
            {
                Id = Id,
                SecondName = SecondName,
                Name = Name,
                Patronymic = Patronymic,
                Phone = Phone,
                Email = Email,
                Login = Login,
                Position = Position
            };
        }

    }
}
