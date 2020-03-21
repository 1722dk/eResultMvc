using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IIT.EResult.Models.ViewModels
{
    public class EmployeeGridViewModel
    {
        public virtual int Id { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string Login { get; set; }
        //public virtual string PIN { get; set; }
        public virtual string Phone { get; set; }
        public virtual string Email { get; set; }
        //public virtual string Phone2 { get; set; }
        //public virtual string PresentAddress { get; set; }
        //public virtual string ParmanentAddress { get; set; }
    }
}