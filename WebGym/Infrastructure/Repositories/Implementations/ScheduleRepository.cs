using Domain.DTOs;
using Domain.InterfacesToDb;
using Infrastructure.ExtractedModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Infrastructure.Repositories.Implementations
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
                                   CoachName = c.Surname + " " + c.FirstName[0] + ". " + c.Patronymic[0] + ".",
                                   CoachId = c.Id,
                                   TrainType = t.Description,
                                   PositionId = p.Id,
                                   ScheduleDescription = s.Description,
                                   TrainTypeId = t.Id,
                                   ImageName = t.ImagePath
                               }).ToListAsync();

            return Mapper.MapSchedule(schedulePositions);
        }

        public async Task RemovePositionAsync(Guid positionId)
        {
            var position = await _gymDbContext.Positions.FirstAsync(x => x.Id.Equals(positionId));
             _gymDbContext.Positions.Remove(position);
            await _gymDbContext.SaveChangesAsync();
        }
    }
}

