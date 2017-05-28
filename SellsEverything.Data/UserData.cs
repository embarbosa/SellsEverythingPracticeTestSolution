using SellsEverything.Helper;
using SellsEverything.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellsEverything.Data
{
    public class UserData
    {
        public UserModel Authenticate(string email, string password)
        {
            UserModel userModel = null;
            using (SellsEverythingDatabase context = new SellsEverythingDatabase())
            {                
                var userLogin = (from user in context.UserSys
                                  join role in context.UserRole on user.UserRoleId equals role.Id
                                 where user.Email == email && user.Password == password 
                                  select new
                                  {
                                      user.Login,
                                      user.Id, 
                                      user.Email,
                                      role.IsAdmin
                                  }).FirstOrDefault();

                if (userLogin != null)
                {
                    userModel = new UserModel()
                    {
                        Login = userLogin.Login,
                        Email = userLogin.Email,
                        IsAdmin = userLogin.IsAdmin,
                        ID = userLogin.Id
                    };
                }

            }
            return userModel;
        }

        public UserModel GetUserByLogin(string username)
        {
            using (SellsEverythingDatabase context = new SellsEverythingDatabase())
            {
                var userLogin = (from user in context.UserSys
                                 join role in context.UserRole on user.UserRoleId equals role.Id
                                 where user.Login == username
                                 select new UserModel
                                 {
                                     Login = user.Login,
                                     ID = user.Id,
                                     Email = user.Email,
                                     IsAdmin = role.IsAdmin
                                 }).FirstOrDefault();


                return userLogin;
            }
        }

        public bool ValidateAdminRole(string username)
        {
            var user = GetUserByLogin(username);
            return user != null && user.IsAdmin;
        }

        public List<UserModel> GetSellers()
        {
            using (SellsEverythingDatabase context = new SellsEverythingDatabase())
            {
                return (from user in context.UserSys
                                 join role in context.UserRole on user.UserRoleId equals role.Id
                                 select new UserModel
                                 {
                                     Login = user.Login,
                                     ID = user.Id,
                                     Email = user.Email,
                                     IsAdmin = role.IsAdmin
                                 }).ToList();

               

            }
        }
    }
         
}
