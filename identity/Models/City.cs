using System;
using System.Collections.Generic;

#nullable disable

namespace identity.Models
{
    public partial class City
    {
        public City()
        {
            BloodBanks = new HashSet<BloodBank>();
            Nurseries = new HashSet<Nursery>();
            OxygenTubes = new HashSet<OxygenTube>();
        }

        public int CityId { get; set; }
        public string CityName { get; set; }
        public int? GovId { get; set; }

        public virtual Governorate Gov { get; set; }
        public virtual ICollection<BloodBank> BloodBanks { get; set; }
        public virtual ICollection<Nursery> Nurseries { get; set; }
        public virtual ICollection<OxygenTube> OxygenTubes { get; set; }
    }
}
