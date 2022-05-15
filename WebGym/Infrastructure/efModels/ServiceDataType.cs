using System;
using System.Collections.Generic;

#nullable disable

namespace Infrastructure.efModels
{
    public partial class ServiceDataType
    {
        public ServiceDataType()
        {
            ServiceData = new HashSet<ServiceData>();
        }

        public Guid Id { get; set; }
        public string NameData { get; set; }
        public decimal? Price { get; set; }

        public virtual ICollection<ServiceData> ServiceData { get; set; }
    }
}
