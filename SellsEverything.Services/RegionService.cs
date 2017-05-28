using SellsEverything.Data;
using SellsEverything.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellsEverything.Services
{
    public class RegionService
    {
        public List<RegionModel> GetRegions()
        {
            return new RegionData().GetRegions();
        }
    }
}
