using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IIT.EResult.Models
{
    public class ResultModel
    {
        [Display(Name = "Id")]
        public virtual string StudentId { get; set; }
        [Display(Name = "Name")]
        public virtual string StudentName { get; set; }
        [Display(Name = "CourseId")]
        public virtual string CourseId { get; set; }
        [Display(Name = "BatchNo")]
        public virtual string BatchNo { get; set; }
        //[Display(Name = "ExamType")]
        //public virtual string ExamType { get; set; }
        //[Display(Name = "ExamNo")]
        //public virtual string ExamNo { get; set; }
        //[Display(Name = "Mark")]
        //public virtual string Mark { get; set; }
        [Display(Name = "Quiz")]
        public virtual string Quiz { get; set; }
        [Display(Name = "Assignment")]
        public virtual string Assignment { get; set; }
        [Display(Name = "Presentation")]
        public virtual string Presentation { get; set; }
        [Display(Name = "Attendance")]
        public virtual string Attendance { get; set; }
        [Display(Name = "MidTerm")]
        public virtual string MidTerm { get; set; }
        [Display(Name = "Final")]
        public virtual string Final { get; set; }
        [Display(Name = "Total")]
        public virtual string Total { get; set; }
        [Display(Name = "GradePoint")]
        public virtual string GradePoint { get; set; }
        [Display(Name = "GradePointLetter")]
        public virtual string GradePointLetter { get; set; }
    }
}