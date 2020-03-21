using System;
using System.Collections.Generic;
using System.Linq;
using IIT.EResult.Models;
using IIT.EResult.Repository;

namespace IIT.EResult.Biz
{
    public class ExamBiz
    {
        private readonly IRepository<ExamModel> _examRepository;

        /// <summary>
        /// Default constructor
        /// </summary>
        public ExamBiz()
        {
            _examRepository = new Repository<ExamModel>();
        }

        /// <summary>
        /// Save of update the entity
        /// </summary>
        /// <param name="examModel"></param>
        /// <returns></returns>
        public ExamModel SaveOrUpdate(ExamModel examModel)
        {
            try
            {
                examModel = _examRepository.SaveOrUpdate(examModel);
            }
            catch (Exception) { }
            return examModel;
        }

        /// <summary>
        /// Save of update the bulk entity
        /// </summary>
        /// <param name="examModel"></param>
        public void SaveOrUpdateAll(params ExamModel[] examModel)
        {
            _examRepository.SaveOrUpdateAll(examModel);
        }

        /// <summary>
        /// Delete the entity
        /// </summary>
        /// <param name="examModel"></param>
        /// <returns></returns>
        public int DeleteExam(ExamModel examModel)
        {
            return _examRepository.Delete(examModel);
        }

        /// <summary>
        /// Retrive entity by Id
        /// </summary>
        /// <param name="examId"></param>
        /// <returns></returns>
        public ExamModel GetExam(int examId)
        {
            var examModel = new ExamModel();
            try
            {
                var queryResult = _examRepository.Get(obj => obj.Id == examId);
                foreach (var obj in queryResult)
                {
                    examModel.Id = obj.Id;
                    examModel.BatchNo = obj.BatchNo;
                    examModel.CourseId = obj.CourseId;
                    examModel.ExamType = obj.ExamType;
                    examModel.ExamNo = obj.ExamNo;
                    examModel.ExamMarks = obj.ExamMarks;
                }
            }
            catch (Exception) { }
            return examModel;
        }

        /// <summary>
        /// Retrive list of entity
        /// </summary>
        /// <returns></returns>
        public List<ExamModel> GetExamList()
        {
            var examModelList = new List<ExamModel>();
            try
            {
                var queryResult = _examRepository.GetAll();
                examModelList.AddRange(queryResult.Select(obj => new ExamModel
                    {
                        Id = obj.Id,
                        BatchNo = obj.BatchNo,
                        CourseId = obj.CourseId,
                        ExamType = obj.ExamType,
                        ExamNo = obj.ExamNo,
                        ExamMarks = obj.ExamMarks
                    }));
            }
            catch (Exception){}
            return examModelList;
        }
    }
}