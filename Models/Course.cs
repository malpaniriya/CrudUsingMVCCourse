using System.ComponentModel.DataAnnotations;

namespace CrudUsingMVCCourse.Models
{
    public class Course
    {
        public int Id { get; set; }
        [Required]

        public string? Name{ get; set; }
        [Required]

        public int Duration { get; set; }

        public double fees { get; set; }



    }
}
