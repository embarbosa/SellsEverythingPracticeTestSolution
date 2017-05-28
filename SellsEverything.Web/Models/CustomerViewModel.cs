using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SellsEverything.Web.Models
{
    public class CustomerViewModel
    {

        public CustomerViewModel()
        {
            this.parameters = new SearchParameters();
            this.customers = new List<CustomerViewModel>();
        }

        public SearchParameters parameters { get; set; }
        public IEnumerable<CustomerViewModel> customers { get; set; }

        public int Id { get; set; }
        public string Classification { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public DateTime LastPurchase { get; set; }
        public string Seller { get; set; }

        public class SearchParameters
        {
            [DisplayName("Name")]
            public string Name { get; set; }

            [DisplayName("Gender")]
            public int? SelectedGenderID { get; set; }

            [DisplayName("City")]
            public int? SelectedCityID { get; set; }

            [DisplayName("Region")]
            public int? SelectedRegionID { get; set; }

            [DataType(DataType.Date)]
            [DisplayName("Last purchase")]
            public DateTime LastPurchaseFrom { get; set; }

            [DataType(DataType.Date)]
            public DateTime LastPurchaseTo { get; set; }

            [DisplayName("Classification")]
            public int? SelectedClassificationID { get; set; }

            [DisplayName("Seller")]
            public int? SelectedSellerID { get; set; }

            public List<CityViewModel> Cities { get; set; }
            public List<RegionViewModel> Regions { get; set; }
            public List<SellerViewModel> Sellers { get; set; }
            public List<ClassificationViewModel> Classifications { get; set; }
            public List<GenderViewModel> Genders { get; set; }


            public bool IsAdmin { get; set; }
        }
    }
}