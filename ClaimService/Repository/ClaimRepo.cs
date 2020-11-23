using ClaimService.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClaimService.Repository
{
    public class ClaimRepo : IClaimRepo
    {
        private readonly ClaimDbContext claimDbContext;

        public ClaimRepo(ClaimDbContext claimsDbContext)
        {
            this.claimDbContext = claimsDbContext;
        }
        public IEnumerable<Claim> GetAll()
        {

     

            var claimlist = claimDbContext.Claims.ToList();
            return claimlist;

        }
        public Claim ClaimUpload(Claim claim)
        {
            if(claim ==null)
            {
                return null;
            }

            var result = claimDbContext.Claims.Add(claim);

            claimDbContext.SaveChanges();
            return claim;
        }



    }
}
