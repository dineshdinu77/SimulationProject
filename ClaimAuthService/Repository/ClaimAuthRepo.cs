using ClaimAuthService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClaimAuthService.Repository
{
    public class ClaimAuthRepo:IClaimAuthRepo
    {
        private readonly ClaimAuthDbContext claimAuthDbContext;

        double bill = 0;

        public ClaimAuthRepo(ClaimAuthDbContext claimsDbContext)
        {
            this.claimAuthDbContext = claimsDbContext;
        }
        public double BillingAmount(int userid)
        {
            Claim d = claimAuthDbContext.Claims.FirstOrDefault(p => p.Id == userid);
            if(d==null)
            {
                return 0;
            }

            double amount = d.Claim_amount;


            if(amount>1000000)
            {
                bill = amount * 0.5;
            }
            else if(amount>500000 && amount<=1000000)
            {
                bill = amount * 0.6;

            }
            else if(amount>100000 && amount<=500000)
            {
                bill = amount * 0.7;
            }
            else
            {
                bill = amount * 0.8;
            }
          
            return bill;
        }
    }
}
