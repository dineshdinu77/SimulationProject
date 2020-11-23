using ClaimAuthService.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClaimAuthService.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ClaimAuthController : ControllerBase
    {
        private readonly IClaimAuthRepo _claimAuthRepository;
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(ClaimAuthController));
        public ClaimAuthController(IClaimAuthRepo claimsAuthRepo)
        {
            _claimAuthRepository = claimsAuthRepo;
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                _log4net.Info("Get BillingAmount by Id accessed");
                double billingAmount = _claimAuthRepository.BillingAmount(id);
                if(billingAmount==0)
                {
                    _log4net.Info("Wrong Id");
                    return new NotFoundResult();
                }

                return new OkObjectResult(billingAmount);

            }
            catch
            {
                _log4net.Error("Error in Getting Billing Details");
                return new NoContentResult();

            }
        }
    }
}
