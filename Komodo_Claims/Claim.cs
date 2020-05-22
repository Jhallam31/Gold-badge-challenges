using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_Claims
{
    public enum ClaimType { car=1, home, theft}
    public class Claim
    {
        public int ClaimID { get; set; }

        public ClaimType TypeOfClaim { get; set; }

        public string Description { get; set; }
        public double ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool ClaimIsValid { get; set; }

        public Claim() { }
        public Claim(int claimId, ClaimType typeOfClaim, string description, double claimAmount, DateTime dateOfIncident, DateTime dateOfClaim, bool claimIsValid)
        {
            ClaimID = claimId;
            TypeOfClaim = typeOfClaim;
            Description = description;
            ClaimAmount = claimAmount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;
            ClaimIsValid = claimIsValid;
        }
    }
}
