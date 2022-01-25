namespace Inve_Time.Entities.Base
{
    public abstract class PersonEntity : NamedEntity
    {
        public string SecondName { get; set; }
        public string Patronymic { get; set; }
    }
}
