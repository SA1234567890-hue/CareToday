using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace identity.Models
{
    public class User: IdentityUser

    {
        [Required, MaxLength(14)]
        [unique]
        public string Id_National { set; get; }


        [Required, MaxLength(11)]
        public int Phone { set; get; }
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public string Password { set; get; }
        public string Confirm_Password { set; get; }
      
      
      


        //public static implicit operator User(User v) => throw new NotImplementedException();
    }
}
