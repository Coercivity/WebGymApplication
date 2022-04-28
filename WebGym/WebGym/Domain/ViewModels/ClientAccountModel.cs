using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebGym.Domain.ViewModels
{
    public class ClientAccountModel : AbstractAccountModel
    {
        public StatisticsModel AccountStatistics { get; set; }
        public Abonement ClientAbonement { get; set; }
        public bool IsAbonementValid { get; set; }

    }
}
