using System;
using System.Collections.Generic;

#nullable disable

namespace identity.Models
{
    public partial class BloodBank
    {
        public int BloodId { get; set; }
        public string BloodType { get; set; }
        public int? BloodCost { get; set; }
        public string BloodPhone { get; set; }
        public string BloodLocation { get; set; }
        public string BloodDescription { get; set; }
        public int? CityId { get; set; }

        public virtual City City { get; set; }
    }
}
