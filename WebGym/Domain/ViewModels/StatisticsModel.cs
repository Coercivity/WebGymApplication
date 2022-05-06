using System.Collections.Generic;


namespace Domain.ViewModels
{
    public class StatisticsModel
    {
        public int? MedianPulse { get; set; }
        public int? VisitsAmount { get; set; }
        public double? Weight { get; set; }
        public int? MedianHeadPressure { get; set; } 
        public int? MedianHeartPressure { get; set; }
        public List<AttendanceModel> ClientAttendances { get; set; }
    }
}
