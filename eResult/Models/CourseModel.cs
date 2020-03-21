using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IIT.EResult.Models
{
    public class CourseModel : BaseModel
    {
        //public virtual string CourseId { get; set; }

        [Required]
        [Display(Name = "Course Id")]
        public virtual string CourseId { get; set; }

        [Required]
        [Display(Name = "Course Credit")]
        public virtual string CourseCredit { get; set; }

        [Required]
        [Display(Name = "Course Title")]
        public virtual string CourseTitle { get; set; }
    }
}