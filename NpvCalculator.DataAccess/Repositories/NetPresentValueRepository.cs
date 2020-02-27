using System.Threading.Tasks;
using NpvCalculator.DataAccess.Entities;


namespace NpvCalculator.DataAccess.Repositories
{
    public class NetPresentValueRepository : RepositoryBase<NetPresentValue>, INetPresentValueRepository
    {
        public async Task<long> InsertNetPresentValue(NetPresentValue netPresentValue)
        {
            var connection = GetSQLiteConnection();
            return await connection.InsertAsync(netPresentValue);
        }
        public async Task UpdateNetPresentValue(NetPresentValue netPresentValue)
        {
            var connection = GetSQLiteConnection();
           await connection.UpdateAsync(netPresentValue);

        }
    }
}
