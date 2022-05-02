using System;
using System.Collections.Generic;

#nullable disable

namespace WebGym.Domain.DTOs
{
    public class PositionDto
    {
        public Guid? CoachId { get; set; }
        public Guid ScheduleId { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? FinishTime { get; set; }
        public int? DayNamingsId { get; set; }
        public Guid TrainTypeId { get; set; }

    }
}
