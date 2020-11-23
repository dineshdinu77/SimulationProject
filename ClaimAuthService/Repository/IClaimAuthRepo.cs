using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClaimAuthService.Repository
{
    public interface IClaimAuthRepo
    {
        public double BillingAmount(int userid);
    }
}
