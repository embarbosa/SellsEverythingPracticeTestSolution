using SellsEverything.Data;
using SellsEverything.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellsEverything.Services
{
    public class CustomerService
    {
        public List<CustomerModel> GetCustomers()
        {
            return new CustomerData().GetCustomers();
        }


        public List<CustomerModel> GetCustomers(string name, int? genderID,
            int? cityId, int? regionId, int? classificationID, int? sellerID,
            DateTime? lastPurchaseFrom, DateTime? lastPurchaseTo)
        {
            return new CustomerData().GetCustomers(name, genderID, cityId, regionId, classificationID,
                sellerID, lastPurchaseFrom, lastPurchaseTo);
        }
    }
}
