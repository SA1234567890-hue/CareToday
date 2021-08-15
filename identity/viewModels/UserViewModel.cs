using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace identity.viewModels
{
    public class UserViewModel
    {
        public string Id { set; get; }
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public string UserName { set; get; }
        public string Email { set; get; }
        public IEnumerable<string> Roles { set; get; }





    }
}
