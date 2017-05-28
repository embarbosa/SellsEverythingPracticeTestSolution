using SellsEverything.Helper;
using SellsEverything.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SellsEverything.Web.Controllers
{
    public class LoginController : Controller
    {
        UserService _userService;

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult ValidateLogin(Models.LoginViewModel data)
        {
            if (!ModelState.IsValid)
            {
                return View(data);
            }

            _userService = new UserService();
            string password = CryptoHelper.Encrypt(data.Password);
            var loggedUser = _userService.Authenticate(data.Email, password);

            if (loggedUser != null)
            {
                FormsAuthentication.SetAuthCookie(loggedUser.Login, false);
                FormsAuthenticationTicket ticket1 =
           new FormsAuthenticationTicket(
                1,                                   // version
                loggedUser.Login,   // get username  from the form
                DateTime.Now,                        // issue time is now
                DateTime.Now.AddMinutes(10),         // expires in 10 minutes
                false,      // cookie is not persistent
                loggedUser.IsAdmin ? "Administrator" : "User"  // role assignment is stored
                                                  // in userData
                );
                HttpCookie cookie1 = new HttpCookie(
                  FormsAuthentication.FormsCookieName,
                  FormsAuthentication.Encrypt(ticket1));
                Response.Cookies.Add(cookie1);

                
                return RedirectToAction("Index", "Customer");
            }
            else
            {
                ModelState.AddModelError("", "The e-mail and/or password entered is invalid. Please try again.");
                return View("Index", data);
            }
        }
    }
}