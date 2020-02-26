

using System.Threading.Tasks;
using NpvCalculator.DataAccess.Entities;

namespace NpvCalculator.DataAccess.Repositories
{
    public interface ITransactionRepository
    {
        Task<long> InsertTransaction(Transaction transaction);
        Task UpdateTransaction(Transaction transaction);
    }
}
