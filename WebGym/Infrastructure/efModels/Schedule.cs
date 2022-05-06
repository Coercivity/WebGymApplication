using System;
using System.Collections.Generic;

#nullable disable

namespace WebGym.Infrastructure.efModels
{
    public partial class Schedule
    {
        public Schedule()
        {
            Positions = new HashSet<Position>();
        }

        public Guid Id { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Position> Positions { get; set; }
    }
}
