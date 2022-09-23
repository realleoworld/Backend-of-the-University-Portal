namespace RealleoschoolindAPI.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string password { get; set; }
        public string Email { get; set; }
        public string Department { get; set; }
        public long Phone { get; set; }
        public bool isActive { get; set; } = true;
       
    }
}
