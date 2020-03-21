using System.Web;
using IIT.EResult.Models;

namespace IIT.EResult.Utility
{
    public static class SessionVars
    {
        public static LoginModel CurrentLoggedInUser
        {
            get
            {
                return HttpContext.Current.Session["CurrentLoggedInUser"] as LoginModel;
            }
            set
            {
                HttpContext.Current.Session["CurrentLoggedInUser"] = value;
            }
        }
    }
}