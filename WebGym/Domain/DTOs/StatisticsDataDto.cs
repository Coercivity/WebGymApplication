using System;
using System.Collections.Generic;

#nullable disable

namespace WebGym
{
    public class StatisticsDataDto
    {
        

        public Guid Id { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? FinishDate { get; set; }
        public int? MedianPulse { get; set; }
        public int? MedianHeadPressure { get; set; }
        public int? MedianHeartPressure { get; set; }
        public double? WeightData { get; set; }
        public int? VisitsAmount { get; set; }

    }
}
