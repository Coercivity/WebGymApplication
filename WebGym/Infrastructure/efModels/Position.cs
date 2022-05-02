using System;
using System.Collections.Generic;

#nullable disable

namespace WebGym.Infrastructure.efModels
{
    public partial class Position
    {
        public Guid? CoachId { get; set; }
        public Guid ScheduleId { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? FinishTime { get; set; }
        public int? DayNamingsId { get; set; }
        public Guid TrainTypeId { get; set; }

        public virtual Coach Coach { get; set; }
        public virtual DayNaming DayNamings { get; set; }
        public virtual Schedule Schedule { get; set; }
        public virtual TrainType TrainType { get; set; }
    }
}
