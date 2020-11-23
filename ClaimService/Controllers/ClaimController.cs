using ClaimService.Models;
using ClaimService.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClaimService.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ClaimController : ControllerBase
    {
        private readonly IClaimRepo _claimRepository;
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(ClaimController));
        public ClaimController(IClaimRepo claimRepository)
        {
            _claimRepository = claimRepository;
        }

        // GET api/<ClaimsController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                _log4net.Info("Get ClaimDetail list");
                IEnumerable<Claim> claimslist = _claimRepository.GetAll();

                return  Ok(claimslist);

               

                

            }
            catch
            {
                _log4net.Error("Error in Getting Claims Details");
                return new NoContentResult();
            }
            
        }

        // POST api/<ClaimsController>
        [HttpPost]
        public IActionResult Post([FromBody] Claim claim)
        {
            try
            {
                _log4net.Info("Claim Details Getting Added");
                if (ModelState.IsValid)
                {

                    var claimobj = _claimRepository.ClaimUpload(claim);

                    return new OkObjectResult(claimobj);

                }
                return BadRequest();

            }
            catch
            {
                _log4net.Error("Error in Adding Claim Details");
                return new NoContentResult();
            }
        }
    }
}
