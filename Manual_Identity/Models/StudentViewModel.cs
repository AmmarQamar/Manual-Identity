using System.ComponentModel.DataAnnotations;
<<<<<<< HEAD
=======
using System.ComponentModel.DataAnnotations.Schema;
>>>>>>> 0ab365ef4b88f303d38a71dfe6eba7c3d22a4e27

namespace Manual_Identity.Models
{
    public class StudentViewModel
    {
        [Key]
        public int StudentId { set; get; }

        [Required(ErrorMessage ="*Required")]
        public string StudentName { set; get; }

        [Required(ErrorMessage = "*Required")]
        public string FatherName { set; get; }

<<<<<<< HEAD
        [Required(ErrorMessage = "*Required")]
        public int CourseId { set; get; }

        [Required(ErrorMessage = "*Required")]
        public string Address { set; get; }
    }
=======
        //public int CourseId { set; get; }

        [Required(ErrorMessage = "*Required")]
        public string Address { set; get; }


        [Required(ErrorMessage = "*Required")]
        public int CourseId { get; set; }
        //public CourseViewModel Courses { get; set; }
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
