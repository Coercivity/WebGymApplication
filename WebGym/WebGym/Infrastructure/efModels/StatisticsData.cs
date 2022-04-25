using System;
using System.Collections.Generic;

#nullable disable

namespace WebGym
{
    public partial class StatisticsData
    {
        public StatisticsData()
        {
            Attendances = new HashSet<Attendance>();
        }

        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public int VisitsAmount { get; set; }

        public virtual Client Client { get; set; }
        public virtual ICollection<Attendance> Attendances { get; set; }
    }
}
