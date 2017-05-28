using SellsEverything.Data;
using SellsEverything.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellsEverything.Services
{
    public class CityService
    {
        public List<CityModel> GetCities()
        {
            return new CityData().GetCities();
        }
    }
}
