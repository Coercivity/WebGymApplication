
using Domain.DTOs;
using System;
using System.Collections.Generic;

namespace Domain.ViewModels
{
    public class ClientAccountModel : AbstractAccountModel
    {
        public StatisticsModel AccountStatistics { get; set; }
        public List<TrainTypeDto> TrainTypes { get; set; }
        public Dictionary<Guid, int> TrainTypesDictionary { get; set; }
        public AbonementModel Abonement { get; set; }
        public DateTime? BirthDate { get; set; }

        public bool IsValid { get; set; }

    }
}
