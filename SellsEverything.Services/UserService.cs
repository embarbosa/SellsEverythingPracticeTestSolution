using SellsEverything.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SellsEverything.Data;
using SellsEverything.Helper;

namespace SellsEverything.Services
{
    public class UserService
    {
        public UserModel Authenticate(string email, string password)
        {
            password = CryptoHelper.Decrypt(password);
            return new Data.UserData().Authenticate(email, password);
        }

        public bool ValidateAdminRole(string login)
        {
            return new UserData().ValidateAdminRole(login);
        }

        public UserModel GetUserByLogin(string username)
        {
            return new UserData().GetUserByLogin(username);
        }


        public List<UserModel> GetSellers()
        {
            return new UserData().GetSellers();
        }
    }   
}
