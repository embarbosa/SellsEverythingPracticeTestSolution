using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellsEverything.Model
{
    public class CustomerModel
    {
        public int? CityID { get; set; }
        public string CityName { get; set; }
        public int? ClassificationID { get; set; }
        public string ClassificationName { get; set; }
        public string Gender { get; set; }
        public int GenderID { get; set; }
        public int ID { get; set; }
        public DateTime? LastPurchase { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public int? RegionID { get; set; }
        public string RegionName { get; set; }
        public string Seller { get; set; }
    }
}
