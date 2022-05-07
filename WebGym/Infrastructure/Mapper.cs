using Domain.DTOs;
using Infrastructure.efModels;
using Infrastructure.ExtractedModels;
using System.Collections.Generic;

namespace Infrastructure
{
    internal static class Mapper
    {
        public static AttendanceDto MapAttendance(Attendance attendance)
        {
            return new AttendanceDto()
            {
                StartTime = attendance.StartTime,
                FinishTime = attendance.FinishTime,
                Id = attendance.Id,
                Pulse = attendance.Pulse,
                WeightData = attendance.WeightData,
                HeartPressure = attendance.HeartPressure,
                HeadPressure = attendance.HeadPressure,
                CaloriesSpent = attendance.CaloriesSpent

            };
        }
        public static ScheduleDto MapSchedule(List<ExtractedSchedule> schedulePositions)
        {

            var positionDtos = new Dictionary<string,List<PositionDto>>();
            var dayPositionDtos = new List<PositionDto>();

            var day = schedulePositions?[0].Day;

            foreach(var position in schedulePositions)
            {
                if (day != position.Day)
                {

                    positionDtos.Add(day, dayPositionDtos);
                    dayPositionDtos = new List<PositionDto>();
                    day = position.Day;
                }
                dayPositionDtos.Add(new PositionDto()
                {
                    CoachId = position.CoachId,
                    StartTime = position.StartTime,
                    Day = position.Day,
                    TrainType = position.TrainType,
                    FinishTime = position.FinishTime,
                    CoachName = position.CoachName,
                    TrainTypeId = position.TrainTypeId,
                    ImageName = position.ImageName

                    

                });
            }
            positionDtos.Add(schedulePositions?[^1].Day, dayPositionDtos);
            return new ScheduleDto()
            {
                Positions = positionDtos
                
            };
        }
        public static AbonementDto MapAbonement(Abonement abonement)
        {
            return new AbonementDto()
            {
                VisitsAmount = abonement.VisitsAmount,
                StartDate = abonement.StartDate,
                FinishDate = abonement.FinishDate,
                IsValid = abonement.IsValid
            };
        }

        public static AccountDto MapAccount(Account account)
        {
            return new AccountDto()
            {
                Email = account.Email,
                Id = account.Id,
                LoginData = account.LoginData,
                PasswordData = account.PasswordData,
                GroupId = account.GroupId
            };
        }



        public static ClientDto MapClient(Client client)
        {
            return new ClientDto()
            {
                Surname = client.Surname,
                FirstName = client.FirstName,
                Patronymic = client.Patronymic,
                PhoneNumber = client.PhoneNumber,
                Id = client.Id,
                Sex = client.Sex
            };
        }

        public static CoachDto MapCoach(Coach coach)
        {
            return new CoachDto()
            {
                FirstName = coach.FirstName,
                Surname = coach.Surname,
                Patronymic = coach.Patronymic,
                Degree = coach.Degree,
                Id = coach.Id,
                PhoneNumber = coach.PhoneNumber,
                Experience = coach.Experience

            };
        }

        public static ServiceDataDto MapServiceData(ServiceData serviceData)
        {
            return new ServiceDataDto()
            {
                ServiceDataTypeId = serviceData.ServiceDataTypeId,
                AbonementId = serviceData.AbonementId,
                AttendanceId = serviceData.AttendanceId
            };
        }

        public static ServiceDataTypeDto MapServiceDataType(ServiceDataType serviceDataType)
        {
            return new ServiceDataTypeDto()
            {
                Id = serviceDataType.Id,
                NameData = serviceDataType.NameData,
                Price = serviceDataType.Price
            };
        }

        public static StatisticsDataDto MapStatisticsData(StatisticsData serviceDataType)
        {
            return new StatisticsDataDto()
            {
                StartDate = serviceDataType.StartDate,
                FinishDate = serviceDataType.FinishDate,
                MedianPulse = serviceDataType.MedianPulse,
                MedianHeadPressure = serviceDataType.MedianHeadPressure,
                MedianHeartPressure = serviceDataType.MedianHeartPressure,
                VisitsAmount = serviceDataType.VisitsAmount,
                Id = serviceDataType.Id,
                WeightData = serviceDataType.WeightData
            };
        }

        public static List<AccountDto> MapAccountsDto(List<Account> accounts)
        {
            var accountsDto = new List<AccountDto>();
            foreach(var account in accounts)
            {
                accountsDto.Add(new AccountDto() { 
                    Email = account.Email,
                    Id = account.Id,
                    LoginData = account.LoginData,
                    PasswordData = account.PasswordData
                });
            }
            return accountsDto;
        }

        public static List<CoachDto> MapCoachesDto(List<Coach> coaches)
        {
            var coachesDto = new List<CoachDto>();
            foreach (var coach in coaches)
            {
                coachesDto.Add(new CoachDto()
                {
                    Surname = coach.Surname,
                    Degree = coach.Degree,
                    Experience = coach.Experience,
                    Id = coach.Id,
                    FirstName = coach.FirstName,
                    PhoneNumber = coach.PhoneNumber,
                    Patronymic = coach.Patronymic
                });
            }
            return coachesDto;
        }

        public static List<ClientDto> MapClientsDto(List<Client> clients)
        {
            var clientsDto = new List<ClientDto>();
            foreach (var client in clients)
            {
                clientsDto.Add(new ClientDto()
                {
                    FirstName = client.FirstName,
                    Surname = client.Surname,
                    Id = client.Id,
                    Patronymic = client.Patronymic,
                    PhoneNumber = client.PhoneNumber
                });
            }
            return clientsDto;
        }

        public static List<AttendanceDto> MapAttendancesDto(List<Attendance> attendances)
        {
            var attendancesDto = new List<AttendanceDto>();
            foreach (var attendance in attendances)
            {
                attendancesDto.Add(new AttendanceDto()
                {
                    StartTime = attendance.StartTime,
                    FinishTime = attendance.FinishTime,
                    HeartPressure = attendance.HeartPressure,
                    Pulse = attendance.Pulse,
                    Id = attendance.Id,
                    WeightData = attendance.WeightData,
                    HeadPressure = attendance.HeadPressure
                });
            }
            return attendancesDto;
        }


    }
}
