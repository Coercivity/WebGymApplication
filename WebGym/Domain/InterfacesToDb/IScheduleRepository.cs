using Domain.DTOs;
using System;
using System.Threading.Tasks;

namespace Domain.InterfacesToDb
{
    public interface IScheduleRepository
    {
        public Task<ScheduleDto> GetSchedule(Guid id);
        public Task RemovePositionAsync(Guid positionId);
    }
}
