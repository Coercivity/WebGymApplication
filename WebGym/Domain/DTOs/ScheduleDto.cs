﻿using System;
using System.Collections.Generic;

#nullable disable

namespace WebGym.Domain.DTOs
{
    public class ScheduleDto
    {

        public Guid Id { get; set; }
        public string Description { get; set; }

        public List<PositionDto> Positions { get; set; }
    }
}
