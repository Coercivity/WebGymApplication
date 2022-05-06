﻿using Domain.InterfacesToDb;
using Domain.ViewModels;
using System;
using System.Threading.Tasks;


namespace Domain.Services
{
    public class ScheduleService
    {
        private readonly IScheduleRepository _scheduleRepository;

        public ScheduleService(IScheduleRepository scheduleRepository)
        {
            _scheduleRepository = scheduleRepository;
        }


        public async Task<ScheduleModel> GetCurrentSchedule(Guid id)
        {
           var schedule = await _scheduleRepository.GetSchedule(id);
           

            var scheduleModel = new ScheduleModel()
            {
                Description = schedule.Description,
                Positions = schedule.Positions
            };

            return scheduleModel;
        }

    }
}
