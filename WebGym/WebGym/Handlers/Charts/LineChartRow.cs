using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebGym.Handlers.Charts
{
    public class LineChartRow
    {
        public int Visits { get; set; }
        public int? HeartPressure { get; set; }
        public int? HeadPressure { get; set; }
        public int? Pulse { get; set; }
        public double? Weight { get; set; }
        
    }
}
