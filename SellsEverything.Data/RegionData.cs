using SellsEverything.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellsEverything.Data
{
    public class RegionData
    {
        public List<RegionModel> GetRegions()
        {
            using (SellsEverythingDatabase context = new SellsEverythingDatabase())
            {
                return (from region in context.Region
                        select new RegionModel
                        {
                            ID = region.Id,
                            Name = region.Name
                        }).ToList();

            }

        }
    }
}
