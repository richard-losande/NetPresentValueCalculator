using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NpvCalculator.DataAccess.Entities;

namespace NpvCalculator.DataAccess.Repositories
{
    public class CashFlowRepository : RepositoryBase<CashFlow>, ICashFlowRepository
    {
        public async Task<long> InsertCashFlow(CashFlow cashFlow)
        {
            var connection = GetSQLiteConnection();
            return await connection.InsertAsync(cashFlow);
        }
        public async Task UpdateCashFlow(CashFlow cashFlow)
        {
            var connection = GetSQLiteConnection();
             await connection.UpdateAsync(cashFlow);
        }
    }
}
