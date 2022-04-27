using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebGym.Domain.ViewModels
{
    public class StatisticsModel
    {
        public Guid Id { get; set; }
        public int ClientId { get; set; }
        public int MedianPulse { get; set; }
        public int VisitsAmount { get; set; }
        public decimal Weight { get; set; }
        public int MedianHeadPressure { get; set; } 
        public int MedianHeartPressure { get; set; }
        public List<AttendanceModel> Items { get; set; }
    }
}
