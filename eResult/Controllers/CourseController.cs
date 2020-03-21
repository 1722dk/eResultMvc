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
    public class CourseController : Controller
    {
        [HttpGet, ERAuthorizeAttribute()]
        public ActionResult Create()
        {
            ViewBag.Title = "New Course";
            ViewBag.EditMode = false;
            return View();
        }

        [HttpPost, ERAuthorizeAttribute()]
        public ActionResult Create(CourseModel courseModel)
        {
            if (ModelState.IsValid)
            {
                var courseBiz = new CourseBiz();
                try
                {
                    var newCourse = courseBiz.SaveOrUpdate(courseModel);
                    if (newCourse.Id > 0)
                    {
                        ViewBag.Mode = true;
                        ViewBag.Message = "Data Saved Successfully";
                        return View("Summary", new CourseBiz().GetCourseList());
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
            ViewBag.Title = "Edit Course";
            ViewBag.EditMode = true;
            try
            {
                return View("Create", new CourseBiz().GetCourse(id));
            }
            catch (Exception)
            {
            }
            return View("Summary", new CourseBiz().GetCourseList());
        }

        [ERAuthorizeAttribute()]
        public ActionResult Delete(int id)
        {
            try
            {
                ViewBag.Mode = true;
                int rslt = new CourseBiz().DeleteCourse(new CourseModel() { Id = id });
                ViewBag.Message = rslt > 0 ? "Data Deleted Successfully" : "Delete Failed";
            }
            catch (Exception)
            {
            }
            return View("Summary", new CourseBiz().GetCourseList());
        }

        [ERAuthorizeAttribute()]
        public ActionResult Details(int id)
        {
            return View(new CourseBiz().GetCourse(id));
        }

        [ERAuthorizeAttribute()]
        public ActionResult Summary()
        {
            ViewBag.Mode = false;
            ViewBag.Message = "";
            return View(new CourseBiz().GetCourseList());
            //var courseList = new List<CourseModel>();
            //var courseBiz = new CourseBiz();
            //courseList = courseBiz.GetCourseList();
            //return View(courseList);
        }
    }
}
