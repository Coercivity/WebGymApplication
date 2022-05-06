using System;
using System.Collections.Generic;

#nullable disable

namespace WebGym.Infrastructure.efModels
{
    public partial class TrainType
    {
        public TrainType()
        {
            Positions = new HashSet<Position>();
        }

        public Guid Id { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }

        public virtual ICollection<Position> Positions { get; set; }
    }
}
