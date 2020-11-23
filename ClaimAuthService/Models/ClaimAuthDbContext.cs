using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClaimAuthService.Models
{
    public class ClaimAuthDbContext:DbContext
    {

        public ClaimAuthDbContext(DbContextOptions<ClaimAuthDbContext> options) : base(options)
        {

        }
        public virtual DbSet<Claim> Claims { get; set; }
    }
}
