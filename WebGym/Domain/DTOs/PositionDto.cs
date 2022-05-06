using System;

#nullable disable

namespace WebGym.Domain.DTOs
{
    public class PositionDto
    {
        public Guid? CoachId { get; set; }
        public string StartTime { get; set; }
        public string FinishTime { get; set; }
        public Guid TrainTypeId { get; set; }
        public string ImageName { get; set; }

        public string TrainType { get; set; }
        public string Day { get; set; }
        public string CoachName { get; set; }

    }
}
