using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClaimService.Models
{
    public class Claim
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        public string Policy { get; set; }

        public double Claim_amount { get; set; }

        public string Hospital_name { get; set; }

        public string ContactNo { get; set; }
    }
}
