using System;
using System.Collections.Generic;

#nullable disable

namespace WebGym
{
    public partial class ServiceDataType
    {
        public ServiceDataType()
        {
            ServiceData = new HashSet<ServiceData>();
        }

        public int Id { get; set; }
        public string NameData { get; set; }
        public decimal? Price { get; set; }

        public virtual ICollection<ServiceData> ServiceData { get; set; }
    }
}
