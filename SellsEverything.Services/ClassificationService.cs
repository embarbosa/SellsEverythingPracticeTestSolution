using SellsEverything.Data;
using SellsEverything.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellsEverything.Services
{
    public class ClassificationService
    {
        public List<ClassificationModel> GetClassifications()
        {
            return new ClassificationData().GetClassifications();
        }
    }
}
