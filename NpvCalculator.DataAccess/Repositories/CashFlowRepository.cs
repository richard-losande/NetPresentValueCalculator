using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NpvCalculator.DataAccess.Entities;

namespace NpvCalculator.DataAccess.Repositories
{
    public class CashFlowRepository :RepositoryBase<CashFlow>, ICashFlowRepository
    {
        public async Task<long> InsertCashFlow(CashFlow cashFlow)
        {
            using (var connection = GetSQLiteConnection())
            {
                return connection.Insert(cashFlow); 
            }
        }
        public async Task UpdateCashFlow(CashFlow cashFlow)
        {
            using (var connection = GetSQLiteConnection())
            {
                connection.Update(cashFlow);
            }
        }
    }
}
