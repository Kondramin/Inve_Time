namespace Inve_Time.Models
{
    class EmpBaseInfo
    {
        public int Id { get; set; }
        public FIO _FIO { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public string Position { get; set; }

    }

    public struct FIO
    {
        public string Name { get; set; }
        public string SecName { get; set; }
        public string Part { get; set; }


        public override string ToString()
        {
            return SecName + " " + Name + " " + Part;
        }
    }

}
