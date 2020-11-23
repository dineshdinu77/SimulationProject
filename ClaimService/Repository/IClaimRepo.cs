using ClaimService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClaimService.Repository
{
    public interface IClaimRepo
    {
        public IEnumerable<Claim> GetAll();
        Claim ClaimUpload(Claim entity);
    }
}
