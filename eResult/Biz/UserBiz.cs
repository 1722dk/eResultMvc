using System;
using System.Collections.Generic;
using IIT.EResult.Models;
using IIT.EResult.Repository;
using IIT.EResult.Security;
using IIT.EResult.Security.Models;

namespace IIT.EResult.Biz
{
    public class UserBiz : IMembershipService
    {
        private readonly IRepository<LoginModel> _userRepository;
        //private readonly IRepository<RegisterModel> _userRepository2;

        // Constructs our UserBiz
        public UserBiz()
        {
            _userRepository = new Repository<LoginModel>();
            //_userRepository2 = new Repository<RegisterModel>();
        }

        public LoginModel SaveOrUpdate(LoginModel user)
        {
            try
            {
                user = _userRepository.SaveOrUpdate(user);
            }
            catch (Exception) { }
            return user;
        }

        //public RegisterModel SaveOrUpdate(RegisterModel user)
        //{
        //    try
        //    {
        //        user = _userRepository2.SaveOrUpdate(user);
        //    }
        //    catch (Exception) { }
        //    return user;
        //}

        public void SaveOrUpdateAll(params LoginModel[] loginModel)
        {
            _userRepository.SaveOrUpdateAll(loginModel);
        }

        public int DeleteUser(LoginModel loginModel)
        {
            return _userRepository.Delete(loginModel);
        }

        public LoginModel GetUser(int userId)
        {
            var user = new LoginModel();
            try
            {
                var queryResult = _userRepository.Get(usr => usr.Id == userId);
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

        public LoginModel GetValidUser(string userName, string password)
        {
            var user = new LoginModel();
            try
            {
                var queryResult = _userRepository.Get(usr => usr.UserName == userName && usr.Password == password);
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

        public List<LoginModel> GetUserList()
        {
            var userList = new List<LoginModel>();
            try
            {
                var queryResult = _userRepository.GetAll();
                foreach (var usr in queryResult)
                {
                    var user = new LoginModel();
                    user.Id = usr.Id;
                    user.UserName = usr.UserName;
                    user.Password = usr.Password;

                    userList.Add(user);
                }
            }
            catch (Exception) { }
            return userList;
        }

        #region IMembershipService methods

        public AuthStatus ValidateUser(string userName, string password)
        {
            var user = new LoginModel();
            user = GetValidUser(userName, password);

            var authStatus = new AuthStatus();
            if (!(String.IsNullOrEmpty(user.UserName)) && !(String.IsNullOrEmpty(user.Password)))
            {
                authStatus.Code = AuthStatusCode.SUCCESS;
                authStatus.Message = "Login successful!";
                authStatus.Data = user;
            }
            else
            {
                authStatus.Code = AuthStatusCode.FAILED;
                authStatus.Message = "The user name or password provided is incorrect.";
            }

            return authStatus;
        }

        public string[] GetRoles(string userName)
        {
            //return user.Roles;
            string[] userRoles = null;// new string[10];
            return userRoles;
        }

        //public static bool IsUserInRole(string roleName)
        //{
        //    return HttpContext.Current.User.IsInRole(roleName);
        //}

        #endregion       
    }
}