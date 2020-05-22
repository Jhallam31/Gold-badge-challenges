using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_Claims
{
    public class ClaimRepository
    {
        public Queue<Claim> _claimDirectory = new Queue<Claim>();
        
        //Add claim to queue
        public void AddClaimToQueue(Claim claim)
        {
            
            _claimDirectory.Enqueue(claim);

        }
        
        //Show All Claims
        public Queue<Claim> GetClaimsQueue()
        {
            return _claimDirectory;
        }
        
        //Display claim and formatting
        public void DisplayClaim(Claim claim,DateTime dateOfIncident, DateTime dateOfClaim)
        {
            string accidentdateDisplay = dateOfIncident.ToShortDateString();
            string claimdateDisplay = dateOfClaim.ToShortDateString();

            string IDlabel = "ID";
            string TypeLabel = "Type";
            string DescriptionLabel = "Description";
            string ClaimLabel = "Amount";
            string accidentDateLabel = "Incident Date";
            string claimDateLabel = "Claim Date";
            string isValidLabel = "IsValid";

            Console.WriteLine($"{IDlabel,-10}{TypeLabel, -10}{DescriptionLabel, -40}{ClaimLabel, -10}{accidentDateLabel, -18}{claimDateLabel, -18}{isValidLabel,-18}");
            Console.WriteLine($"\n"+
                $"{claim.ClaimID,-10}{claim.TypeOfClaim,-10}" +
                $"{claim.Description,-40}{claim.ClaimAmount, -10}" +
                $"{accidentdateDisplay,-18}{claimdateDisplay,-18}{claim.ClaimIsValid,-18}");
            
        }

        //get next claim in queue
        public Claim GetNextClaim()
        {
            Claim nextClaim = _claimDirectory.Peek();
            return nextClaim;
        }

        public Claim GetClaimByID(int claimID)
        {

            foreach (Claim claim in _claimDirectory)
            {
                if (claim.ClaimID == claimID)
                {

                    return claim;
                }
                else 
                {
                    Console.WriteLine("No claim with that number, please try again.");
                }   
            }
            return null;
        }
        //Full add-claim input process
        

        //verify validity
        public bool IsClaimValid(DateTime dateOfIncident, DateTime dateOfClaim)
        {
            bool claimIsValid = true;
            int daysSinceIncident = (dateOfClaim - dateOfIncident).Days;
            if (daysSinceIncident > 30)
            {
                claimIsValid = false;
                return claimIsValid;
            }
            else
            {
                claimIsValid = true;
                return claimIsValid;
            }
        }

        //dequeue next available claim
        public void HandleNextClaim()
        {

            GetNextClaim();
            _claimDirectory.Dequeue();


        }

    }
}
