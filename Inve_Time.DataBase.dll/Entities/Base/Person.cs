namespace Inve_Time.DataBase.dll.Entities.Base
{
    public abstract class Person : NamedEntity
    {
        public string SecondName { get; set; }
        public string Patronymic { get; set; }
    }
}
