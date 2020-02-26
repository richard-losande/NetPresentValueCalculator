

using System.Collections.Generic;
using System.Threading.Tasks;
using NpvCalculator.DataAccess.Entities;

namespace NpvCalculator.DataAccess.Repositories
{
    public interface ITransactionRepository
    {
        Task<long> InsertTransaction(Transaction transaction);
        Task UpdateTransaction(Transaction transaction);
        Task<IEnumerable<Transaction>> GetAllTransactions();
        Task<Transaction> GetTransactionById(int id);
    }
}
