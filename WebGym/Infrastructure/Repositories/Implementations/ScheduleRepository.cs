using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebGym.Domain.DTOs;
using WebGym.Domain.InterfacesToDb;
using WebGym.Infrastructure;

namespace WebGym.Infrastructure.Repositories.Implementations
{
    public class ScheduleRepository : IScheduleRepository
    {
        private readonly GymDbContext _gymDbContext;

        public ScheduleRepository(GymDbContext gymDbContext)
        {
            _gymDbContext = gymDbContext;
        }

        public async Task<ScheduleDto> GetSchedule(Guid id)
        {
            var schedule = await _gymDbContext.Schedules.Where(x => x.Id.Equals(id)).FirstOrDefaultAsync();
            return Mapper.MapSchedule(schedule);
        }

        public async Task<List<PositionDto>> GetSchedulePositions(Guid scheduleId, Guid trainTypeId)
        {
            var positions = await _gymDbContext.Positions.Where(x => x.ScheduleId.Equals(scheduleId) && x.TrainTypeId.Equals(trainTypeId)).ToListAsync();


            return Mapper.MapSchedulePositions(positions);
        }

        public async Task<TrainTypeDto> GetTrainType(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
