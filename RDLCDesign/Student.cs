namespace RDLCDesign
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Student
    {
        public int StudentId { get; set; }

        [Required]
        public string StudentName { get; set; }

        [Required]
        public string FatherName { get; set; }

        public int CourseId { get; set; }

        [Required]
        public string Address { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime AdmissionDate { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime AdmissionYear { get; set; }

        [Required]
        public string ContactNo { get; set; }

        [Required]
        public string Email { get; set; }

        public string PhotoPath { get; set; }

        public int Month { get; set; }

        public int Year { get; set; }

        [Required]
        public string CourseName { get; set; }
    }
}
