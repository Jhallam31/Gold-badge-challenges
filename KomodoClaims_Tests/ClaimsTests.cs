using System;
using System.Collections.Generic;
using Komodo_Claims;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KomodoClaims_Tests
{
    

    [TestClass]
    public class ClaimsTests
    {


        public readonly Queue<Claim> _claimDirectory = new Queue<Claim>();
        public readonly ClaimRepository _repo = new ClaimRepository();
        
        [TestInitialize]

        public void SeedQueue()
        {
            
        


            DateTime seedDateIncident = new DateTime(2018, 4, 25);
            DateTime seedDateClaim = new DateTime(2018, 4, 27);
            Claim exsistingClaim = new Claim(1, ClaimType.car, "Car accident on 464", 400.00, seedDateIncident, seedDateClaim, true);

            DateTime seedDateIncident2 = new DateTime(2019, 6, 25);
            DateTime seedDateClaim2 = new DateTime(2019, 8, 27);
            Claim exsistingClaim2 = new Claim(2, ClaimType.home, "Hail damage to roof", 4000.00, seedDateIncident2, seedDateClaim2, false);

            DateTime seedDateIncident3 = new DateTime(2019, 6, 25);
            DateTime seedDateClaim3 = new DateTime(2019, 7, 20);
            Claim exsistingClaim3 = new Claim(3, ClaimType.theft, "Valuables stolen from home", 1500.00, seedDateIncident3, seedDateClaim3, false);

            _repo.AddClaimToQueue(exsistingClaim);
            _repo.AddClaimToQueue(exsistingClaim2);
            _repo.AddClaimToQueue(exsistingClaim3);
        }

        [TestMethod]
        public void AddtoQueueCountShouldIncrease()


        {
            //Arrange

            DateTime testDateOfIncident = new DateTime(2020, 06, 25);
            DateTime testDateClaim = new DateTime(2020, 06, 27);
            Claim testClaim = new Claim(454, ClaimType.home, "Hail damage to roof", 5500.00, testDateOfIncident, testDateClaim, true);

            //Act
            _repo.AddClaimToQueue(testClaim);

            //Assert

            int actual = _repo.GetClaimsQueue().Count;
            int expected = 4;

            Assert.AreEqual(expected,actual);
        }

        [TestMethod]
        public void GetNextClaimTest()
        {
            //Arrange is Seed
            //Act
            _repo.GetNextClaim();
            //Assert


            Claim actual = _repo.GetNextClaim();
            Claim expected = _repo.GetClaimByID(1);
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]

        public void HandleNextClaimTest()

        {
            //Arrang
            //Act
            _repo.HandleNextClaim();
            //Assert

            int actualCount = _repo.GetClaimsQueue().Count;
            int expectedCount = 2;
            Assert.AreEqual(expectedCount, actualCount);

        }



    }
}
