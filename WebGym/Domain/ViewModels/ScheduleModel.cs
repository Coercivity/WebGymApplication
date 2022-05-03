using System;
using System.Collections.Generic;
using WebGym.Domain.DTOs;

namespace WebGym.Domain.ViewModels
{
    public class ScheduleModel
    {

        public Guid? Id { get; set; }
        public string Description { get; set; }
        public List<PositionDto> Positions { get; set; }

        public List<string> Days = new List<string>() 
        { "Понедельник", "Вторник", "Среда", "Четверг", "Пятница", "Суббота" };
    }
}
