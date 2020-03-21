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
    public class ExamController : Controller
    {
        [HttpGet, ERAuthorizeAttribute()]
        public ActionResult Create()
        {
            ViewBag.Title = "New Exam";
            ViewBag.EditMode = false;
            return View();
        }

        [HttpPost, ERAuthorizeAttribute()]
        public ActionResult Create(ExamModel examModel)//(FormCollection form)
        {
            //var examModel=new ExamModel();
            //TryUpdateModel(examModel, form);
            if (ModelState.IsValid)
            {
                var examBiz = new ExamBiz();
                try
                {
                    var newExam = examBiz.SaveOrUpdate(examModel);
                    if (newExam.Id > 0)
                    {
                        ViewBag.Mode = true;
                        ViewBag.Message = "Data Saved Successfully";
                        return View("Summary", new ExamBiz().GetExamList());
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
            ViewBag.Title = "Edit Exam";
            ViewBag.EditMode = true;
            try
            {
                return View("Create", new ExamBiz().GetExam(id));
            }
            catch (Exception)
            {
            }
            return View("Summary", new ExamBiz().GetExamList());
        }

        [ERAuthorizeAttribute()]
        public ActionResult Delete(int id)
        {
            try
            {
                ViewBag.Mode = true;
                int rslt = new ExamBiz().DeleteExam(new ExamModel() { Id = id });
                ViewBag.Message = rslt > 0 ? "Data Deleted Successfully" : "Delete Failed";
            }
            catch (Exception)
            {
            }
            return View("Summary", new ExamBiz().GetExamList());
        }

        [ERAuthorizeAttribute()]
        public ActionResult Details(int id)
        {
            return View(new ExamBiz().GetExam(id));
        }

        [ERAuthorizeAttribute()]
        public ActionResult Summary()
        {
            ViewBag.Mode = false;
            ViewBag.Message = "";
            return View(new ExamBiz().GetExamList());
            //var examList = new List<ExamModel>();
            //var examBiz = new ExamBiz();
            //examList = examBiz.GetExamList();
            //return View(examList);
        }
    }
}
