using System;
using System.Collections.Generic;

#nullable disable

namespace WebGym.Infrastructure.efModels
{
    public partial class DayNamings
    {
        public DayNamings()
        {
            Positions = new HashSet<Position>();
        }

        public int Id { get; set; }
        public string DayData { get; set; }

        public virtual ICollection<Position> Positions { get; set; }
    }
}
