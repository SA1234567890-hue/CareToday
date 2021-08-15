using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace identity.viewModels
{
    public class UserRole
    {
        public string RoleId { set; get; }
        public string RoleName { set; get; }
        public List<RoleViewModel>Roles{ set; get; }
        public string UserId { get; internal set; }
        public string UserName { get; internal set; }
    }
}
