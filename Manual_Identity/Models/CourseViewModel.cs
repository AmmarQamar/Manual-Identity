using System.ComponentModel.DataAnnotations;

namespace Manual_Identity.Models
{
    public class CourseViewModel
    {
        [Key]
        public int CourseId { get; set; }

        [Required(ErrorMessage ="Required")]
<<<<<<< HEAD
        public string Name { get; set; }
=======
        public string Name { get;set; }
        //public CourseName Name { get; set; }

>>>>>>> 0ab365ef4b88f303d38a71dfe6eba7c3d22a4e27

        [Required(ErrorMessage = "Required")]
        public string Details { get; set; }

<<<<<<< HEAD
    }
=======
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
>>>>>>> 0ab365ef4b88f303d38a71dfe6eba7c3d22a4e27
}
