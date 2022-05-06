using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.DTOs
{
    public class ScheduleDto
    {

        public Guid Id { get; set; }
        public string Description { get; set; }

        public Dictionary<string, List<PositionDto>> Positions { get; set; }
    }
}
