using System.Threading.Tasks;
using NpvCalculator.DataAccess.Entities;


namespace NpvCalculator.DataAccess.Repositories
{
    public class NetPresentValueRepository : RepositoryBase<NetPresentValue>, INetPresentValueRepository 
    {
        public async Task<long> InsertNetPresentValue(NetPresentValue netPresentValue)
        {
            using (var connection = GetSQLiteConnection())
            {
                return connection.Insert(netPresentValue);
            }
        }
        public async Task UpdateNetPresentValue(NetPresentValue netPresentValue)
        {
            using (var connection = GetSQLiteConnection())
            {
                connection.Update(netPresentValue);
            }
        }
    }
}
