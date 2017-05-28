using SellsEverything.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellsEverything.Data
{
    public class GenderData
    {
        public List<GenderModel> GetGenders()
        {
            using (SellsEverythingDatabase context = new SellsEverythingDatabase())
            {
                return (from Gender in context.Gender
                        select new GenderModel
                        {
                            ID = Gender.Id,
                            Name = Gender.Name
                        }).ToList();

            }

        }
    }
}
