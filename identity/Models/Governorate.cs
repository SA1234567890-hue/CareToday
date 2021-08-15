using System;
using System.Collections.Generic;

#nullable disable

namespace identity.Models
{
    public partial class Governorate
    {
        public Governorate()
        {
            Cities = new HashSet<City>();
        }

        public int GovId { get; set; }
        public string GovName { get; set; }

        public virtual ICollection<City> Cities { get; set; }
    }
}
