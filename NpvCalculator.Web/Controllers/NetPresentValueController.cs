using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NpvCalculator.Business.DataTransferObjects;
using NpvCalculator.Business.Services;

namespace NpvCalculator.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NetPresentValueController : ControllerBase
    {
        private readonly INetPresentValueService _netPresentValueService;
        public NetPresentValueController(INetPresentValueService eNetPresentValueService)
        {
            _netPresentValueService = eNetPresentValueService ?? throw new ArgumentException(nameof(eNetPresentValueService));
        }

        [HttpPost("compute")]
        public IActionResult ComputeNetPresentValue([FromBody]NetPresentValueInputDto netPresentValueInputDto)
        {
            var result = _netPresentValueService.GetNetPresentValue(netPresentValueInputDto);
            return Ok(result);
        }

        [HttpPost("save")]
        public IActionResult SaveNetPresentValue([FromBody] NetPresentValueInputDto netPresentValueInputDto)
        {
            _netPresentValueService.SaveTransaction(netPresentValueInputDto);
            return Ok();
        }

        [HttpGet("transactions")]
        public IActionResult GetAllTransactions()
        {
            var transactions = _netPresentValueService.GetAllTransactions();
            return Ok(transactions);
        }

        [HttpGet("transactions/[id]")]
        public IActionResult GetTransactionById(int id)
        {
            var transaction = _netPresentValueService.GetTransactionById(id);
            return Ok(transaction);
        }
    }
}