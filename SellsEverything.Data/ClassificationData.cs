using SellsEverything.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellsEverything.Data
{
    public class ClassificationData
    {
        public List<ClassificationModel> GetClassifications()
        {
            using (SellsEverythingDatabase context = new SellsEverythingDatabase())
            {
                return (from classification in context.Classification
                        select new ClassificationModel
                        {
                           ID = classification.Id,
                           Name = classification.Name
                        }).ToList();

            }

        }
    }
}
