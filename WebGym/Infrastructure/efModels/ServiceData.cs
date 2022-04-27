using System;
using System.Collections.Generic;

#nullable disable

namespace WebGym
{
    public partial class ServiceData
    {
        public int AbonementId { get; set; }
        public int AttendanceId { get; set; }
        public int? ServiceDataTypeId { get; set; }

        public virtual Abonement Abonement { get; set; }
        public virtual Attendance Attendance { get; set; }
        public virtual ServiceDataType ServiceDataType { get; set; }
    }
}
