using FisketorvetWebAppProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FisketorvetWebAppProject.Interfaces
{
    public interface IUserAccountRepository
    {
        public List<UserAccount> AllUsers();
        void AddUser(UserAccount user);
        void DeleteUser(UserAccount user);
        void UpdateUser(UserAccount user);        
        public UserAccount GetUserWithID(int id);
        public UserAccount GetUserWithLogin(string login);
        public bool UserCheck(string login, string password);
        public int GetLastUserID();

    }
}
