using System;
using System.Collections.Generic;
using System.Linq;
using IIT.EResult.Models;
using IIT.EResult.Repository;

namespace IIT.EResult.Biz
{
    public class TeacherBiz
    {
        private readonly IRepository<TeacherModel> _teacherRepository;

        /// <summary>
        /// Default constructor
        /// </summary>
        public TeacherBiz()
        {
            _teacherRepository = new Repository<TeacherModel>();
        }

        /// <summary>
        /// Save of update the entity
        /// </summary>
        /// <param name="teacherModel"></param>
        /// <returns></returns>
        public TeacherModel SaveOrUpdate(TeacherModel teacherModel)
        {
            try
            {
                teacherModel = _teacherRepository.SaveOrUpdate(teacherModel);
            }
            catch (Exception) { }
            return teacherModel;
        }

        /// <summary>
        /// Save of update the bulk entity
        /// </summary>
        /// <param name="teacherModel"></param>
        public void SaveOrUpdateAll(params TeacherModel[] teacherModel)
        {
            _teacherRepository.SaveOrUpdateAll(teacherModel);
        }

        /// <summary>
        /// Delete the entity
        /// </summary>
        /// <param name="teacherModel"></param>
        /// <returns></returns>
        public int DeleteTeacher(TeacherModel teacherModel)
        {
            return _teacherRepository.Delete(teacherModel);
        }

        /// <summary>
        /// Retrive entity by Id
        /// </summary>
        /// <param name="teacherId"></param>
        /// <returns></returns>
        public TeacherModel GetTeacher(int teacherId)
        {
            var teacherModel = new TeacherModel();
            try
            {
                var queryResult = _teacherRepository.Get(obj => obj.Id == teacherId);
                foreach (var obj in queryResult)
                {
                    teacherModel.Id = obj.Id;
                    teacherModel.Name = obj.Name;
                    teacherModel.Designation = obj.Designation;
                    teacherModel.Email = obj.Email;
                    teacherModel.ContactNo = obj.ContactNo;
                }
            }
            catch (Exception) { }
            return teacherModel;
        }
        
        /// <summary>
        /// Retrive list of entity
        /// </summary>
        /// <returns></returns>
        public List<TeacherModel> GetTeacherList()
        {
            var teacherModelList = new List<TeacherModel>();
            try
            {
                var queryResult = _teacherRepository.GetAll();
                teacherModelList.AddRange(queryResult.Select(obj => new TeacherModel
                    {
                        Id = obj.Id, 
                        Name = obj.Name,
                        Designation = obj.Designation,
                        Email = obj.Email,
                        ContactNo = obj.ContactNo
                    }));
            }
            catch (Exception) { }
            return teacherModelList;
        }
        
        /// <summary>
        /// Check duplicacy of an entity's specific attribute
        /// </summary>
        /// <param name="teacherModel"></param>
        /// <returns></returns>
        public TeacherModel CheckDuplicate(TeacherModel teacherModel)
        {
            //var teacherModel = new TeacherModel();
            try
            {
                var queryResult = _teacherRepository.Get(obj => obj.Email == teacherModel.Email);
                foreach (var obj in queryResult)
                {
                    teacherModel.Id = obj.Id;
                    teacherModel.Name = obj.Name;
                    teacherModel.Designation = obj.Designation;
                    teacherModel.Email = obj.Email;
                    teacherModel.ContactNo = obj.ContactNo;
                }
            }
            catch (Exception) { }
            return teacherModel;
        }
    }
}