using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NpvCalculator.DataAccess.Entities;

namespace NpvCalculator.DataAccess.Repositories
{
    public class TransactionRepository : RepositoryBase<Transaction>, ITransactionRepository
    {
        public async Task<long> InsertTransaction(Transaction transaction)
        {
            using (var connection = GetSQLiteConnection())
            {
                return connection.Insert(transaction);
            }
        }
        public Task UpdateTransaction(Transaction transaction)
        {
            throw new NotImplementedException();
        }
    }
}
