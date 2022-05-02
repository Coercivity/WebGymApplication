using System;
using System.Threading.Tasks;
using WebGym.Domain.InterfacesToDb;
using WebGym.Domain.ViewModels;

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
           //var trainTypes = await _scheduleRepository.

            var scheduleModel = new ScheduleModel()
            {
                Id = schedule.Id,
                Description = schedule.Description
            };

            return scheduleModel;
        }

    }
}
