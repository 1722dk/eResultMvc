using System;
using System.Collections.Generic;
using System.Linq;
using IIT.EResult.Models;
using IIT.EResult.Repository;

namespace IIT.EResult.Biz
{
    public class StudentBiz
    {
        private readonly IRepository<StudentModel> _studentRepository;

        /// <summary>
        /// Default constructor
        /// </summary>
        public StudentBiz()
        {
            _studentRepository = new Repository<StudentModel>();
        }

        /// <summary>
        /// Save of update the entity
        /// </summary>
        /// <param name="studentModel"></param>
        /// <returns></returns>
        public StudentModel SaveOrUpdate(StudentModel studentModel)
        {
            try
            {
                studentModel = _studentRepository.SaveOrUpdate(studentModel);
            }
            catch (Exception) { }
            return studentModel;
        }

        /// <summary>
        /// Save of update the bulk entity
        /// </summary>
        /// <param name="studentModel"></param>
        public void SaveOrUpdateAll(params StudentModel[] studentModel)
        {
            _studentRepository.SaveOrUpdateAll(studentModel);
        }

        /// <summary>
        /// Delete the entity
        /// </summary>
        /// <param name="studentModel"></param>
        /// <returns></returns>
        public int DeleteStudent(StudentModel studentModel)
        {
            return _studentRepository.Delete(studentModel);
        }

        /// <summary>
        /// Retrive entity by Id
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        public StudentModel GetStudent(int studentId)
        {
            var studentModel = new StudentModel();
            try
            {
                var queryResult = _studentRepository.Get(obj => obj.Id == studentId);
                foreach (var obj in queryResult)
                {
                    studentModel.Id = obj.Id;
                    studentModel.Name = obj.Name;
                    studentModel.BatchNo = obj.BatchNo;
                    studentModel.Session = obj.Session;
                    studentModel.Email = obj.Email;
                    studentModel.ContactNo = obj.ContactNo;
                }
            }
            catch (Exception) { }
            return studentModel;
        }
        
        /// <summary>
        /// Retrive list of entity
        /// </summary>
        /// <returns></returns>
        public List<StudentModel> GetStudentList()
        {
            var studentModelList = new List<StudentModel>();
            try
            {
                var queryResult = _studentRepository.GetAll();
                studentModelList.AddRange(queryResult.Select(obj => new StudentModel
                    {
                        Id = obj.Id, 
                        Name = obj.Name,
                        BatchNo = obj.BatchNo,
                        Session = obj.Session,
                        Email = obj.Email,
                        ContactNo = obj.ContactNo
                    }));
            }
            catch (Exception) { }
            return studentModelList;
        }
        
        /// <summary>
        /// Check duplicacy of an entity's specific attribute
        /// </summary>
        /// <param name="studentModel"></param>
        /// <returns></returns>
        public StudentModel CheckDuplicate(StudentModel studentModel)
        {
            //var studentModel = new StudentModel();
            try
            {
                var queryResult = _studentRepository.Get(obj => obj.Email == studentModel.Email);
                foreach (var obj in queryResult)
                {
                    studentModel.Id = obj.Id;
                    studentModel.Name = obj.Name;
                    studentModel.BatchNo = obj.BatchNo;
                    studentModel.Session = obj.Session;
                    studentModel.Email = obj.Email;
                    studentModel.ContactNo = obj.ContactNo;
                }
            }
            catch (Exception) { }
            return studentModel;
        }
    }
}