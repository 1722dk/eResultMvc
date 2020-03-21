using System;
using System.Collections.Generic;
using System.Linq;
using IIT.EResult.Models;
using IIT.EResult.Repository;
using NHibernate;

namespace IIT.EResult.Biz
{
    public class ExamResultBiz
    {
        private readonly IRepository<ExamResultModel> _examResultRepository;

        /// <summary>
        /// Default constructor
        /// </summary>
        public ExamResultBiz()
        {
            _examResultRepository = new Repository<ExamResultModel>();
        }

        /// <summary>
        /// Save of update the entity
        /// </summary>
        /// <param name="examResultModel"></param>
        /// <returns></returns>
        public ExamResultModel SaveOrUpdate(ExamResultModel examResultModel)
        {
            try
            {
                examResultModel = _examResultRepository.SaveOrUpdate(examResultModel);
            }
            catch (Exception)
            {
            }
            return examResultModel;
        }

        /// <summary>
        /// Save of update the bulk entity
        /// </summary>
        /// <param name="examResultModel"></param>
        public void SaveOrUpdateAll(params ExamResultModel[] examResultModel)
        {
            _examResultRepository.SaveOrUpdateAll(examResultModel);
        }

        /// <summary>
        /// Delete the entity
        /// </summary>
        /// <param name="examResultModel"></param>
        /// <returns></returns>
        public int DeleteExamResult(ExamResultModel examResultModel)
        {
            return _examResultRepository.Delete(examResultModel);
        }

        /// <summary>
        /// Retrive entity by Id
        /// </summary>
        /// <param name="examResultId"></param>
        /// <returns></returns>
        public ExamResultModel GetExamResult(int examResultId)
        {
            var examResultModel = new ExamResultModel();
            try
            {
                var queryResult = _examResultRepository.Get(obj => obj.Id == examResultId);
                foreach (var obj in queryResult)
                {
                    examResultModel.Id = obj.Id;
                    examResultModel.CourseId = obj.CourseId;
                    examResultModel.BatchNo = obj.BatchNo;
                    examResultModel.StudentId = obj.StudentId;
                    examResultModel.ExamType = obj.ExamType;
                    examResultModel.Mark = obj.Mark;
                }
            }
            catch (Exception)
            {
            }
            return examResultModel;
        }

        /// <summary>
        /// Retrive list of entity
        /// </summary>
        /// <returns></returns>
        public IList<ExamResultModel> GetExamResultList()
        {
            var examResultModelList = new List<ExamResultModel>();
            try
            {
                var queryResult = _examResultRepository.GetAll();
                examResultModelList.AddRange(queryResult.Select(obj => new ExamResultModel
                    {
                        Id = obj.Id,
                        CourseId = obj.CourseId,
                        BatchNo = obj.BatchNo,
                        StudentId = obj.StudentId,
                        ExamType = obj.ExamType,
                        Mark = obj.Mark
                    }));
            }
            catch (Exception)
            {
            }
            return examResultModelList;
        }

        public IList<ExamResultModel> GetQueryResult(ExamResultModel examResultModel)
        {
            string spName = "exec " + examResultModel.SpName + " ?, ?, ?, ?";
            var spParams = new Dictionary<int, string>()
                {
                    {0, examResultModel.CourseId},
                    {1, examResultModel.BatchNo},
                    {2, examResultModel.ExamType},
                    {3, examResultModel.ExamNo}
                };

            var listItems = _examResultRepository.GetQueryResult(spName, spParams);
            return listItems.Select(item => new ExamResultModel
                {
                    Id = Convert.ToInt32(((object[]) (item))[0].ToString()),
                    StudentId = ((object[]) (item))[1].ToString(),
                    StudentName = ((object[]) (item))[2].ToString(),
                    CourseId = ((object[]) (item))[3].ToString(),
                    BatchNo = ((object[]) (item))[4].ToString(),
                    ExamType = ((object[]) (item))[5].ToString(),
                    ExamNo = ((object[]) (item))[6].ToString(),
                    Mark = Convert.ToDouble(((object[]) (item))[7].ToString())
                }).ToList();
        }

        public IList<ResultModel> GetQueryResultFinal(ExamResultModel examResultModel)
        {
            string spName = "exec " + examResultModel.SpName + " ?, ?";
            var spParams = new Dictionary<int, string>()
                {
                    {0, examResultModel.CourseId},
                    {1, examResultModel.BatchNo},
                    //{2, examResultModel.ExamType},
                    //{3, examResultModel.ExamNo}
                };

            var listItems = _examResultRepository.GetQueryResult(spName, spParams);
            return listItems.Select(item => new ResultModel
            {
                StudentId = ((object[])(item))[0].ToString(),
                StudentName = ((object[])(item))[1].ToString(),
                BatchNo = ((object[])(item))[2].ToString(),
                CourseId = ((object[])(item))[3].ToString(),
                Quiz = ((object[])(item))[4].ToString(),
                Assignment = ((object[])(item))[5].ToString(),
                Presentation = ((object[])(item))[6].ToString(),
                Attendance = ((object[])(item))[7].ToString(),
                MidTerm = ((object[])(item))[8].ToString(),
                Final = ((object[])(item))[9].ToString(),
                Total = ((object[])(item))[10].ToString(),
                GradePoint = ((object[])(item))[11].ToString(),
                GradePointLetter = ((object[])(item))[12].ToString()
            }).ToList();
        }

        public IList<ExamResultModel> GetStudentForResultEntry(ExamResultModel examResultModel)
        {
            string spName = "exec " + examResultModel.SpName + " ?, ?, ?, ?";
            var spParams = new Dictionary<int, string>()
                {
                    {0, examResultModel.CourseId},
                    {1, examResultModel.BatchNo},
                    {2, examResultModel.ExamType},
                    {3, examResultModel.ExamNo}
                };
            var examResultList = _examResultRepository.GetCustomQueryResult(spName, spParams);
            return examResultList;
        }

        //Exception Details: NHibernate.MappingException: Named query not known: GetStudentForResultEntry
        public IList<ExamResultModel> GetNamedQueryResult(ExamResultModel examResultModel)
        {
            string spName = examResultModel.SpName;
            var spParams = new Dictionary<string, string>()
                {
                    {"CourseId", examResultModel.CourseId},
                    {"BatchNo", examResultModel.BatchNo},
                    {"ExamType", examResultModel.ExamType},
                    {"ExamNo", examResultModel.ExamNo}
                };

            var examResultList = _examResultRepository.GetNamedQueryResult(spName, spParams);
            return examResultList;
        }
    }
}