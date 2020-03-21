using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IIT.EResult.Models
{
    public class ExamModel : BaseModel
    {
        //public virtual int ExamId { get; set; }

        [Required]
        [Display(Name = "BatchNo")]
        public virtual string BatchNo { get; set; }

        [Required]
        [Display(Name = "Course")]
        public virtual string CourseId { get; set; }

        [Required]
        [Display(Name = "Exam Type")]
        public virtual string ExamType { get; set; }

        [Required]
        [Display(Name = "ExamNo")]
        public virtual string ExamNo { get; set; }

        [Required]
        [Display(Name = "Exam Marks")]
        public virtual  double ExamMarks { get; set; }
    }
}