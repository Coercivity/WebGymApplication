﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebGym.Domain.ViewModels
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