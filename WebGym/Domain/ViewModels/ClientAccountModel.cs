
namespace WebGym.Domain.ViewModels
{
    public class ClientAccountModel : AbstractAccountModel
    {
        public StatisticsModel AccountStatistics { get; set; }
        public bool IsAbonementValid { get; set; }

    }
}
