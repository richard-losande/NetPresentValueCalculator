

using System.Threading.Tasks;
using NpvCalculator.DataAccess.Entities;

namespace NpvCalculator.DataAccess.Repositories
{
    public interface INetPresentValueRepository
    {
        Task<long> InsertNetPresentValue(NetPresentValue netPresentValue);
        Task UpdateNetPresentValue(NetPresentValue netPresentValue);
    }
}
