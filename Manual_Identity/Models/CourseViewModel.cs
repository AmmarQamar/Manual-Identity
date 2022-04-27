using System.ComponentModel.DataAnnotations;

namespace Manual_Identity.Models
{
    public class CourseViewModel
    {
        [Key]
        public int CourseId { get; set; }

        [Required(ErrorMessage ="Required")]
        public string Name { get;set; }
        //public CourseName Name { get; set; }


        [Required(ErrorMessage = "Required")]
        public string Details { get; set; }

        //public virtual ICollection<StudentViewModel> Students { get; set; }

    }
    //public enum CourseName
    //{
    //    CS,
    //    SE,
    //    ME,
    //    BBA,
    //    CA
        
    //}
}
