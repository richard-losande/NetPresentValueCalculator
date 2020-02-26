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
            string query = $"SELECT * FROM Transaction";
            IEnumerable<Transaction> transactions = null;
            await Task.Run(() =>
            {
                using (var connection = GetSQLiteConnection())
                {
                    transactions = connection.Query<Transaction>(query);
                }
            });

            return transactions;
        }

        public async Task<Transaction> GetTransactionById(int id)
        {
            string query = $"SELECT * FROM Transaction WHERE TransacationId = {id}";
            Transaction transaction = null;
            await Task.Run(() =>
            {
                using (var connection = GetSQLiteConnection())
                {
                    transaction = connection.Query<Transaction>(query).FirstOrDefault();
                }
            });
            
            return transaction;
        }

        public async Task<long> InsertTransaction(Transaction transaction)
        {
            int result = 0;
            await Task.Run(() =>
            {
                using (var connection = GetSQLiteConnection())
                {
                    result = connection.Insert(transaction);
                }
            });

            return result;
        }
        public async Task UpdateTransaction(Transaction transaction)
        {
            await Task.Run(() =>
            {
                using (var connection = GetSQLiteConnection())
                {
                    connection.Update(transaction);
                }
            });
            
        }
    }
}
