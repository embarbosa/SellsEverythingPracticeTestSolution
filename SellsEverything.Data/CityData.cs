using SellsEverything.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellsEverything.Data
{
    public class CityData
    {
        public List<CityModel> GetCities()
        {
            using(SellsEverythingDatabase context = new SellsEverythingDatabase())
            {
                return (from city in context.City
                        select new CityModel
                        {
                            ID = city.Id,
                            Name = city.Name,
                            RegionID = city.RegionId
                        }).ToList();
                       
            }
        }
    }
}
