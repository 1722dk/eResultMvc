using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IIT.EResult.Biz;
using IIT.EResult.Models;
using IIT.EResult.Security;

namespace IIT.EResult.Controllers
{
    public class TeacherController : Controller
    {
        [HttpGet, ERAuthorizeAttribute()]
        public ActionResult Create()
        {
            ViewBag.Title = "New Teacher";
            ViewBag.EditMode = false;
            return View();
        }

        [HttpPost, ERAuthorizeAttribute()]
        public ActionResult Create(TeacherModel teacherModel)//(FormCollection form)
        {
            //var teacherModel=new TeacherModel();
            //TryUpdateModel(teacherModel, form);
            if (ModelState.IsValid)
            {
                var teacherBiz = new TeacherBiz();
                try
                {
                    var newTeacher = teacherBiz.SaveOrUpdate(teacherModel);
                    if (newTeacher.Id > 0)
                    {
                        ViewBag.Mode = true;
                        ViewBag.Message = "Data Saved Successfully";
                        return View("Summary", new TeacherBiz().GetTeacherList());
                    }
                }
                catch (Exception)
                {
                }
            }
            return View();
        }

        [ERAuthorizeAttribute()]
        public ActionResult Edit(int id)
        {
            ViewBag.Mode = true;
            ViewBag.Title = "Edit Teacher";
            ViewBag.EditMode = true;
            try
            {
                return View("Create", new TeacherBiz().GetTeacher(id));
            }
            catch (Exception)
            {
            }
            return View("Summary", new TeacherBiz().GetTeacherList());
        }

        [ERAuthorizeAttribute()]
        public ActionResult Delete(int id)
        {
            try
            {
                ViewBag.Mode = true;
                int rslt = new TeacherBiz().DeleteTeacher(new TeacherModel() { Id = id });
                ViewBag.Message = rslt > 0 ? "Data Deleted Successfully" : "Delete Failed";
            }
            catch (Exception)
            {
            }
            return View("Summary", new TeacherBiz().GetTeacherList());
        }

        [ERAuthorizeAttribute()]
        public ActionResult Details(int id)
        {
            return View(new TeacherBiz().GetTeacher(id));
        }

        [ERAuthorizeAttribute()]
        public ActionResult Summary()
        {
            ViewBag.Mode = false;
            ViewBag.Message = "";
            return View(new TeacherBiz().GetTeacherList());
            //var teacherList = new List<TeacherModel>();
            //var teacherBiz = new TeacherBiz();
            //teacherList = teacherBiz.GetTeacherList();
            //return View(teacherList);
        }
    }
}
