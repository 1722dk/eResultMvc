using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IIT.EResult.Models
{
    public class ExamResultModel : BaseModel
    {
        //public virtual int ExamId { get; set; }

        //[Required]
        [Display(Name = "Student Id")]
        public virtual string StudentId { get; set; }

        [Display(Name = "Student Name")]
        public virtual string StudentName { get; set; }

        [Required]
        [Display(Name = "Course")]
        public virtual string CourseId { get; set; }

        [Required]
        [Display(Name = "BatchNo")]
        public virtual string BatchNo { get; set; }

        //[Required]
        [Display(Name = "Exam Type")]
        public virtual string ExamType { get; set; }

        //[Required]
        [Display(Name = "Exam No")]
        public virtual string ExamNo { get; set; }
        
        //[Required]
        [Display(Name = "Mark")]
        public virtual double Mark { get; set; }

        [ScaffoldColumn(false)]
        public virtual string SpName { get; set; }
    }
}