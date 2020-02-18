using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NpvCalculator.Business.DataTransferObjects;
using NpvCalculator.Business.Factories;
using NpvCalculator.Business.Services;

namespace NpvCalculator.Controllers
{
    [Route("api/netpresentvalue")]
    [ApiController]
    public class NetPresentationValueController : Controller
    {
        private readonly INetPresentValueService _netPresentValueService;
        public NetPresentationValueController(INetPresentValueService eNetPresentValueService)
        {
            _netPresentValueService = eNetPresentValueService;
        }

        [HttpPost("netpresentvalueresult")]
        public IActionResult ComputeNetPresentValue([FromBody]NetPresentValueInputDto request)
        {
             var result = _netPresentValueService.GetNetPresentValue(request);
             return Ok(result);
        }
    }
}