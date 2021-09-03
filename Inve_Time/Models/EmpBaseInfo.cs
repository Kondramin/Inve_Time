using Inve_Time.DataBase.dll.Entities;

namespace Inve_Time.Models
{
    /// <summary>Helpfull class of model. Using to working with colections to show info about Employees.</summary>
    class EmpBaseInfo : Employee
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
        


        /// <summary>Helpful property. Return SecondName, Name, Patronymic in one field as FIO</summary>
        public string Fio { get => SecondName + " " + Name + " " + Patronymic; }



        /// <summary>Helpful property. Using in filters</summary>
        public string Any { get => SecondName ?? "" + Name ?? "" + Patronymic ?? "" + Phone ?? "" + Email ?? "" + Position.Name ?? ""; }
    }
}
