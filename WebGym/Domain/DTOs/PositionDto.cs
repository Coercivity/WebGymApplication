﻿using System;
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
        public Guid TrainTypeId { get; set; }

        public string ScheduleDescription { get; set; }
        public string Description { get; set; }
        public string Day { get; set; }
        public string CoachName { get; set; }

    }
}
