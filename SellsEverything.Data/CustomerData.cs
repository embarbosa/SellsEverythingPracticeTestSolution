using SellsEverything.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellsEverything.Data
{
    public class CustomerData
    {
        public List<CustomerModel> GetCustomers()
        {
            using (SellsEverythingDatabase context = new SellsEverythingDatabase())
            {
                return (from customer in context.Customer
                        join user in context.UserSys on customer.UserId equals user.Id into Sellers
                        from user in Sellers.DefaultIfEmpty()
                        join region in context.Region on customer.RegionId equals region.Id into Regions
                        from region in Regions.DefaultIfEmpty()
                        join city in context.City on customer.CityId equals city.Id into Cities
                        from city in Cities.DefaultIfEmpty()
                        join classification in context.Classification on customer.ClassificationId equals classification.Id into Classifications
                        from classification in Classifications.DefaultIfEmpty()
                        join gender in context.Gender on customer.GenderId equals gender.Id
                        select new CustomerModel
                        {
                            ID = customer.Id,
                            Name = customer.Name,
                            RegionID = customer.RegionId,
                            LastPurchase = customer.LastPurchase,
                            RegionName = region.Name,
                            Phone = customer.Phone,
                            CityID = customer.CityId,
                            CityName = city.Name,
                            ClassificationID = customer.ClassificationId,
                            ClassificationName = classification.Name,
                            GenderID = customer.GenderId,
                            Gender = gender.Name,
                            Seller = user.Login
                        }).ToList();

            }
        }

        public List<CustomerModel> GetCustomers(string name, int? genderId, int? cityId, int? regionId,
            int? classificationID, int? sellerID, DateTime? lastPurchaseFrom, DateTime? lastPurchaseTo)
        {
            using (SellsEverythingDatabase context = new SellsEverythingDatabase())
            {
                return (from customer in context.Customer
                        join user in context.UserSys on customer.UserId equals user.Id into Sellers
                        from user in Sellers.DefaultIfEmpty()
                        join region in context.Region on customer.RegionId equals region.Id into Regions
                        from region in Regions.DefaultIfEmpty()
                        join city in context.City on customer.CityId equals city.Id into Cities
                        from city in Cities.DefaultIfEmpty()
                        join classification in context.Classification on customer.ClassificationId equals classification.Id into Classifications
                        from classification in Classifications.DefaultIfEmpty()
                        join gender in context.Gender on customer.GenderId equals gender.Id
                        where
                            (String.IsNullOrEmpty(name) || customer.Name.Contains(name)) &&
                            (!genderId.HasValue || gender.Id == genderId) &&
                            (!cityId.HasValue || city.Id == cityId) &&
                            (!regionId.HasValue || region.Id == regionId) &&
                            (!classificationID.HasValue || classification.Id == classificationID) &&
                            (!sellerID.HasValue || user.Id == sellerID) &&
                            (!lastPurchaseFrom.HasValue  || customer.LastPurchase >= lastPurchaseFrom.Value) &&
                            (!lastPurchaseTo.HasValue || customer.LastPurchase <= lastPurchaseTo.Value)
                        select new CustomerModel
                        {
                            ID = customer.Id,
                            Name = customer.Name,
                            RegionID = customer.RegionId,
                            LastPurchase = customer.LastPurchase,
                            RegionName = region.Name,
                            Phone = customer.Phone,
                            CityID = customer.CityId,
                            CityName = city.Name,
                            ClassificationID = customer.ClassificationId,
                            ClassificationName = classification.Name,
                            GenderID = customer.GenderId,
                            Gender = gender.Name,
                            Seller = user.Login
                        }).ToList();
            }
        }
    }
}
