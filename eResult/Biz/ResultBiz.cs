using System;
using System.Collections.Generic;
using System.Linq;
using IIT.EResult.Models;
using IIT.EResult.Repository;

namespace IIT.EResult.Biz
{
    public class ResultBiz
    {
        private readonly IRepository<ResultModel> _resultRepository;

        /// <summary>
        /// Default constructor
        /// </summary>
        public ResultBiz()
        {
            _resultRepository = new Repository<ResultModel>();
        }

        /// <summary>
        /// Save of update the entity
        /// </summary>
        /// <param name="resultModel"></param>
        /// <returns></returns>
        public ResultModel SaveOrUpdate(ResultModel resultModel)
        {
            try
            {
                resultModel = _resultRepository.SaveOrUpdate(resultModel);
            }
            catch (Exception)
            {
            }
            return resultModel;
        }

        /// <summary>
        /// Save of update the bulk entity
        /// </summary>
        /// <param name="resultModel"></param>
        public void SaveOrUpdateAll(params ResultModel[] resultModel)
        {
            _resultRepository.SaveOrUpdateAll(resultModel);
        }

        /// <summary>
        /// Delete the entity
        /// </summary>
        /// <param name="resultModel"></param>
        /// <returns></returns>
        public int DeleteResult(ResultModel resultModel)
        {
            return _resultRepository.Delete(resultModel);
        }

        /// <summary>
        /// Retrive entity by Id
        /// </summary>
        /// <param name="resultId"></param>
        /// <returns></returns>
        public ResultModel GetResult(int resultId)
        {
            var resultModel = new ResultModel();
            try
            {
                var queryResult = _resultRepository.Get(obj => obj.Id == resultId);
                foreach (var obj in queryResult)
                {
                    resultModel.Id = obj.Id;
                    resultModel.CourseId = obj.CourseId;
                    resultModel.BatchNo = obj.BatchNo;
                    resultModel.StudentId = obj.StudentId;
                    resultModel.ExamType = obj.ExamType;
                    resultModel.ExamNo = obj.ExamNo;
                    resultModel.Mark = obj.Mark;
                    resultModel.Quiz = obj.Quiz;
                    resultModel.Assignment = obj.Assignment;
                    resultModel.Presentation = obj.Presentation;
                    resultModel.Attendance = obj.Attendance;
                    resultModel.MidTerm = obj.MidTerm;
                    resultModel.Final = obj.Final;
                    resultModel.Total = obj.Total;
                    resultModel.GradePoint = obj.GradePoint;
                    resultModel.GradePointLetter = obj.GradePointLetter;
                }
            }
            catch (Exception)
            {
            }
            return resultModel;
        }

        /// <summary>
        /// Retrive list of entity
        /// </summary>
        /// <returns></returns>
        public List<ResultModel> GetResultList()
        {
            var resultModelList = new List<ResultModel>();
            try
            {
                var queryResult = _resultRepository.GetAll();
                resultModelList.AddRange(queryResult.Select(obj => new ResultModel
                    {
                        Id = obj.Id,
                        CourseId = obj.CourseId,
                        BatchNo = obj.BatchNo,
                        StudentId = obj.StudentId,
                        ExamType = obj.ExamType,
                        ExamNo = obj.ExamNo,
                        Mark = obj.Mark,
                        Quiz = obj.Quiz,
                        Assignment = obj.Assignment,
                        Presentation = obj.Presentation,
                        Attendance = obj.Attendance,
                        MidTerm = obj.MidTerm,
                        Final = obj.Final,
                        Total = obj.Total,
                        GradePoint = obj.GradePoint,
                        GradePointLetter = obj.GradePointLetter
                    }));
            }
            catch (Exception)
            {
            }
            return resultModelList;
        }
    }
}