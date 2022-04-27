using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebGym.Domain.ViewModels
{
    public class AttendanceModel
    {
        public Guid Id { get; set; }
        public int ClientId { get; set; }
        public int CoachId { get; set; }
        public int TrainTime { get; set; } 
        public int Pulse { get; set; }
        public float Weight { get; set; }
        public int HeadPressure { get; set; }
        public int HeartPressure { get; set; }
    }
}
