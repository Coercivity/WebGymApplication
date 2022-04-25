using System.Threading.Tasks;

namespace WebGym.Infrastructure.Repositories.Interfaces
{
    public interface IStatisticsRepository
    {
        public Task<StatisticsData> GetStatisticsByIdAsync();
    }
}
