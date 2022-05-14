using System;

#nullable disable

namespace Domain.DTOs
{
    public class PositionDto
    {
        public Guid Id { get; set; }
        public Guid? CoachId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime FinishTime { get; set; }
        public Guid TrainTypeId { get; set; }
        public string ImageName { get; set; }
        public string TrainType { get; set; }
        public string Day { get; set; }
        public string CoachName { get; set; }

    }
}
