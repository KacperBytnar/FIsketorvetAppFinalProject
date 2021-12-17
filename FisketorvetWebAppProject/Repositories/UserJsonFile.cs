using FisketorvetWebAppProject.Helpers;
using FisketorvetWebAppProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FisketorvetWebAppProject.Interfaces;
using System.Data;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace FisketorvetWebAppProject.Repositories
{
    public class UserJsonFile : IUserAccountRepository
    {
        public IWebHostEnvironment WebHostEnvironment { get; }
        private string jsonFilePath
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "Data", "UserAccounts.json"); }
        }

        public List<UserAccount> users;

        public UserJsonFile(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
            users = JsonFileReader.ReadUserAccounts(jsonFilePath);
        }


        public UserAccount GetUserWithID(int id)
        {
            foreach (var user in users)
            {
                if (user.Id == id)
                    return user;
            }
            return new UserAccount();
        }

        public UserAccount GetUserWithLogin(string login)
        {
            foreach (var user in users)
            {
                if (user.Login == login)
                    return user;
            }
            return new UserAccount();
        }

        List<UserAccount> IUserAccountRepository.AllUsers()
        {
            return users;
        }

        public void AddUser(UserAccount user)
        {
            users.Add(user);
            JsonFileWriter.WriteToUserAccounts(users, jsonFilePath);
        }

        public void DeleteUser(UserAccount user)
        {
            foreach (var userr in users)
            {
                if (userr.Login == user.Login)
                {
                    users.Remove(user);
                }
            }
        }

        public bool UserCheck(string login, string password)
        {
            foreach(UserAccount user in users)
            {
                if((user.Login==login)&&(user.Password == password))
                {
                    return true;
                }
            }
            return false;
        }

        public void UpdateUser(UserAccount user)
        {
            DeleteUser(user);
            AddUser(user);
        }
        
        public int GetLastUserID()
        {
            return users.Last().Id;
        }
    }
}
