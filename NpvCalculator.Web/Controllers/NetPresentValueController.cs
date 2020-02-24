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

        [HttpPost("Compute")]
        public IActionResult ComputeNetPresentValue([FromBody]NetPresentValueInputDto request)
        {
            var result = _netPresentValueService.GetNetPresentValue(request);
            return Ok(result);
        }

        [HttpPost("Save")]
        public IActionResult SaveNetPresentValue([FromBody] NetPresentValueInputDto request)
        {
            return Ok();
        }
    }
}