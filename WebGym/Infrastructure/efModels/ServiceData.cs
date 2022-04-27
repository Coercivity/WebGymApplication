using System;
using System.Collections.Generic;

#nullable disable

namespace WebGym
{
    public partial class ServiceData
    {
        public Guid AbonementId { get; set; }
        public Guid AttendanceId { get; set; }
        public Guid? ServiceDataTypeId { get; set; }

        public virtual Abonement Abonement { get; set; }
        public virtual Attendance Attendance { get; set; }
        public virtual ServiceDataType ServiceDataType { get; set; }
    }
}
