using System;
using System.Collections.Generic;

#nullable disable

namespace identity.Models
{
    public partial class Nursery
    {
        public int NurId { get; set; }
        public int? NurCost { get; set; }
        public string NurPhone { get; set; }
        public string NurLocation { get; set; }
        public string NurDescription { get; set; }
        public bool? Status { get; set; }
        public int? CityId { get; set; }

        public virtual City City { get; set; }
    }
}
