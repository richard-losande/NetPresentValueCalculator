using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NpvCalculator.Business.DataTransferObjects;

namespace NpvCalculator.Business.Services
{
    public interface INetPresentValueService
    {
        IEnumerable<double> GetNetPresentValue(NetPresentValueInputDto netPresentValueInputDto);
        Task<IEnumerable<NetPresentValueInputDto>> GetAllTransactions();
        NetPresentValueInputDto GetTransactionById(int id);
        void SaveTransaction(NetPresentValueInputDto netPresentValueInputDto);

    }
}
