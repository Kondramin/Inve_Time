namespace Inve_Time.Models
{
    class EpmInfo
    {
        public int Id { get; set; }
        public FIO FIO { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

    }

    struct FIO
    {
        string Name { get; set; }
        string SecName { get; set; }
        string Part { get; set; }


        public override string ToString()
        {
            return SecName +" "+ Name + " " + Part;
        }
    }
        
}
