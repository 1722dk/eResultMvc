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
    public class StudentController : Controller
    {
        [HttpGet, ERAuthorizeAttribute()]
        public ActionResult Create()
        {
            ViewBag.Title = "New Student";
            ViewBag.EditMode = false;
            return View();
        }

        [HttpPost, ERAuthorizeAttribute()]
        public ActionResult Create(StudentModel studentModel)//(FormCollection form)
        {
            //var studentModel=new StudentModel();
            //TryUpdateModel(studentModel, form);
            if (ModelState.IsValid)
            {
                var studentBiz = new StudentBiz();
                try
                {
                    var newStudent = studentBiz.SaveOrUpdate(studentModel);
                    if (newStudent.Id > 0)
                    {
                        ViewBag.Mode = true;
                        ViewBag.Message = "Data Saved Successfully";
                        return View("Summary", new StudentBiz().GetStudentList());
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
            ViewBag.Title = "Edit Student";
            ViewBag.EditMode = true;
            try
            {
                return View("Create", new StudentBiz().GetStudent(id));
            }
            catch (Exception)
            {
            }
            return View("Summary", new StudentBiz().GetStudentList());
        }

        [ERAuthorizeAttribute()]
        public ActionResult Delete(int id)
        {
            try
            {
                ViewBag.Mode = true;
                int rslt = new StudentBiz().DeleteStudent(new StudentModel() { Id = id });
                ViewBag.Message = rslt > 0 ? "Data Deleted Successfully" : "Delete Failed";
            }
            catch (Exception)
            {
            }
            return View("Summary", new StudentBiz().GetStudentList());
        }

        [ERAuthorizeAttribute()]
        public ActionResult Details(int id)
        {
            return View(new StudentBiz().GetStudent(id));
        }

        [ERAuthorizeAttribute()]
        public ActionResult Summary()
        {
            ViewBag.Mode = false;
            ViewBag.Message = "";
            return View(new StudentBiz().GetStudentList());
            //var studentList = new List<StudentModel>();
            //var studentBiz = new StudentBiz();
            //studentList = studentBiz.GetStudentList();
            //return View(studentList);
        }
    }
}
