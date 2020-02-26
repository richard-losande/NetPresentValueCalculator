

using System.Threading.Tasks;
using NpvCalculator.DataAccess.Entities;

namespace NpvCalculator.DataAccess.Repositories
{
    public interface ICashFlowRepository
    {
        Task<long> InsertCashFlow(CashFlow cashFlow);
        Task UpdateCashFlow(CashFlow cashFlow);
    }
}
