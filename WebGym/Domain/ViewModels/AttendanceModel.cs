using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.ViewModels
{
    public class AttendanceModel
    {
        public Guid? Id { get; set; }
        public Guid? StatisticsId { get; set; }
        public Guid? CoachId { get; set; }

        public Guid? TrainTypeId { get; set; }

        public DateTime? TrainTime { get; set; } 
        public DateTime? StartTime { get; set; } 
        public DateTime? FinishTime { get; set; } 
        public string TrainType { get; set; }
        public int? Pulse { get; set; }
        public double? Weight { get; set; }
        public double? CaloriesSpent { get; set; }
        public int? HeadPressure { get; set; }
        public int? HeartPressure { get; set; }
    }
}
