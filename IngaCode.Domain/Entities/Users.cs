using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IngaCode.Domain.Entities
{
    public class Users : BaseEntity
    {
        public Users()
        {

        }
        public Users(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }

        public string UserName { get; set; }
        public string Password { get; set; }

        public void Update(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }
    }
}
