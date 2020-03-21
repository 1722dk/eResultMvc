using System;
using System.ComponentModel.DataAnnotations;

namespace IIT.EResult.Models
{
    public abstract class BaseModel
    {
        public virtual int Id { get; set; }
        /*
        [Display(Name = "Is Active")]
        public virtual bool IsActive { get; set; }

        [Display(Name = "Is Deleted")]
        public virtual bool IsDeleted { get; set; }

        [Display(Name = "Created By")]
        public virtual int CreatedBy { get; set; }

        [Display(Name = "Modified By")]
        public virtual int ModifiedBy { get; set; }

        [Display(Name = "Created Date")]
        public virtual DateTime CreatedDate { get; set; }

        [Display(Name = "Last Modified Date")]
        public virtual DateTime ModifiedDate { get; set; }
        */
    }
}
