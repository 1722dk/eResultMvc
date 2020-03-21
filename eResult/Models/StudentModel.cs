using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IIT.EResult.Models
{
    public class StudentModel : BaseModel
    {
        [Required]//(ErrorMessage = "Student name required")]
        [Display(Name = "Student Name")]
        public virtual string Name { get; set; }

        [Required]
        [Display(Name = "Batch No")]
        public virtual string BatchNo { get; set; }

        [Required]
        [Display(Name = "Session")]
        public virtual string Session { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Invalid email address!")]
        public virtual string Email { get; set; }

        [Required]
        [Display(Name = "Contact No")]
        public virtual string ContactNo { get; set; }
    }
}