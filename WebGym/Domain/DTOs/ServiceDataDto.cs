using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.DTOs
{
    public class ServiceDataDto
    {
        public Guid AbonementId { get; set; }
        public Guid AttendanceId { get; set; }
        public Guid? ServiceDataTypeId { get; set; }


    }
}
