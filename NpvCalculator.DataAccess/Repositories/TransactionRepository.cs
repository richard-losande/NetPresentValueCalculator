using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NpvCalculator.DataAccess.Entities;

namespace NpvCalculator.DataAccess.Repositories
{
    public class TransactionRepository : RepositoryBase<Transaction>, ITransactionRepository
    {
        public async Task<IEnumerable<Transaction>> GetAllTransactions()
        {
            string query = $"SELECT * FROM [Transaction]";
            var connection = GetSQLiteConnection();
            return await connection.QueryAsync<Transaction>(query);
        }

        public async Task<Transaction> GetTransactionById(int id)
        {
            string query = $"SELECT * FROM Transaction WHERE TransacationId = {id}";
            var connection = GetSQLiteConnection();
            return  await connection.FindWithQueryAsync<Transaction>(query);
        }
        public async Task<long> InsertTransaction(Transaction transaction)
        {
            var connection = GetSQLiteConnection();
            await connection.InsertAsync(transaction);
            return transaction.Id;
        }
        public async Task UpdateTransaction(Transaction transaction)
        {
            var connection = GetSQLiteConnection();
            connection.UpdateAsync(transaction);
        }
    }
}
