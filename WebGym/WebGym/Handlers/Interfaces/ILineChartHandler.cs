using Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebGym.Handlers.Interfaces
{
    public interface ILineChartHandler
    {
        public string GetLineChart(List<AttendanceModel>  attendanceModels);
    }
}
