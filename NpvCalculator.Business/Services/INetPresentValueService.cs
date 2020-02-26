﻿using System;
using System.Collections.Generic;
using System.Text;
using NpvCalculator.Business.DataTransferObjects;

namespace NpvCalculator.Business.Services
{
    public interface INetPresentValueService
    {
        IEnumerable<double> GetNetPresentValue(NetPresentValueInputDto netPresentValueInputDto);
        IEnumerable<NetPresentValueInputDto> GetAllTransactions();
        NetPresentValueInputDto GetTransactionById(int id);
        void SaveTransaction(NetPresentValueInputDto netPresentValueInputDto);

    }
}
