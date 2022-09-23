using System.ComponentModel.DataAnnotations;

namespace RealleoschoolindAPI.Models
{
    public class course
    {
        [Key]
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public double CourseFees { get; set;}
        public bool isDeleted { get; set; } = false;
        public bool isActive { get; set; } = true;
    }
}
