namespace RDLCDesign
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Courses")]
    public partial class Cours
    {
        [Key]
        public int CourseId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Details { get; set; }
    }
}
