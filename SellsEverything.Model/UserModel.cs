using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellsEverything.Model
{
    public class UserModel
    {
        public int ID { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public bool IsAdmin { get; set; }
    }
}
