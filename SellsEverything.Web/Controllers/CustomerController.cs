using SellsEverything.Model;
using SellsEverything.Services;
using SellsEverything.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SellsEverything.Web.Controllers
{
    public class CustomerController : Controller
    {
        CityService _cityService;
        ClassificationService _classificationService;
        CustomerService _customerService;
        RegionService _regionService;
        UserService _userService;
        GenderService _genderService;
        private string GetCurrentUserNameLogin()
        {
            return HttpContext.User.Identity.Name;
        }

        [AuthorizeAttribute]
        public ActionResult Index()
        {
            _userService = new UserService();
            CustomerViewModel model = new CustomerViewModel();
            model.parameters.IsAdmin = _userService.ValidateAdminRole(GetCurrentUserNameLogin());
            FillFilters(model);
            DoSearch(model, true);

            return View(model);
        }
        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            _userService = new UserService();
            bool currentUserIsAdmin = _userService.ValidateAdminRole(GetCurrentUserNameLogin());
            int currentUserId = _userService.GetUserByLogin(GetCurrentUserNameLogin()).ID;
            CustomerViewModel model = new CustomerViewModel();

            model.parameters.Name = !string.IsNullOrEmpty(form["parameters.Name"].ToString()) ? form["parameters.Name"].ToString() : string.Empty;


            if (!string.IsNullOrEmpty(form["SelectedGenderID"].ToString()))
            {
                model.parameters.SelectedGenderID = int.Parse(form["SelectedGenderID"]);
            }

            if (!string.IsNullOrEmpty(form["SelectedCityID"].ToString()))
            {
                model.parameters.SelectedCityID = int.Parse(form["SelectedCityID"]);
            }

            if (!string.IsNullOrEmpty(form["SelectedRegionID"].ToString()))
            {
                model.parameters.SelectedRegionID = int.Parse(form["SelectedRegionID"]);
            }

            if (!string.IsNullOrEmpty(form["SelectedClassificationID"].ToString()))
            {
                model.parameters.SelectedClassificationID = int.Parse(form["SelectedClassificationID"]);
            }

            if (!string.IsNullOrEmpty(form["parameters.LastPurchaseFrom"].ToString()))
            {
                model.parameters.LastPurchaseFrom = Convert.ToDateTime(form["parameters.LastPurchaseFrom"].ToString());
            }

            if (!string.IsNullOrEmpty(form["parameters.LastPurchaseTo"].ToString()))
            {
                model.parameters.LastPurchaseTo = Convert.ToDateTime(form["parameters.LastPurchaseTo"].ToString());
            }          
            

            model.parameters.IsAdmin = currentUserIsAdmin;

            if (!model.parameters.IsAdmin)
            {
                model.parameters.SelectedSellerID = currentUserId;
            }

            if (!model.parameters.IsAdmin)
            {
                model.parameters.SelectedSellerID = currentUserId;
            }
            else if (!string.IsNullOrEmpty(form["SelectedSellerID"].ToString()))
            {
                model.parameters.SelectedSellerID = int.Parse(form["SelectedSellerID"]);
            }

            FillFilters(model);
            DoSearch(model, false);
            return View(model);
        }

        private void FillFilters(CustomerViewModel model)
        {
            _cityService = new CityService();
            _classificationService = new ClassificationService();
            _regionService = new RegionService();
            _userService = new UserService();
            _genderService = new GenderService();
             
            List<CityModel> cities = _cityService.GetCities();
            List<ClassificationModel> classifications = _classificationService.GetClassifications();
            List<RegionModel> regions = _regionService.GetRegions();
            List<UserModel> sellers = _userService.GetSellers();
            List<GenderModel> genders = _genderService.GetGenders();

            model.parameters.Cities = cities.Select(c => new CityViewModel()
            {
                CityId = c.ID,
                Name = c.Name
            }).ToList();

            model.parameters.Classifications = classifications.Select(classification => new ClassificationViewModel()
            {
                ClassificationId = classification.ID,
                Name = classification.Name
            }).ToList();

            model.parameters.Regions = regions.Select(region => new RegionViewModel()
            {
                RegionId = region.ID,
                Name = region.Name
            }).ToList();

            model.parameters.Sellers = sellers.Select(seller => new SellerViewModel()
            {
                UserId = seller.ID,
                Name = seller.Login
            }).ToList();

            model.parameters.Genders = genders.Select(gender => new GenderViewModel()
            {
                GenderId = gender.ID,
                Name = gender.Name
            }).ToList();
        }

        private void DoSearch(CustomerViewModel model, bool getAll)
        {
            _customerService = new CustomerService();
            List<CustomerModel> customers = new List<CustomerModel>();
            if (getAll)
            {
                var user = _userService.GetUserByLogin(GetCurrentUserNameLogin());

                int? sellerId = null;
                if (user != null)
                {
                    sellerId = user.ID;
                }

                if (!model.parameters.IsAdmin)
                {
                    model.parameters.SelectedSellerID = sellerId;
                    customers = _customerService.GetCustomers(null, null, null, null, null, model.parameters.SelectedSellerID, null, null);
                }
                else
                {
                    customers = _customerService.GetCustomers();
                }
            }
            else
            {
                customers = _customerService.GetCustomers(
                    model.parameters.Name,
                    model.parameters.SelectedGenderID,
                    model.parameters.SelectedCityID,
                    model.parameters.SelectedRegionID,
                    model.parameters.SelectedClassificationID,
                    model.parameters.SelectedSellerID,
                    model.parameters.LastPurchaseFrom == DateTime.MinValue ? null : (DateTime?)model.parameters.LastPurchaseFrom,
                    model.parameters.LastPurchaseTo == DateTime.MinValue ? null : (DateTime?)model.parameters.LastPurchaseTo);
            }

            model.customers = customers.Select(s => new CustomerViewModel()
            {
                Name = s.Name,
                Phone = s.Phone,
                Gender = s.Gender,
                LastPurchase = s.LastPurchase.Value,
                Seller = s.Seller,
                Region = s.RegionName,
                Classification = s.ClassificationName,
                City = s.CityName
            }).ToList();
        }

        [Authorize]
        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Login");
        }
    }
}