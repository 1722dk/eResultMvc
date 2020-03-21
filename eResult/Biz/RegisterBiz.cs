using System;
using System.Collections.Generic;
using IIT.EResult.Models;
using IIT.EResult.Repository;

namespace IIT.EResult.Biz
{
    public class RegisterBiz
    {
        private readonly IRepository<RegisterModel> _registerRepository;

        // Constructs our UserBiz
        public RegisterBiz()
        {
            _registerRepository = new Repository<RegisterModel>();
        }

        public RegisterModel SaveOrUpdate(RegisterModel user)
        {
            try
            {
                user = _registerRepository.SaveOrUpdate(user);
            }
            catch (Exception) { }
            return user;
        }
        public void SaveOrUpdateAll(params RegisterModel[] registerModel)
        {
            _registerRepository.SaveOrUpdateAll(registerModel);
        }
        public int DeleteUser(RegisterModel registerModel)
        {
            return _registerRepository.Delete(registerModel);
        }
        public RegisterModel GetUser(int userId)
        {
            var user = new RegisterModel();
            try
            {
                var queryResult = _registerRepository.Get(usr => usr.Id == userId);
                foreach (var usr in queryResult)
                {
                    user.Id = usr.Id;
                    user.UserName = usr.UserName;
                    user.Password = usr.Password;
                }
            }
            catch (Exception) { }
            return user;
        }

        public RegisterModel CheckDuplicateUser(RegisterModel registerModel)
        {
            var user = new RegisterModel();
            try
            {
                var queryResult = _registerRepository.Get(usr => usr.UserName == registerModel.UserName);
                foreach (var usr in queryResult)
                {
                    user.Id =usr.Id;
                    user.UserName = usr.UserName;
                    user.Password = usr.Password;
                }
            }
            catch (Exception) { }
            return user;
        }
        public List<RegisterModel> GetUserList()
        {
            var userList = new List<RegisterModel>();
            try
            {
                var queryResult = _registerRepository.GetAll();
                foreach (var usr in queryResult)
                {
                    var user = new RegisterModel();
                    user.Id = usr.Id;
                    user.UserName = usr.UserName;
                    user.Password = usr.Password;

                    userList.Add(user);
                }
            }
            catch (Exception) { }
            return userList;
        }
    }
}