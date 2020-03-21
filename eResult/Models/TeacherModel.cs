using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IIT.EResult.Models
{
    public class TeacherModel : BaseModel
    {
        [Required]
        [Display(Name = "Teacher Name")]
        public virtual string Name { get; set; }

        [Required]
        [Display(Name = "Designation")]
        public virtual string Designation { get; set; }
        
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