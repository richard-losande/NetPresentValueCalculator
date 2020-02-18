using System;
using System.Collections.Generic;
using System.Text;
using NpvCalculator.Business.DataTransferObjects;

namespace NpvCalculator.Business.Services
{
    public interface INetPresentValueService
    {
        double GetNetPresentValue(NetPresentValueInputDto netPresentValueInputDto);
    }
}
