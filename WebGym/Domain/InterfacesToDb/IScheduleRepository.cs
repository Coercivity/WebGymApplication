using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebGym.Domain.DTOs;

namespace WebGym.Domain.InterfacesToDb
{
    public interface IScheduleRepository
    {
        public Task<ScheduleDto> GetSchedule(Guid id);

        public Task<List<PositionDto>> GetSchedulePositions(Guid id, Guid typeId);

        public Task<TrainTypeDto> GetTrainType(Guid id);

    }
}
