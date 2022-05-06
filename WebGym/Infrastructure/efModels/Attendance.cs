﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Infrastructure.efModels
{
    public partial class Attendance
    {
        public Attendance()
        {
            ServiceData = new HashSet<ServiceData>();
        }

        public Guid Id { get; set; }
        public Guid? CoachId { get; set; }
        public Guid? StatisticsDataId { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? FinishTime { get; set; }
        public int? Pulse { get; set; }
        public int? HeadPressure { get; set; }
        public int? HeartPressure { get; set; }
        public double? WeightData { get; set; }
        public double? CaloriesSpent { get; set; }

        public virtual Coach Coach { get; set; }
        public virtual StatisticsData StatisticsData { get; set; }
        public virtual ICollection<ServiceData> ServiceData { get; set; }
    }
}
