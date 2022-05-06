using Domain.DTOs;
using System;
using System.Collections.Generic;

namespace Domain.ViewModels
{
    public class ScheduleModel
    {

        public Guid? Id { get; set; }
        public string Description { get; set; }
        public Dictionary<string , List<PositionDto>> Positions { get; set; }

    }
}
