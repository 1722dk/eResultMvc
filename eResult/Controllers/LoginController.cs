using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IIT.EResult.Biz;
using IIT.EResult.Utility;
using IIT.EResult.Models;
using IIT.EResult.Security;
using IIT.EResult.Security.Models;

namespace IIT.EResult.Controllers
{
    public class LoginController : Controller
    {
        private IMembershipService _MembershipService;
        private ERFormsAuthenticationService _ERFormsAuthenticationService;

        public LoginController()
        {
            _MembershipService = new UserBiz();
            _ERFormsAuthenticationService = new ERFormsAuthenticationService(_MembershipService);
        }

        public ActionResult Index()
        {            
            return View();
        }

        public ActionResult Login()
        {
            this.Logout();
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel loginModel)
        {
            try
            {
                AuthStatus authStatus = _ERFormsAuthenticationService.SignIn(loginModel.Login, loginModel.PIN, false);
                if (authStatus.Code == AuthStatusCode.SUCCESS)
                {
                    List<Employee> userModelList = new List<Employee>() { authStatus.Data as Employee };
                    ViewBag.Login = loginModel.Login;
                    ViewBag.PIN = loginModel.PIN;

                    SessionVars.CurrentLoggedInUser = (Employee)authStatus.Data;

                    return RedirectToAction("List", "User");
                }
                else
                {
                    ModelState.AddModelError("", "The user name or password provided is incorrect.");
                }
            }
            catch (Exception)
            {
                //Elmah.ErrorSignal.FromCurrentContext();
            }
            // If we got this far, something failed, redisplay form
            return View(loginModel);
        }

        public ActionResult Logout()
        {
            _ERFormsAuthenticationService.SignOut();
            return RedirectToAction("Login","Login");
        } 
    }
}
