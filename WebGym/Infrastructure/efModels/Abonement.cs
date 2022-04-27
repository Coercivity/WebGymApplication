using System;
using System.Collections.Generic;

#nullable disable

namespace WebGym
{
    public partial class Abonement
    {
        public Abonement()
        {
            ServiceData = new HashSet<ServiceData>();
        }

        public Guid Id { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? FinishDate { get; set; }
        public int? VisitsAmount { get; set; }
        public Guid? ClientId { get; set; }
        public bool? IsValid { get; set; }

        public virtual Client Client { get; set; }
        public virtual ICollection<ServiceData> ServiceData { get; set; }
    }
}
