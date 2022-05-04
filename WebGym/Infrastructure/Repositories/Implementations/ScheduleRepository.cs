using Infrastructure.ExtractedModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebGym.Domain.DTOs;
using WebGym.Domain.InterfacesToDb;

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

            var schedulePositions = await (from p in _gymDbContext.Positions
                               join s in _gymDbContext.Schedules
                               on p.ScheduleId equals s.Id
                               join c in _gymDbContext.Coaches
                               on p.CoachId equals c.Id
                               join t in _gymDbContext.TrainTypes
                               on p.TrainTypeId equals t.Id
                               join d in _gymDbContext.DayNamings
                               on p.DayNamingsId equals d.Id
                               where p.ScheduleId == id
                               orderby d.Id, p.StartTime

                               select new ExtractedSchedule
                               {
                                   StartTime = p.StartTime,
                                   FinishTime = p.FinishTime,
                                   Day = d.DayData,
                                   CoachName = c.Surname + " " + c.FirstName + " " + c.Patronymic,
                                   CoachId = c.Id,
                                   TrainType = t.Description,
                                   Id = s.Id,
                                   PositionId = p.Id,
                                   ScheduleDescription = s.Description,
                                   TrainTypeId = t.Id
                               }).ToListAsync();

            return Mapper.MapSchedule(schedulePositions);
        }


    }
}

