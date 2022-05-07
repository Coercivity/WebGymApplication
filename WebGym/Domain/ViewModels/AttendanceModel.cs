using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.ViewModels
{
    public class AttendanceModel
    {
        public Guid? Id { get; set; }
        public Guid? StatisticsId { get; set; }
        public Guid? CoachId { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? TrainTime { get; set; } 
        public string TrainType { get; set; }
        public int? Pulse { get; set; }
        public double? Weight { get; set; }
        public int? HeadPressure { get; set; }
        public int? HeartPressure { get; set; }
    }
}
