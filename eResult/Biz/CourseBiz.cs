using System;
using System.Collections.Generic;
using System.Linq;
using IIT.EResult.Models;
using IIT.EResult.Repository;

namespace IIT.EResult.Biz
{
    public class CourseBiz
    {
        private readonly IRepository<CourseModel> _courseRepository;

        /// <summary>
        /// Default constructor
        /// </summary>
        public CourseBiz()
        {
            _courseRepository = new Repository<CourseModel>();
        }

        /// <summary>
        /// Save of update the entity
        /// </summary>
        /// <param name="courseModel"></param>
        /// <returns></returns>
        public CourseModel SaveOrUpdate(CourseModel courseModel)
        {
            try
            {
                courseModel = _courseRepository.SaveOrUpdate(courseModel);
            }
            catch (Exception) { }
            return courseModel;
        }

        /// <summary>
        /// Save of update the bulk entity
        /// </summary>
        /// <param name="courseModel"></param>
        public void SaveOrUpdateAll(params CourseModel[] courseModel)
        {
            _courseRepository.SaveOrUpdateAll(courseModel);
        }

        /// <summary>
        /// Delete the entity
        /// </summary>
        /// <param name="courseModel"></param>
        /// <returns></returns>
        public int DeleteCourse(CourseModel courseModel)
        {
            return _courseRepository.Delete(courseModel);
        }

        /// <summary>
        /// Retrive entity by Id
        /// </summary>
        /// <param name="courseId"></param>
        /// <returns></returns>
        public CourseModel GetCourse(int courseId)
        {
            var courseModel = new CourseModel();
            try
            {
                var queryResult = _courseRepository.Get(obj => obj.Id == courseId);
                foreach (var obj in queryResult)
                {
                    courseModel.Id = obj.Id;
                    courseModel.CourseId = obj.CourseId;
                    courseModel.CourseTitle = obj.CourseTitle;
                    courseModel.CourseCredit = obj.CourseCredit;
                }
            }
            catch (Exception) { }
            return courseModel;
        }
        
        /// <summary>
        /// Retrive list of entity
        /// </summary>
        /// <returns></returns>
        public List<CourseModel> GetCourseList()
        {
            var courseModelList = new List<CourseModel>();
            try
            {
                var queryResult = _courseRepository.GetAll();
                courseModelList.AddRange(queryResult.Select(obj => new CourseModel
                    {
                        Id = obj.Id, CourseId = obj.CourseId, CourseTitle = obj.CourseTitle, CourseCredit = obj.CourseCredit
                    }));
            }
            catch (Exception) { }
            return courseModelList;
        }
        
        /// <summary>
        /// Check duplicacy of an entity's specific attribute
        /// </summary>
        /// <param name="courseModel"></param>
        /// <returns></returns>
        public CourseModel CheckDuplicate(CourseModel courseModel)
        {
            //var courseModel = new CourseModel();
            try
            {
                var queryResult = _courseRepository.Get(obj => obj.CourseTitle == courseModel.CourseId);
                foreach (var obj in queryResult)
                {
                    courseModel.Id = obj.Id;
                    courseModel.CourseId = obj.CourseId;
                    courseModel.CourseTitle = obj.CourseTitle;
                    courseModel.CourseCredit = obj.CourseCredit;
                }
            }
            catch (Exception) { }
            return courseModel;
        }
    }
}