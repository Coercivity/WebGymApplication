using System;
using System.Collections.Generic;

#nullable disable

namespace WebGym
{
    public class AttendanceDto
    {

        public Guid Id { get; set; }
        public Guid? CoachId { get; set; }
        public Guid? StatisticsDataId { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? FinishTime { get; set; }
        public int? Pulse { get; set; }
        public int? HeadPressure { get; set; }
        public int? HeartPressure { get; set; }
        public double? WeightData { get; set; }

    }
}
