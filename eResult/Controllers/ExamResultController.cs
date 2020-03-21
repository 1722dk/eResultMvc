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
    public class ExamResultController : Controller
    {
        [ERAuthorizeAttribute()]
        public ActionResult NewExamResult(string courseId, string batchNo, string examType, string examNo)
        {
            var examResultModel = new ExamResultModel
                {
                    SpName = "GetStudentForResultEntry",
                    CourseId = courseId,
                    BatchNo = batchNo,
                    ExamType = examType,
                    ExamNo = examNo
                };
            var studentList = new ExamResultBiz().GetQueryResult(examResultModel);
            if (Request.IsAjaxRequest())
            {
                ViewBag.Mode = true;
                if (studentList.Count > 0)
                {
                    if (studentList[0].Id > 0)
                    {
                        ViewBag.Title = "Edit Exam Marks";
                        ViewBag.EditMode = true;
                    }
                    else
                    {
                        ViewBag.Title = "Add New Exam Marks";
                        ViewBag.EditMode = false; 
                    }
                }
                return PartialView("_ResultEntryPartial", studentList);
            }
            return View("Summary");
        }

        [ERAuthorizeAttribute()]
        public ActionResult ViewExamResult(string courseId, string batchNo)
        {
            var examResultModel = new ExamResultModel
            {
                SpName = "GetFinalResult",
                CourseId = courseId,
                BatchNo = batchNo
            };
            var studentList = new ExamResultBiz().GetQueryResultFinal(examResultModel);
            if (Request.IsAjaxRequest())
            {
                ViewBag.Mode = true;
                return PartialView("_ResultViewPartial", studentList);
            } 
            return View("Summary");
        }

        [HttpPost, ERAuthorizeAttribute()]
        public ActionResult SubmitExamResult(IList<ExamResultModel> examResultModel)
        {
            var examResult = new ExamResultModel[examResultModel.Count()];
            int i = 0;
            foreach (var resultModel in examResultModel)
            {
                examResult[i] = resultModel;
                i++;
            }

            //if (ModelState.IsValid)
            //{
                var examResultBiz = new ExamResultBiz();
                try
                {
                    ViewBag.Mode = true;
                    examResultBiz.SaveOrUpdateAll(examResult);
                    ViewBag.Message = "Data Saved Successfully";
                    return View("Summary", new ExamResultBiz().GetExamResultList());
                }
                catch (Exception)
                {
                }
            //}
            return View("Summary", examResultModel);
        }

        [ERAuthorizeAttribute()]
        public ActionResult Edit(int id)
        {
            ViewBag.Title = "Edit ExamResult";
            ViewBag.EditMode = true;
            try
            {
                return View("Create", new ExamResultBiz().GetExamResult(id));
            }
            catch (Exception)
            {
            }
            return View("Summary", new ExamResultBiz().GetExamResultList());
        }

        [ERAuthorizeAttribute()]
        public ActionResult Delete(int id)
        {
            try
            {
                int rslt = new ExamResultBiz().DeleteExamResult(new ExamResultModel() { Id = id });
                ViewBag.Message = rslt > 0 ? "Data Deleted Successfully" : "Delete Failed";
            }
            catch (Exception)
            {
            }
            return View("Summary", new ExamResultBiz().GetExamResultList());
        }

        [ERAuthorizeAttribute()]
        public ActionResult Details(int id)
        {
            return View(new ExamResultBiz().GetExamResult(id));
        }

        [ERAuthorizeAttribute()]
        public ActionResult Summary()
        {
            ViewBag.Message = "";
            ViewBag.Mode = false;
            return View(new ExamResultBiz().GetExamResultList());
            //var examResultList = new List<ExamResultModel>();
            //var examResultBiz = new ExamResultBiz();
            //examResultList = examResultBiz.GetExamResultList();
            //return View(examResultList);
        }
    }
}
