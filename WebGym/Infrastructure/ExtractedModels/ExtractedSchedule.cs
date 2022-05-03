﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebGym.Infrastructure.efModels;

namespace Infrastructure.ExtractedModels
{
    public class ExtractedSchedule
    {
        public Guid Id { get; set; }
        public Guid PositionId { get; set; }
        public Guid? CoachId { get; set; }
        public Guid TrainTypeId { get; set; }
        
        public DateTime? StartTime { get; set; }
        public DateTime? FinishTime { get; set; }
        
        public string ScheduleDescription { get; set; }
        public string Description { get; set; }
        public string Day { get; set; }
        public string CoachName { get; set; }

    }
}
