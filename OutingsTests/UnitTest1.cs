using System;
using System.Collections.Generic;
using CompanyOutings;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OutingsTests
{
    [TestClass]
    public class UnitTest1
    {
        public readonly Outings_Repository _repo = new Outings_Repository();
        public readonly List<Outing> _outingsDirectory = new List<Outing>();

        [TestMethod]
        public void GetDirectoryMethod()
        {
            //Arrange 
            SeedList();
            
            //Act
            _repo.GetOutingsList();
            
            //Assert
            int expected = 3;
            int actual = _outingsDirectory.Count;

            Assert.AreEqual(expected, actual);


        }
        [TestMethod]
        public void GrandTotalTest()
        {
            //Arrange
            DateTime seedOutingDate = new DateTime(2018, 04, 25);
            DateTime seedOutingDate2 = new DateTime(2019, 06, 17);
            Outing bowlingTrip = new Outing(OutingType.Bowling, 23, seedOutingDate, 23.75, 546.25);
            Outing cedarPoint = new Outing(OutingType.Amusement_Park, 11, seedOutingDate2, 95.20, 1047.20);
            _repo.AddOutingToList(bowlingTrip);
            _repo.AddOutingToList(cedarPoint);
           
            
            //Act
            _repo.CalculateGrandTotal();

            //Assert

            double expected = 1593.45;
            double actual = _repo.CalculateGrandTotal();
            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void TotalByTypeTest()
        {
            //Arrange
            DateTime seedOutingDate = new DateTime(2018, 04, 25);
            DateTime seedOutingDate2 = new DateTime(2019, 06, 17);
            DateTime seedOutingDate3 = new DateTime(2019, 11, 20);

            Outing bowlingTrip2 = new Outing(OutingType.Bowling, 25, seedOutingDate3, 19.95, 498.75);
            Outing bowlingTrip = new Outing(OutingType.Bowling, 23, seedOutingDate, 23.75, 546.25);
            Outing cedarPoint = new Outing(OutingType.Amusement_Park, 11, seedOutingDate2, 95.20, 1047.20);
            _repo.AddOutingToList(bowlingTrip);
            _repo.AddOutingToList(cedarPoint);
            _repo.AddOutingToList(bowlingTrip2);
            //Act

            _repo.CalculateOutingCostByType(OutingType.Bowling);

            //Assert
            double expected = 1045.00;
            double actual = _repo.CalculateOutingCostByType(OutingType.Bowling);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void AddOutingCountShouldIncrease()
        {
            //Arrange
            DateTime seedOutingDate = new DateTime(2019, 11, 20);
            Outing outing = new Outing(OutingType.Bowling, 25, seedOutingDate, 19.95, 498.75);

            //Act
            _repo.AddOutingToList(outing);
            
            //Assert
            int expected = 1;
            int actual = _repo._outingsDirectory.Count;

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void SingleOutingSum()
        {
            //Arrange
            double perPersonCost = 12.55;
            int attendees = 34;
            //Act
            _repo.SingleOutingTotalCost(perPersonCost, attendees);
            //Assert
            double expected = 426.7;
            double actual = _repo.SingleOutingTotalCost(perPersonCost, attendees);

            Assert.AreEqual(expected, actual);
        }

        private void SeedList()
        {
            DateTime seedOutingDate = new DateTime(2018, 04, 25);
            DateTime seedOutingDate2 = new DateTime(2019, 06, 17);
            DateTime seedOutingDate3 = new DateTime(2019, 11, 20);

            Outing bowlingTrip = new Outing(OutingType.Bowling, 25, seedOutingDate, 19.95, 498.75);
            Outing cedarPoint = new Outing(OutingType.Amusement_Park, 11, seedOutingDate2, 95.20, 1047.20);
            Outing theWigglesLive = new Outing(OutingType.Concert, 43, seedOutingDate3, 19.95, 857.85);
            _repo.AddOutingToList(bowlingTrip);
            _repo.AddOutingToList(cedarPoint);
            _repo.AddOutingToList(theWigglesLive);
        }
    }
}
