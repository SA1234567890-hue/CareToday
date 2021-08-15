using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;

#nullable disable

namespace identity.Models
{
   
    public partial class OxygenTube
    {
        public int OxgnId { get; set; }

        public string OxgnType { get; set; }
        public int? OxgnAmount { get; set; }
        public int? OxgnCost { get; set; }
        public string OxgnPhone { get; set; }
        public string OxgnLocation { get; set; }
        public string OxgnDescription { get; set; }
        public int? CityId { get; set; }

        public virtual City City { get; set; }
    }
}
