using System.ComponentModel.DataAnnotations;

namespace Manual_Identity.Models
{
    public class CourseViewModel
    {
        [Key]
        public int CourseId { get; set; }

        [Required(ErrorMessage ="Required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Required")]
        public string Details { get; set; }

    }
}
